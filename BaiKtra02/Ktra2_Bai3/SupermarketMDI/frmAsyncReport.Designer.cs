namespace SupermarketMDI
{
    partial class frmAsyncReport
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // === Báo cáo doanh thu (trái) ===
            grpBaoCao = new System.Windows.Forms.GroupBox();
            btnTaiBaoCao = new System.Windows.Forms.Button();
            progressTai = new System.Windows.Forms.ProgressBar();
            lblKetQua = new System.Windows.Forms.Label();
            dgvBaoCao = new System.Windows.Forms.DataGridView();

            // === Đồng bộ realtime (phải) ===
            grpDongBo = new System.Windows.Forms.GroupBox();
            btnBatDauDongBo = new System.Windows.Forms.Button();
            lblTrangThaiDongBo = new System.Windows.Forms.Label();
            lblNhatKyTitle = new System.Windows.Forms.Label();
            lstNhatKy = new System.Windows.Forms.ListBox();

            // ===== grpBaoCao =====
            grpBaoCao.SuspendLayout();
            grpBaoCao.Text = "📊 Báo cáo Doanh thu (Async/Await)";
            grpBaoCao.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            grpBaoCao.Location = new System.Drawing.Point(6, 6);
            grpBaoCao.Size = new System.Drawing.Size(640, 460);

            btnTaiBaoCao.Text = "⬇ Tải Báo Cáo Doanh Thu";
            btnTaiBaoCao.Location = new System.Drawing.Point(10, 28);
            btnTaiBaoCao.Size = new System.Drawing.Size(220, 36);
            btnTaiBaoCao.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            btnTaiBaoCao.BackColor = System.Drawing.Color.DarkSlateBlue;
            btnTaiBaoCao.ForeColor = System.Drawing.Color.White;
            btnTaiBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTaiBaoCao.Click += new System.EventHandler(btnTaiBaoCao_Click);

            progressTai.Location = new System.Drawing.Point(10, 72);
            progressTai.Size = new System.Drawing.Size(610, 20);
            progressTai.Minimum = 0;
            progressTai.Maximum = 100;
            progressTai.Visible = false;
            progressTai.Style = System.Windows.Forms.ProgressBarStyle.Continuous;

            lblKetQua.Text = "Nhấn nút để tải báo cáo...";
            lblKetQua.Location = new System.Drawing.Point(10, 98);
            lblKetQua.Size = new System.Drawing.Size(610, 22);
            lblKetQua.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Italic);
            lblKetQua.ForeColor = System.Drawing.Color.DarkBlue;

            dgvBaoCao.Location = new System.Drawing.Point(10, 126);
            dgvBaoCao.Size = new System.Drawing.Size(612, 318);
            dgvBaoCao.AllowUserToAddRows = false;
            dgvBaoCao.AllowUserToDeleteRows = false;
            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            grpBaoCao.Controls.AddRange(new System.Windows.Forms.Control[]
            { btnTaiBaoCao, progressTai, lblKetQua, dgvBaoCao });
            grpBaoCao.ResumeLayout(false);

            // ===== grpDongBo =====
            grpDongBo.SuspendLayout();
            grpDongBo.Text = "🔄 Đồng bộ Dữ liệu Thời gian thực (Cross-Thread)";
            grpDongBo.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            grpDongBo.Location = new System.Drawing.Point(656, 6);
            grpDongBo.Size = new System.Drawing.Size(480, 460);

            btnBatDauDongBo.Text = "▶ Bắt đầu đồng bộ";
            btnBatDauDongBo.Location = new System.Drawing.Point(10, 28);
            btnBatDauDongBo.Size = new System.Drawing.Size(200, 36);
            btnBatDauDongBo.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            btnBatDauDongBo.BackColor = System.Drawing.Color.ForestGreen;
            btnBatDauDongBo.ForeColor = System.Drawing.Color.White;
            btnBatDauDongBo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBatDauDongBo.Click += new System.EventHandler(btnBatDauDongBo_Click);

            lblTrangThaiDongBo.Text = "⏸ Đồng bộ chưa chạy";
            lblTrangThaiDongBo.Location = new System.Drawing.Point(10, 72);
            lblTrangThaiDongBo.Size = new System.Drawing.Size(456, 36);
            lblTrangThaiDongBo.Font = new System.Drawing.Font("Segoe UI", 9f);
            lblTrangThaiDongBo.ForeColor = System.Drawing.Color.DarkGreen;
            lblTrangThaiDongBo.AutoEllipsis = true;

            lblNhatKyTitle.Text = "Nhật ký đồng bộ (mới nhất trên cùng):";
            lblNhatKyTitle.Location = new System.Drawing.Point(10, 116);
            lblNhatKyTitle.Size = new System.Drawing.Size(456, 22);
            lblNhatKyTitle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);

            lstNhatKy.Location = new System.Drawing.Point(10, 140);
            lstNhatKy.Size = new System.Drawing.Size(456, 306);
            lstNhatKy.Font = new System.Drawing.Font("Consolas", 8.5f);
            lstNhatKy.ScrollAlwaysVisible = true;
            lstNhatKy.BackColor = System.Drawing.Color.Black;
            lstNhatKy.ForeColor = System.Drawing.Color.LimeGreen;

            grpDongBo.Controls.AddRange(new System.Windows.Forms.Control[]
            { btnBatDauDongBo, lblTrangThaiDongBo, lblNhatKyTitle, lstNhatKy });
            grpDongBo.ResumeLayout(false);

            // ===== FORM =====
            this.Text = "📊 Báo cáo Thống kê & Đồng bộ";
            this.ClientSize = new System.Drawing.Size(1150, 478);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Load += new System.EventHandler(frmAsyncReport_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmAsyncReport_FormClosing);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { grpBaoCao, grpDongBo });
        }

        #endregion

        private System.Windows.Forms.GroupBox grpBaoCao;
        private System.Windows.Forms.Button btnTaiBaoCao;
        private System.Windows.Forms.ProgressBar progressTai;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.DataGridView dgvBaoCao;

        private System.Windows.Forms.GroupBox grpDongBo;
        private System.Windows.Forms.Button btnBatDauDongBo;
        private System.Windows.Forms.Label lblTrangThaiDongBo;
        private System.Windows.Forms.Label lblNhatKyTitle;
        private System.Windows.Forms.ListBox lstNhatKy;
    }
}
