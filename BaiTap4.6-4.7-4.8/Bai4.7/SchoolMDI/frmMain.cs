using System;
using System.Windows.Forms;

namespace SchoolMDI
{
    public partial class frmMain : Form
    {
        private frmStudent? _frmStudent;
        private frmProduct? _frmProduct;

        // Timer đồng hồ thực
        private readonly System.Windows.Forms.Timer _clock = new();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = "👤 Admin";
            lblStatus.Text = "Sẵn sàng";
            _clock.Interval = 1000;
            _clock.Tick += (s, _) => lblTime.Text = DateTime.Now.ToString("HH:mm:ss  dd/MM/yyyy");
            _clock.Start();
        }

        // ── Mở Form con (Singleton per Form) ─────────────────────────────────
        private void MoFormCon<T>(Func<T?> getter, Action<T?> setter) where T : Form, new()
        {
            T? instance = getter();

            if (instance == null || instance.IsDisposed)
            {
                instance = new T();
                instance.MdiParent = this;

                // Khi Form con đóng, xóa tham chiếu
                instance.FormClosed += (s, e) =>
                {
                    setter(null);
                };

                setter(instance);
                instance.Show();
            }
            else
            {
                instance.Activate();
            }
        }

        // ── Public API để Form con gọi cập nhật StatusStrip ──────────────────
        public void CapNhatTrangThai(string msg)
        {
            // An toàn cross-thread
            if (InvokeRequired) { Invoke(() => CapNhatTrangThai(msg)); return; }
            lblStatus.Text = msg;
        }

        // ── Menu: Hệ thống ───────────────────────────────────────────────────
        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Đăng xuất?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Form c in MdiChildren) c.Close();
                lblUser.Text = "👤 Chưa đăng nhập";
                CapNhatTrangThai("Đã đăng xuất");
            }
        }

        private void menuThoat_Click(object sender, EventArgs e) => Close();

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Thoát ứng dụng?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        // ── Menu: Danh mục ───────────────────────────────────────────────────
        private void menuSinhVien_Click(object sender, EventArgs e)
            => MoFormCon(() => _frmStudent, value => _frmStudent = value);

        private void menuSanPham_Click(object sender, EventArgs e)
            => MoFormCon(() => _frmProduct, value => _frmProduct = value);

        // ── Menu: Cửa sổ ─────────────────────────────────────────────────────
        private void menuCascade_Click(object sender, EventArgs e)
            => LayoutMdi(MdiLayout.Cascade);
        private void menuTileH_Click(object sender, EventArgs e)
            => LayoutMdi(MdiLayout.TileHorizontal);
        private void menuTileV_Click(object sender, EventArgs e)
            => LayoutMdi(MdiLayout.TileVertical);

        // ── ToolStrip shortcuts ───────────────────────────────────────────────
        private void tsBtnSinhVien_Click(object sender, EventArgs e)
            => MoFormCon(() => _frmStudent, value => _frmStudent = value);
        private void tsBtnSanPham_Click(object sender, EventArgs e)
            => MoFormCon(() => _frmProduct, value => _frmProduct = value);
        private void tsBtnThoat_Click(object sender, EventArgs e)
            => Close();
    }
}
