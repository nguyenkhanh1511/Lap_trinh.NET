using System;
using System.Windows.Forms;

namespace SchoolMDIAsync
{
    public partial class frmMain : Form
    {
        private frmStudent? _frmStudent;
        private frmProduct? _frmProduct;
        private readonly System.Windows.Forms.Timer _clock = new();

        public frmMain() { InitializeComponent(); }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = "👤 Admin";
            lblStatus.Text = "Sẵn sàng";
            _clock.Interval = 1000;
            _clock.Tick += (s, _) => lblTime.Text = DateTime.Now.ToString("HH:mm:ss  dd/MM/yyyy");
            _clock.Start();
        }

        private void MoFormCon<T>(T? instance, Action<T?> setInstance) where T : Form, new()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new T();
                setInstance(instance);
                instance.MdiParent = this;
                instance.FormClosed += (s, e) => setInstance(null);
                instance.Show();
            }
            else instance.Activate();
        }

        // ── Public API ─────────────────────────────────────────────────────
        public void CapNhatTrangThai(string msg)
        {
            if (InvokeRequired) { Invoke(() => CapNhatTrangThai(msg)); return; }
            lblStatus.Text = msg;
        }

        /// <summary>Bật ProgressBar Marquee trên Form cha từ Form con async</summary>
        public void BatDauTienTrinh(string moTa = "Đang xử lý...")
        {
            if (InvokeRequired) { Invoke(() => BatDauTienTrinh(moTa)); return; }
            lblStatus.Text = moTa;
            progressParent.Style = ProgressBarStyle.Blocks;
            progressParent.Value = 0;
            progressParent.Visible = true;
        }

        /// <summary>Cập nhật % tiến trình từ Form con lên StatusStrip Form cha</summary>
        public void CapNhatTienTrinh(int phanTram, string moTa = "")
        {
            if (InvokeRequired) { Invoke(() => CapNhatTienTrinh(phanTram, moTa)); return; }
            progressParent.Value = Math.Clamp(phanTram, 0, 100);
            if (!string.IsNullOrEmpty(moTa)) lblStatus.Text = moTa;
        }

        /// <summary>Tắt ProgressBar sau khi xong</summary>
        public void KetThucTienTrinh(string moTa = "Hoàn tất")
        {
            if (InvokeRequired) { Invoke(() => KetThucTienTrinh(moTa)); return; }
            progressParent.Visible = false;
            lblStatus.Text = moTa;
        }

        // ── Menu / ToolStrip ───────────────────────────────────────────────
        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Đăng xuất?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { foreach (Form c in MdiChildren) c.Close(); lblUser.Text = "👤 Chưa đăng nhập"; }
        }
        private void menuThoat_Click(object sender, EventArgs e) => Close();
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Thoát ứng dụng?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) e.Cancel = true;
        }
        private void menuSinhVien_Click(object sender, EventArgs e) => MoFormCon(_frmStudent, value => _frmStudent = value);
        private void menuSanPham_Click(object sender, EventArgs e)  => MoFormCon(_frmProduct, value => _frmProduct = value);
        private void menuCascade_Click(object sender, EventArgs e)  => LayoutMdi(MdiLayout.Cascade);
        private void menuTileH_Click(object sender, EventArgs e)    => LayoutMdi(MdiLayout.TileHorizontal);
        private void menuTileV_Click(object sender, EventArgs e)    => LayoutMdi(MdiLayout.TileVertical);
        private void tsBtnSinhVien_Click(object sender, EventArgs e)=> MoFormCon(_frmStudent, value => _frmStudent = value);
        private void tsBtnSanPham_Click(object sender, EventArgs e) => MoFormCon(_frmProduct, value => _frmProduct = value);
        private void tsBtnThoat_Click(object sender, EventArgs e)   => Close();
    }
}
