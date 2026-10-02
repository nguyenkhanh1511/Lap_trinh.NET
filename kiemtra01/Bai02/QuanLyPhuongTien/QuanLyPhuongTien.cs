namespace QuanLyPhuongTien;

// ============================================================
//  Class QuanLyPhuongTien – Quản lý tập hợp
// ============================================================
public class QuanLyPhuongTien
{
    private readonly List<PhuongTien> _danhSach = new();

    // 1. Thêm phương tiện
    public void AddPhuongTien(PhuongTien pt)
    {
        ArgumentNullException.ThrowIfNull(pt);
        _danhSach.Add(pt);
    }

    // 2. Hiển thị tất cả kèm giá lăn bánh
    public void DisplayAll()
    {
        Console.WriteLine("\n" + new string('═', 80));
        Console.WriteLine("  DANH SÁCH PHƯƠNG TIỆN GIAO THÔNG ");
        Console.WriteLine(new string('═', 80));

        if (_danhSach.Count == 0)
        {
            Console.WriteLine("  (Danh sách trống)");
            return;
        }

        int stt = 1;
        foreach (var pt in _danhSach)
        {
            Console.WriteLine($"\n  [{stt++}] {pt.GetInfo()}");
            Console.WriteLine($"       ➤ Giá lăn bánh: {pt.TinhGiaLanBanh():N0} VNĐ");
        }
        Console.WriteLine(new string('─', 80));
    }

    // 3. Tìm phương tiện có giá lăn bánh cao nhất (Đa hình)
    public PhuongTien? FindMaxGiaLanBanh()
    {
        if (_danhSach.Count == 0) return null;
        return _danhSach.OrderByDescending(pt => pt.TinhGiaLanBanh()).First();
    }

    // 4. Tìm theo tên hãng (LINQ)
    public List<PhuongTien> SearchByName(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword)) return [];
        return _danhSach
            .Where(pt => pt.TenHang.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
