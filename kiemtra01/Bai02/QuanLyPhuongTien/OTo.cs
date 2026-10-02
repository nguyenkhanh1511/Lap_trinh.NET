namespace QuanLyPhuongTien;

// ============================================================
//  Class OTo – kế thừa PhuongTien
// ============================================================
public class OTo : PhuongTien
{
    private int    _soChoNgoi;
    private double _dungTichDongCo;

    public int SoChoNgoi
    {
        get => _soChoNgoi;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Số chỗ ngồi phải lớn hơn 0!");
            _soChoNgoi = value;
        }
    }

    public double DungTichDongCo
    {
        get => _dungTichDongCo;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Dung tích động cơ phải lớn hơn 0!");
            _dungTichDongCo = value;
        }
    }

    public OTo(string maPT, string tenHang, int namSanXuat, decimal giaGoc,
               int soChoNgoi, double dungTichDongCo)
        : base(maPT, tenHang, namSanXuat, giaGoc)
    {
        SoChoNgoi      = soChoNgoi;
        DungTichDongCo = dungTichDongCo;
    }

    /// <summary>
    /// ≤9 chỗ : GiaGoc + 12% (trước bạ) + 30% (TTĐB)
    /// >9 chỗ : GiaGoc + 10% (trước bạ)
    /// </summary>
    public override decimal TinhGiaLanBanh()
    {
        if (SoChoNgoi <= 9)
            return GiaGoc + (GiaGoc * 0.12m) + (GiaGoc * 0.30m);
        else
            return GiaGoc + (GiaGoc * 0.10m);
    }

    public override string GetInfo()
        => base.GetInfo()
           + $" | Số chỗ: {SoChoNgoi} | Dung tích ĐC: {DungTichDongCo}L";
}
