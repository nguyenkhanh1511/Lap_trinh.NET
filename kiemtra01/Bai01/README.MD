# Bài 1 – Phần Lý Thuyết & Câu Hỏi Ngắn

**Sinh viên:** Nguyễn Duy Khánh – **Mã SV:** 24810310256

---

## Câu 1: Value Types vs Reference Types trong C#

| Tiêu chí | Value Types (Kiểu giá trị) | Reference Types (Kiểu tham chiếu) |
|---|---|---|
| **Vùng nhớ lưu trữ** | Stack | Heap (biến lưu địa chỉ trên Stack) |
| **Sao chép dữ liệu** | Copy toàn bộ giá trị (độc lập nhau) | Copy địa chỉ (cùng trỏ đến 1 object) |
| **Quản lý bộ nhớ** | Tự giải phóng khi ra khỏi scope | Garbage Collector thu hồi |
| **Ví dụ** | `int`, `double`, `bool`, `struct`, `enum` | `class`, `string`, `array`, `interface` |

**Cơ chế hoạt động:**

- **Stack** lưu trữ các Value Types theo cơ chế LIFO. Khi gán `y = x`, toàn bộ giá trị được **sao chép** — hai biến hoàn toàn độc lập.
- **Heap** lưu trữ object thực sự của Reference Types. Biến chỉ chứa **địa chỉ tham chiếu** đến vùng Heap. Gán `arr2 = arr1` thì cả hai cùng trỏ đến 1 object.

```csharp
// Value Type – Stack
int x = 10;
int y = x;   // bản sao độc lập
y = 20;      // x vẫn = 10

// Reference Type – Heap
int[] arr1 = { 1, 2, 3 };
int[] arr2 = arr1;   // cùng địa chỉ
arr2[0] = 99;        // arr1[0] cũng = 99
```

---

## Câu 2: Init-only Properties (`init`) trong C# 9/10

| Tiêu chí | `set` thông thường | `init` (C# 9+) |
|---|---|---|
| **Thời điểm gán** | Bất kỳ lúc nào | Chỉ trong object initializer hoặc constructor |
| **Sau khởi tạo** | Có thể thay đổi tự do | Không thể thay đổi (read-only sau init) |
| **Mục đích** | Property có thể mutate | Tạo object immutable, cú pháp linh hoạt |

```csharp
public class SanPham
{
    public string MaSP  { get; init; }
    public string TenSP { get; init; }
    public decimal Gia  { get; set; }
}

var sp = new SanPham { MaSP = "SP001", TenSP = "Laptop" }; // ✅
sp.MaSP = "SP002";   // ❌ CS8852 - không thể gán lại
sp.Gia  = 25000000;  // ✅ set bình thường
```

**Trường hợp dùng thực tế:** DTO/Record bất biến truyền giữa các tầng API, cấu hình appsettings chỉ đọc một lần.

---

## Câu 3: `virtual` ở lớp cha và `override` ở lớp con – Tính Đa hình

| Tiêu chí | `virtual` (lớp cha) | `override` (lớp con) |
|---|---|---|
| **Vai trò** | Khai báo phương thức có thể bị ghi đè | Ghi đè lại phương thức virtual từ cha |
| **Gọi qua biến cha** | Gọi phiên bản của cha | Gọi phiên bản của **con** (late binding) |
| **`base.Method()`** | — | Có thể gọi lại logic cha nếu cần |

```csharp
public class PhuongTien
{
    public virtual string GetInfo() => "Phương tiện";
}
public class OTo : PhuongTien
{
    public override string GetInfo() => base.GetInfo() + " – Ô tô";
}

PhuongTien pt = new OTo();
Console.WriteLine(pt.GetInfo()); // "Phương tiện – Ô tô"
```

C# dùng **Virtual Method Table (vtable)** — runtime tra vtable để gọi đúng phiên bản override của object thực tế.

---

## Câu 4: Tại sao `static` không thể truy xuất qua Object Instance?

`static` thuộc về **lớp (Type)** chứ không thuộc về **thể hiện (Instance)**.

- Thành phần `static` được cấp phát bộ nhớ **1 lần duy nhất** trong vùng **Static/Method Area** khi class được nạp vào CLR.
- Mỗi `new` tạo vùng Heap riêng cho instance fields — không có bản sao `static` nào trong đó.
- Trình biên dịch C# **từ chối** truy xuất `static` qua instance để tránh hiểu nhầm mỗi object có bản sao riêng.

```csharp
public class BoDem
{
    public static int TongSoXe = 0;  // dùng chung toàn app
    public string TenXe;

    public BoDem(string ten) { TenXe = ten; TongSoXe++; }
}

Console.WriteLine(BoDem.TongSoXe); // ✅ truy cập qua tên lớp
// Console.WriteLine(x1.TongSoXe); // ❌ Compiler error
```
