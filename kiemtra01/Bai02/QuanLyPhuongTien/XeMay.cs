namespace QuanLyPhuongTien;

// ============================================================
//  Class XeMay – kế thừa PhuongTien
// ============================================================
public class XeMay : PhuongTien
{
    private int _dungTichXylanh;

    public int DungTichXylanh
    {
        get => _dungTichXylanh;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Dung tích xy-lanh phải lớn hơn 0!");
            _dungTichXylanh = value;
        }
    }

    public XeMay(string maPT, string tenHang, int namSanXuat, decimal giaGoc,
                 int dungTichXylanh)
        : base(maPT, tenHang, namSanXuat, giaGoc)
    {
        DungTichXylanh = dungTichXylanh;
    }

    /// <summary>
    /// &lt;175cc : GiaGoc + 2%
    /// ≥175cc  : GiaGoc + 5%
    /// </summary>
    public override decimal TinhGiaLanBanh()
    {
        if (DungTichXylanh < 175)
            return GiaGoc + (GiaGoc * 0.02m);
        else
            return GiaGoc + (GiaGoc * 0.05m);
    }

    public override string GetInfo()
        => base.GetInfo() + $" | Dung tích xy-lanh: {DungTichXylanh}cc";
}
