using BookingPR.Data;
using DevExpress.XtraExport.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;    
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BookingPR
{
    public partial class MenuUC : UserControl
    {
        public MenuUC()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            LoadMenu();
        }

        public void RefreshMenu()
        {
            LoadMenu();
        }

        private void LoadMenu()
        {
            flowLayoutPanel1.SuspendLayout();
            try
            {
                flowLayoutPanel1.Controls.Clear();

                // set common FlowLayoutPanel properties once
                flowLayoutPanel1.AutoScroll = true;
                flowLayoutPanel1.WrapContents = true;
                flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
                flowLayoutPanel1.Padding = new Padding(10);
                flowLayoutPanel1.AutoScrollMargin = new Size(10, 10);

                using (var db = new Model1())
                {
                    var list = db.MonAn.AsNoTracking().ToList();
                    var tt = new ToolTip();

                    foreach (var item in list)
                    {
                        try
                        {
                            Panel pnl = new Panel
                            {
                                Width = 200,
                                Height = 250,
                                BorderStyle = BorderStyle.FixedSingle,
                                Margin = new Padding(10),
                                BackColor = Color.FromArgb(230, Color.White),
                                Tag = item
                            };

                            PictureBox pic = new PictureBox
                            {
                                Width = 180,
                                Height = 150,
                                Left = 10,
                                Top = 5,
                                SizeMode = PictureBoxSizeMode.Zoom
                            };

                            string fileName = (item.HinhAnh ?? "").Trim();
                            string foundPath = FindImagePath(fileName, item.TenMon);

                            if (!string.IsNullOrEmpty(foundPath))
                            {
                                try
                                {
                                    byte[] bytes = File.ReadAllBytes(foundPath);
                                    using (var ms = new MemoryStream(bytes))
                                    using (var img = Image.FromStream(ms))
                                    {
                                        pic.Image = new Bitmap(img);
                                    }
                                    tt.SetToolTip(pic, $"Image: {Path.GetFileName(foundPath)}");
                                }
                                catch
                                {
                                    pic.Image = CreatePlaceholderImage(pic.Width, pic.Height);
                                    tt.SetToolTip(pic, $"Image exists but failed to load: {Path.GetFileName(foundPath)}");
                                }
                            }
                            else
                            {
                                pic.Image = CreatePlaceholderImage(pic.Width, pic.Height);
                                tt.SetToolTip(pic, string.IsNullOrEmpty(fileName) ? "No image specified" : $"Missing file: {fileName}");
                            }

                            Label lblName = new Label
                            {
                                Text = string.IsNullOrEmpty(item.TenMon) ? "(Không tên)" : item.TenMon,
                                AutoSize = false,
                                TextAlign = ContentAlignment.MiddleCenter,
                                Dock = DockStyle.Bottom,
                                Height = 40,
                                Font = new Font("Segoe UI", 10, FontStyle.Bold)
                            };

                            Label lblPrice = new Label
                            {
                                Text = $"{(item.Gia):N0} VNĐ",
                                AutoSize = false,
                                TextAlign = ContentAlignment.MiddleCenter,
                                Dock = DockStyle.Bottom,
                                Height = 30,
                                ForeColor = Color.DarkRed,
                                Font = new Font("Segoe UI", 10, FontStyle.Regular)
                            };

                            pnl.Controls.Add(lblPrice);
                            pnl.Controls.Add(lblName);
                            pnl.Controls.Add(pic);

                            flowLayoutPanel1.Controls.Add(pnl);
                        }
                        catch (Exception exItem)
                        {
                            var err = new Panel
                            {
                                Width = 200,
                                Height = 120,
                                BorderStyle = BorderStyle.FixedSingle,
                                Margin = new Padding(10),
                                BackColor = Color.LightSalmon
                            };
                            var lbl = new Label
                            {
                                Text = "Error loading item",
                                Dock = DockStyle.Fill,
                                TextAlign = ContentAlignment.MiddleCenter
                            };
                            var lblEx = new Label
                            {
                                Text = exItem.Message,
                                Dock = DockStyle.Bottom,
                                Height = 40,
                                ForeColor = Color.DarkRed,
                                Font = new Font("Segoe UI", 7)
                            };
                            err.Controls.Add(lblEx);
                            err.Controls.Add(lbl);
                            flowLayoutPanel1.Controls.Add(err);
                        }
                    }
                }
            }
            finally
            {
                flowLayoutPanel1.ResumeLayout();
            }
        }

        // Try to find an image file using several fallbacks:
        // - exact path if DB stored absolute path
        // - Application startup Hinhanh\filename
        // - try multiple extensions
        // - try normalized names (remove diacritics, spaces)
        // - search the Hinhanh folder for a best match
        private string FindImagePath(string dbFileName, string tenMon)
        {
            var candidates = new List<string>();

            // if DB has absolute path or relative path, try it first
            if (!string.IsNullOrWhiteSpace(dbFileName))
            {
                candidates.Add(dbFileName);
                candidates.Add(Path.Combine(Application.StartupPath, "Hinhanh", dbFileName));
                candidates.Add(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Hinhanh", dbFileName));
                candidates.Add(Path.Combine(Application.StartupPath, dbFileName));
            }

            // try using dish name as filename (common pattern)
            if (!string.IsNullOrWhiteSpace(tenMon))
            {
                string simple = NormalizeFileName(tenMon);
                candidates.Add(Path.Combine(Application.StartupPath, "Hinhanh", simple));
                candidates.Add(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Hinhanh", simple));
            }

            string[] exts = new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };

            // try candidates with/without extension
            foreach (var c in candidates)
            {
                if (string.IsNullOrWhiteSpace(c)) continue;

                // exact file if stored w/ extension
                try
                {
                    if (File.Exists(c)) return c;
                }
                catch { }

                // try adding extensions
                string baseName = Path.HasExtension(c) ? Path.Combine(Path.GetDirectoryName(c) ?? string.Empty, Path.GetFileNameWithoutExtension(c)) : c;
                foreach (var ext in exts)
                {
                    var p = baseName + ext;
                    try
                    {
                        if (File.Exists(p)) return p;
                    }
                    catch { }
                }
            }

            // finally search the Hinhanh folder for files that contain the normalized name
            string hinhanhDir = Path.Combine(Application.StartupPath, "Hinhanh");
            if (Directory.Exists(hinhanhDir))
            {
                string normalizedDb = NormalizeFileName(dbFileName);
                string normalizedTen = NormalizeFileName(tenMon);

                try
                {
                    var files = Directory.GetFiles(hinhanhDir);
                    // first, exact normalized filename match
                    foreach (var f in files)
                    {
                        string n = NormalizeFileName(Path.GetFileNameWithoutExtension(f));
                        if (!string.IsNullOrEmpty(normalizedDb) && n == normalizedDb) return f;
                    }
                    // second, contains normalizedDb
                    foreach (var f in files)
                    {
                        string n = NormalizeFileName(Path.GetFileNameWithoutExtension(f));
                        if (!string.IsNullOrEmpty(normalizedDb) && n.Contains(normalizedDb)) return f;
                    }
                    // third, contains normalizedTen
                    foreach (var f in files)
                    {
                        string n = NormalizeFileName(Path.GetFileNameWithoutExtension(f));
                        if (!string.IsNullOrEmpty(normalizedTen) && n.Contains(normalizedTen)) return f;
                    }
                }
                catch { }
            }

            return null;
        }

        // remove diacritics, punctuation and spaces; lower-case for matching
        private string NormalizeFileName(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;
            s = s.Trim().ToLowerInvariant();
            // remove diacritics
            var normalized = s.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var ch in normalized)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                    sb.Append(ch);
            }
            var noDiacritics = sb.ToString().Normalize(NormalizationForm.FormC);
            // remove non-alphanumeric characters
            var cleaned = Regex.Replace(noDiacritics, @"[^0-9a-z]+", "_");
            cleaned = cleaned.Trim('_');
            return cleaned;
        }

        // small helper to create "No Image" placeholder
        private Image CreatePlaceholderImage(int width, int height)
        {
            Bitmap noImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(noImage))
            {
                g.Clear(Color.LightGray);
                using (var f = new Font("Segoe UI", 10, FontStyle.Italic))
                using (var brush = new SolidBrush(Color.DarkGray))
                {
                    var text = "No Image";
                    var sz = g.MeasureString(text, f);
                    g.DrawString(text, f, brush, (width - sz.Width) / 2f, (height - sz.Height) / 2f);
                }
            }
            return noImage;
        }

        private void MenuUC_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    // simple helper: call MenuDebug.CheckImageEntry("cơm chiên trứng");
    // or MenuDebug.UpdateImageFile("cơm chiên trứng", "com_chien_trung.jpg", @"C:\temp\com_chien_trung.jpg");
    public static class MenuDebug
    {
        public static void CheckImageEntry(string tenMon)
        {
            using (var db = new Model1())
            {
                var m = db.MonAn.FirstOrDefault(x => x.TenMon == tenMon);
                if (m == null)
                {
                    MessageBox.Show($"Dish not found: {tenMon}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string fileName = (m.HinhAnh ?? "").Trim();
                string imgPath = Path.Combine(Application.StartupPath, "Hinhanh", fileName);
                bool exists = !string.IsNullOrEmpty(fileName) && File.Exists(imgPath);

                MessageBox.Show(
                    $"TenMon: {m.TenMon}\nHinhAnh: {fileName}\nImgPath: {imgPath}\nFile exists: {exists}",
                    "Image debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void UpdateImageFile(string tenMon, string fileName, string sourceFullPath)
        {
            if (!File.Exists(sourceFullPath))
            {
                MessageBox.Show($"Source file not found: {sourceFullPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string destDir = Path.Combine(Application.StartupPath, "Hinhanh");
            Directory.CreateDirectory(destDir);
            string destPath = Path.Combine(destDir, fileName);

            File.Copy(sourceFullPath, destPath, overwrite: true);

            using (var db = new Model1())
            {
                var m = db.MonAn.FirstOrDefault(x => x.TenMon == tenMon);
                if (m == null)
                {
                    MessageBox.Show($"Dish not found: {tenMon} — file copied to {destPath}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                m.HinhAnh = fileName;
                db.SaveChanges();
            }

            MessageBox.Show($"Image copied to {destPath} and DB updated.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
