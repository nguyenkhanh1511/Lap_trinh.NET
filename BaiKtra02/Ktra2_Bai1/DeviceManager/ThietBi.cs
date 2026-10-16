namespace DeviceManager
{
    public class ThietBi
    {
        private static int _soThuTu = 1;

        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
        public string LoaiThietBi { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuongTon { get; set; }

        public ThietBi()
        {
            MaThietBi = $"TB{_soThuTu:D4}";
            _soThuTu++;
        }

        public ThietBi(string ma, string ten, string loai, decimal donGia, int soLuong)
        {
            MaThietBi = ma;
            TenThietBi = ten;
            LoaiThietBi = loai;
            DonGia = donGia;
            SoLuongTon = soLuong;
        }

        public static void ResetCounter(int value = 1)
        {
            _soThuTu = value;
        }
    }
}
