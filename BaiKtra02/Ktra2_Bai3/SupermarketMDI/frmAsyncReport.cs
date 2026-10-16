using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupermarketMDI
{
    public partial class frmAsyncReport : Form
    {
        // Token để hủy tiến trình đồng bộ ngầm khi Form đóng
        private CancellationTokenSource? _ctsDongBo;

        // Dữ liệu báo cáo giả lập
        private readonly Random _rnd = new Random();

        public frmAsyncReport()
        {
            InitializeComponent();
        }

        private frmMain? FormCha => this.MdiParent as frmMain;

        // =====================================================================
        // LOAD
        // =====================================================================
        private void frmAsyncReport_Load(object sender, EventArgs e)
        {
            lblTrangThaiDongBo.Text = "⏸ Đồng bộ chưa chạy";
            dgvBaoCao.AutoGenerateColumns = false;
            KhoiTaoCotBaoCao();
        }

        private void KhoiTaoCotBaoCao()
        {
            dgvBaoCao.BackgroundColor = System.Drawing.Color.White;
            dgvBaoCao.RowHeadersVisible = false;
            dgvBaoCao.Font = new System.Drawing.Font("Segoe UI", 9f);
            dgvBaoCao.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkSlateBlue;
            dgvBaoCao.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvBaoCao.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            dgvBaoCao.EnableHeadersVisualStyles = false;
            dgvBaoCao.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;

            dgvBaoCao.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "colThang", HeaderText = "Tháng", Width = 80,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                new DataGridViewTextBoxColumn { Name = "colDoanhThu", HeaderText = "Doanh thu (VNĐ)", Width = 160,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } },
                new DataGridViewTextBoxColumn { Name = "colSoDon", HeaderText = "Số đơn", Width = 80,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                new DataGridViewTextBoxColumn { Name = "colTangTruong", HeaderText = "Tăng trưởng (%)", Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            );
        }

        // =====================================================================
        // SCENARIO B: TẢI BÁO CÁO BẤT ĐỒNG BỘ (async / await)
        // =====================================================================
        private async void btnTaiBaoCao_Click(object sender, EventArgs e)
        {
            btnTaiBaoCao.Enabled = false;
            dgvBaoCao.Rows.Clear();
            lblKetQua.Text = "Đang tải dữ liệu...";
            progressTai.Value = 0;
            progressTai.Visible = true;

            // Thông báo lên ProgressBar của Form cha (UI thread — an toàn)
            FormCha?.BatDauTienTrinh("📊 Đang tải báo cáo doanh thu...");

            try
            {
                // Đẩy tác vụ nặng xuống Thread phụ — UI KHÔNG bị đơ
                var danhSachThang = await Task.Run(async () =>
                {
                    var result = new List<(string Thang, decimal DoanhThu, int SoDon, double TangTruong)>();
                    decimal doanhThuTruoc = 0;

                    for (int thang = 1; thang <= 12; thang++)
                    {
                        // Giả lập tính toán nặng (mỗi tháng mất ~350ms → tổng ~4.2 giây)
                        await Task.Delay(350);

                        decimal doanhThu = _rnd.Next(500_000_000, 2_000_000_000);
                        int soDon = _rnd.Next(200, 800);
                        double tangTruong = doanhThuTruoc == 0
                            ? 0
                            : Math.Round((double)((doanhThu - doanhThuTruoc) / doanhThuTruoc * 100), 1);

                        result.Add(($"Tháng {thang:D2}", doanhThu, soDon, tangTruong));
                        doanhThuTruoc = doanhThu;

                        // Cập nhật thanh tiến trình an toàn từ Thread phụ
                        int phanTram = thang * 100 / 12;
                        this.Invoke(() =>
                        {
                            progressTai.Value = phanTram;
                            lblKetQua.Text = $"Đang xử lý tháng {thang}/12...";
                        });
                    }
                    return result;
                });

                // Trở về UI Thread → đổ dữ liệu lên DataGridView
                dgvBaoCao.Rows.Clear();
                decimal tongDoanhThu = 0;
                foreach (var (thang, dt, soDon, tang) in danhSachThang)
                {
                    int row = dgvBaoCao.Rows.Add();
                    dgvBaoCao.Rows[row].Cells["colThang"].Value = thang;
                    dgvBaoCao.Rows[row].Cells["colDoanhThu"].Value = dt;
                    dgvBaoCao.Rows[row].Cells["colSoDon"].Value = soDon;
                    dgvBaoCao.Rows[row].Cells["colTangTruong"].Value =
                        tang >= 0 ? $"+{tang:F1}%" : $"{tang:F1}%";

                    // Tô màu tăng trưởng
                    dgvBaoCao.Rows[row].Cells["colTangTruong"].Style.ForeColor =
                        tang >= 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;

                    tongDoanhThu += dt;
                }

                lblKetQua.Text = $"✅ Tổng doanh thu năm: {tongDoanhThu:N0} VNĐ";
                progressTai.Value = 100;
                FormCha?.KetThucTienTrinh("✅ Tải báo cáo hoàn tất");
            }
            catch (Exception ex)
            {
                lblKetQua.Text = $"❌ Lỗi: {ex.Message}";
                FormCha?.KetThucTienTrinh("❌ Lỗi tải báo cáo");
            }
            finally
            {
                btnTaiBaoCao.Enabled = true;
                await Task.Delay(1500);
                progressTai.Visible = false;
            }
        }

        // =====================================================================
        // SCENARIO C: ĐỒNG BỘ DỮ LIỆU THỜI GIAN THỰC (Cross-Thread)
        // =====================================================================
        private void btnBatDauDongBo_Click(object sender, EventArgs e)
        {
            if (_ctsDongBo != null && !_ctsDongBo.IsCancellationRequested)
            {
                // Đang chạy → dừng lại
                _ctsDongBo.Cancel();
                btnBatDauDongBo.Text = "▶ Bắt đầu đồng bộ";
                btnBatDauDongBo.BackColor = System.Drawing.Color.ForestGreen;
                lblTrangThaiDongBo.Text = "⏹ Đã dừng đồng bộ";
                return;
            }

            // Bắt đầu đồng bộ ngầm
            _ctsDongBo = new CancellationTokenSource();
            btnBatDauDongBo.Text = "⏹ Dừng đồng bộ";
            btnBatDauDongBo.BackColor = System.Drawing.Color.Crimson;

            var token = _ctsDongBo.Token;

            // Chạy trên Background Thread — KHÔNG được truy cập Control trực tiếp!
            Task.Run(async () =>
            {
                int soLuotDongBo = 0;
                while (!token.IsCancellationRequested)
                {
                    await Task.Delay(2000, token); // Mỗi 2 giây đồng bộ 1 lần
                    if (token.IsCancellationRequested) break;

                    soLuotDongBo++;
                    decimal tyGia = 24000 + _rnd.Next(-200, 200);
                    int donHangMoi = _rnd.Next(0, 15);
                    string thoiGian = DateTime.Now.ToString("HH:mm:ss");

                    // *** CROSS-THREAD SAFE: dùng Invoke để về UI Thread ***
                    this.Invoke(() =>
                    {
                        // Kiểm tra InvokeRequired thêm lần nữa để an toàn tuyệt đối
                        if (this.IsDisposed) return;

                        lblTrangThaiDongBo.Text =
                            $"🔄 Lượt {soLuotDongBo} | {thoiGian} | Tỷ giá USD: {tyGia:N0} VNĐ | Đơn mới: +{donHangMoi}";

                        // Thêm dòng log vào ListBox
                        lstNhatKy.Items.Insert(0,
                            $"[{thoiGian}] Tỷ giá: {tyGia:N0} | Đơn hàng mới: +{donHangMoi}");

                        // Giữ tối đa 50 dòng log
                        while (lstNhatKy.Items.Count > 50)
                            lstNhatKy.Items.RemoveAt(lstNhatKy.Items.Count - 1);
                    });
                }

                // Kết thúc: về UI Thread để cập nhật nhãn
                if (!this.IsDisposed)
                    this.Invoke(() =>
                    {
                        lblTrangThaiDongBo.Text = $"⏸ Đã dừng sau {soLuotDongBo} lượt đồng bộ";
                    });

            }, token);
        }

        // =====================================================================
        // ĐÓNG FORM: hủy token để tắt background task
        // =====================================================================
        private void frmAsyncReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ctsDongBo?.Cancel();
        }
    }
}
