using QuanLyPhuongTien;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
Console.WriteLine("║               HỆ THỐNG QUẢN LÝ PHƯƠNG TIỆN GIAO THÔNG                    ║");
Console.WriteLine("║            Sinh viên: Nguyễn Duy Khánh – MSSV: 24810310256               ║");
Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");

var ql = new QuanLyPhuongTien.QuanLyPhuongTien();
bool thoat = false;

while (!thoat)
{
    Console.WriteLine("\n╔══════════════════ MENU ══════════════════╗");
    Console.WriteLine("║  1. Thêm Ô tô                            ║");
    Console.WriteLine("║  2. Thêm Xe máy                          ║");
    Console.WriteLine("║  3. Hiển thị tất cả phương tiện          ║");
    Console.WriteLine("║  4. Tìm phương tiện giá lăn bánh cao nhất║");
    Console.WriteLine("║  5. Tìm kiếm theo tên hãng               ║");
    Console.WriteLine("║  0. Thoát                                ║");
    Console.WriteLine("╚══════════════════════════════════════════╝");
    Console.Write("  Chọn chức năng: ");

    string luaChon = Console.ReadLine() ?? "";

    switch (luaChon)
    {
        case "1":
            ThemOTo(ql);
            break;
        case "2":
            ThemXeMay(ql);
            break;
        case "3":
            ql.DisplayAll();
            break;
        case "4":
            TimMaxGiaLanBanh(ql);
            break;
        case "5":
            TimKiemTheoTen(ql);
            break;
        case "0":
            thoat = true;
            Console.WriteLine("\n  Tạm biệt!");
            break;
        default:
            Console.WriteLine("  ❌ Lựa chọn không hợp lệ, vui lòng thử lại.");
            break;
    }
}

// ══════════════════════════════════════════════════════
//  HÀM NHẬP Ô TÔ
// ══════════════════════════════════════════════════════
static void ThemOTo(QuanLyPhuongTien.QuanLyPhuongTien ql)
{
    Console.WriteLine("\n── NHẬP THÔNG TIN Ô TÔ ──");
    try
    {
        Console.Write("  Mã phương tiện (Enter để dùng mặc định PT000): ");
        string maPT = Console.ReadLine() ?? "";

        Console.Write("  Tên hãng xe: ");
        string tenHang = Console.ReadLine() ?? "";

        Console.Write("  Năm sản xuất: ");
        int namSX = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("  Giá gốc (VNĐ): ");
        decimal giaGoc = decimal.Parse(Console.ReadLine() ?? "0");

        Console.Write("  Số chỗ ngồi: ");
        int soChoNgoi = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("  Dung tích động cơ (L): ");
        double dungTich = double.Parse(Console.ReadLine() ?? "0");

        var oto = new OTo(maPT, tenHang, namSX, giaGoc, soChoNgoi, dungTich);
        ql.AddPhuongTien(oto);
        Console.WriteLine($"\n  ✅ Đã thêm: {oto.GetInfo()}");
        Console.WriteLine($"  ➤ Giá lăn bánh: {oto.TinhGiaLanBanh():N0} VNĐ");
    }
    catch (FormatException)
    {
        Console.WriteLine("  ❌ Lỗi: Sai định dạng số, vui lòng nhập lại.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"  ❌ Lỗi validation: {ex.Message}");
    }
}

// ══════════════════════════════════════════════════════
//  HÀM NHẬP XE MÁY
// ══════════════════════════════════════════════════════
static void ThemXeMay(QuanLyPhuongTien.QuanLyPhuongTien ql)
{
    Console.WriteLine("\n── NHẬP THÔNG TIN XE MÁY ──");
    try
    {
        Console.Write("  Mã phương tiện (Enter để dùng mặc định PT000): ");
        string maPT = Console.ReadLine() ?? "";

        Console.Write("  Tên hãng xe: ");
        string tenHang = Console.ReadLine() ?? "";

        Console.Write("  Năm sản xuất: ");
        int namSX = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("  Giá gốc (VNĐ): ");
        decimal giaGoc = decimal.Parse(Console.ReadLine() ?? "0");

        Console.Write("  Dung tích xy-lanh (cc, vd: 150): ");
        int dungTich = int.Parse(Console.ReadLine() ?? "0");

        var xemay = new XeMay(maPT, tenHang, namSX, giaGoc, dungTich);
        ql.AddPhuongTien(xemay);
        Console.WriteLine($"\n  ✅ Đã thêm: {xemay.GetInfo()}");
        Console.WriteLine($"  ➤ Giá lăn bánh: {xemay.TinhGiaLanBanh():N0} VNĐ");
    }
    catch (FormatException)
    {
        Console.WriteLine("  ❌ Lỗi: Sai định dạng số, vui lòng nhập lại.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"  ❌ Lỗi validation: {ex.Message}");
    }
}

// ══════════════════════════════════════════════════════
//  HÀM TÌM MAX GIÁ LĂN BÁNH
// ══════════════════════════════════════════════════════
static void TimMaxGiaLanBanh(QuanLyPhuongTien.QuanLyPhuongTien ql)
{
    var maxPT = ql.FindMaxGiaLanBanh();
    if (maxPT == null)
    {
        Console.WriteLine("\n  Danh sách trống, chưa có phương tiện nào.");
        return;
    }
    Console.WriteLine("\n  ➤ Phương tiện có giá lăn bánh cao nhất:");
    Console.WriteLine($"    {maxPT.GetInfo()}");
    Console.WriteLine($"    Giá lăn bánh: {maxPT.TinhGiaLanBanh():N0} VNĐ");
}

// ══════════════════════════════════════════════════════
//  HÀM TÌM KIẾM THEO TÊN
// ══════════════════════════════════════════════════════
static void TimKiemTheoTen(QuanLyPhuongTien.QuanLyPhuongTien ql)
{
    Console.Write("\n  Nhập tên hãng cần tìm: ");
    string keyword = Console.ReadLine() ?? "";
    var ketQua = ql.SearchByName(keyword);

    if (ketQua.Count == 0)
    {
        Console.WriteLine("  Không tìm thấy phương tiện nào.");
        return;
    }
    Console.WriteLine($"\n  Tìm thấy {ketQua.Count} kết quả:");
    foreach (var pt in ketQua)
    {
        Console.WriteLine($"  → {pt.GetInfo()}");
        Console.WriteLine($"    Giá lăn bánh: {pt.TinhGiaLanBanh():N0} VNĐ");
    }
}
