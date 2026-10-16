namespace SupermarketMDI
{
    public class SanPham
    {
        private static int _soThuTu = 1;

        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string LoaiSanPham { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuongTon { get; set; }
        public string DuongDanAnh { get; set; }

        public SanPham()
        {
            MaSanPham = $"SP{_soThuTu:D4}";
            _soThuTu++;
            DuongDanAnh = string.Empty;
        }

        public SanPham(string ma, string ten, string loai, decimal donGia, int soLuong, string duongDanAnh = "")
        {
            MaSanPham = ma; TenSanPham = ten; LoaiSanPham = loai;
            DonGia = donGia; SoLuongTon = soLuong; DuongDanAnh = duongDanAnh ?? string.Empty;
        }

        public static void ResetCounter(int value = 1) => _soThuTu = value;

        public string ToCsvLine() =>
            $"\"{MaSanPham}\",\"{TenSanPham}\",\"{LoaiSanPham}\",{DonGia},{SoLuongTon},\"{DuongDanAnh}\"";

        public static SanPham? FromCsvLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;
            try
            {
                var parts = ParseCsvLine(line);
                if (parts.Length < 6) return null;
                return new SanPham(parts[0].Trim('"'), parts[1].Trim('"'), parts[2].Trim('"'),
                    decimal.Parse(parts[3], System.Globalization.CultureInfo.InvariantCulture),
                    int.Parse(parts[4]), parts[5].Trim('"'));
            }
            catch { return null; }
        }

        private static string[] ParseCsvLine(string line)
        {
            var result = new System.Collections.Generic.List<string>();
            bool inQ = false;
            var cur = new System.Text.StringBuilder();
            foreach (char c in line)
            {
                if (c == '"') { inQ = !inQ; cur.Append(c); }
                else if (c == ',' && !inQ) { result.Add(cur.ToString()); cur.Clear(); }
                else cur.Append(c);
            }
            result.Add(cur.ToString());
            return result.ToArray();
        }
    }
}
