using System;
using System.Windows.Forms;

namespace SupermarketMDI
{
    public partial class frmMain : Form
    {
        // Giữ tham chiếu để tránh mở nhiều instance
        private frmProductCatalog? _frmProductCatalog;
        private frmAsyncReport? _frmAsyncReport;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblNguoiDung.Text = "👤 Người dùng: Admin";
            progressBar.Visible = false;
        }

        // =====================================================================
        // ĐIỀU HƯỚNG MDI - MỞ FORM CON AN TOÀN (SINGLETON PER FORM)
        // =====================================================================
        private void MoFormCon<T>(Func<T?> getInstance, Action<T?> setInstance) where T : Form, new()
        {
            T? instance = getInstance();
            if (instance == null || instance.IsDisposed)
            {
                instance = new T();
                setInstance(instance);
                instance.MdiParent = this;
                T openedInstance = instance;
                instance.FormClosed += (s, e) =>
                {
                    if (ReferenceEquals(getInstance(), openedInstance))
                        setInstance(null);
                };
                instance.Show();
            }
            else
            {
                instance.Activate();
            }
        }

        // =====================================================================
        // MENU: DANH MỤC
        // =====================================================================
        private void menuQuanLySanPham_Click(object sender, EventArgs e)
            => MoFormCon(() => _frmProductCatalog, instance => _frmProductCatalog = instance);

        private void menuBaoCao_Click(object sender, EventArgs e)
            => MoFormCon(() => _frmAsyncReport, instance => _frmAsyncReport = instance);

        // =====================================================================
        // MENU: CỬA SỔ
        // =====================================================================
        private void menuCascade_Click(object sender, EventArgs e)
            => this.LayoutMdi(MdiLayout.Cascade);

        private void menuTileHorizontal_Click(object sender, EventArgs e)
            => this.LayoutMdi(MdiLayout.TileHorizontal);

        private void menuTileVertical_Click(object sender, EventArgs e)
            => this.LayoutMdi(MdiLayout.TileVertical);

        // =====================================================================
        // MENU: HỆ THỐNG
        // =====================================================================
        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Form child in this.MdiChildren) child.Close();
                lblNguoiDung.Text = "👤 Chưa đăng nhập";
            }
        }

        private void menuThoat_Click(object sender, EventArgs e) => this.Close();

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Xác nhận thoát",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        // =====================================================================
        // PUBLIC API: cho Form con hiển thị ProgressBar trên Form cha
        // =====================================================================
        public void BatDauTienTrinh(string moTa = "Đang xử lý...")
        {
            if (InvokeRequired)
            {
                Invoke(() => BatDauTienTrinh(moTa));
                return;
            }
            lblTrangThai.Text = moTa;
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.Visible = true;
        }

        public void KetThucTienTrinh(string moTa = "Sẵn sàng")
        {
            if (InvokeRequired)
            {
                Invoke(() => KetThucTienTrinh(moTa));
                return;
            }
            progressBar.Visible = false;
            progressBar.Style = ProgressBarStyle.Blocks;
            lblTrangThai.Text = moTa;
        }
    }
}
