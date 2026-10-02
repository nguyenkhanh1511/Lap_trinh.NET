namespace QuanLyPhuongTien;

// ============================================================
//  Abstract Class PhuongTien – Lớp cha trừu tượng
// ============================================================
public abstract class PhuongTien
{
    // ── Private backing fields ─────────────────────────────
    private string  _maPT        = "PT000";
    private string  _tenHang     = "";
    private int     _namSanXuat  = 2000;
    private decimal _giaGoc      = 1m;

    // ── Properties với Validation Encapsulation ────────────
    public string MaPT
    {
        get => _maPT;
        set => _maPT = string.IsNullOrWhiteSpace(value) ? "PT000" : value.Trim();
    }

    public string TenHang
    {
        get => _tenHang;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Tên hãng không được để trống!");
            _tenHang = value.Trim();
        }
    }

    public int NamSanXuat
    {
        get => _namSanXuat;
        set
        {
            int namHienTai = DateTime.Now.Year;
            if (value < 1900 || value > namHienTai)
                throw new ArgumentException(
                    $"Năm sản xuất không hợp lệ! Phải từ 1900 đến {namHienTai}.");
            _namSanXuat = value;
        }
    }

    public decimal GiaGoc
    {
        get => _giaGoc;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Giá gốc phải lớn hơn 0!");
            _giaGoc = value;
        }
    }

    // ── Constructor ────────────────────────────────────────
    protected PhuongTien(string maPT, string tenHang, int namSanXuat, decimal giaGoc)
    {
        MaPT       = maPT;
        TenHang    = tenHang;
        NamSanXuat = namSanXuat;
        GiaGoc     = giaGoc;
    }

    // ── Abstract Method ────────────────────────────────────
    public abstract decimal TinhGiaLanBanh();

    // ── Virtual Method ─────────────────────────────────────
    public virtual string GetInfo()
        => $"[{MaPT}] {TenHang} | Năm SX: {NamSanXuat} | Giá gốc: {GiaGoc:N0} VNĐ";
}
