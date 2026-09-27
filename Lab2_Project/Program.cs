using Phan1CoBan;
using Phan3KeThua;
using Phan2NangCao;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Hiển thị tiếng Việt

        // --- Test Bài 1.2: Point ---
        Console.WriteLine("=== BÀI 1.2: POINT ===");
        Point p1 = new Point(1, 2);
        Point p2 = new Point(4, 6);
        Console.WriteLine($"Khoảng cách tĩnh: {Point.TinhKhoangCach(p1, p2)}");
        Console.WriteLine($"Trung điểm: {Point.TimTrungDiem(p1, p2)}");

        // --- Test Bài 1.4: Phân số ---
        Console.WriteLine("\n=== BÀI 1.4: PHÂN SỐ ===");
        PhanSo ps1 = new PhanSo(1, 2);
        PhanSo ps2 = new PhanSo(3, 4);
        Console.WriteLine($"{ps1} + {ps2} = {ps1 + ps2}");

        // --- Test Bài 1.5: Đơn thức ---
        Console.WriteLine("\n=== BÀI 1.5: ĐƠN THỨC ===");
        DonThuc dt = new DonThuc(3, 2); // 3x^2
        Console.WriteLine($"Giá trị tại x=2: {dt.TinhGiaTri(2)}");
        Console.WriteLine($"Đạo hàm: {dt.DaoHam()}");

        // --- Test Bài 3.1: Sắp xếp ---
        Console.WriteLine("\n=== BÀI 3.1: SẮP XẾP SINH VIÊN ===");
        SinhVienSapXep[] arrSV = new SinhVienSapXep[]
        {
            new SinhVienSapXep("An", 8.5),
            new SinhVienSapXep("Binh", 7.0),
            new SinhVienSapXep("Cuong", 9.0)
        };
        Array.Sort(arrSV); // Sử dụng IComparable
        foreach (var sv in arrSV) Console.WriteLine(sv);

        Console.WriteLine("\n--- Sắp xếp theo tên (Interface) ---");
        Array.Sort(arrSV, new SinhVienComparerByName());
        foreach (var sv in arrSV) Console.WriteLine(sv);

        // --- Test Bài 3.4: Menu ---
        Console.WriteLine("\n=== BÀI 3.4: CONSOLE MENU ===");
        ConsoleMenu menu = new PTBac2Console();
        // menu.Run(); // Bỏ comment để chạy thử menu tương tác

        // --- Test Bài 3.5: Tính lương nhân viên ---

         Console.WriteLine("\n=== BÀI 3.5: TÍNH LƯƠNG NHÂN VIÊN ===");


        // Nhân viên kinh doanh: lương CB 5tr + 12 hợp đồng * 500k = 11tr
        NhanVien nvKD = new NhanVienKinhDoanh("KD001", "Nguyễn Văn A", 5000000, 12);

        // Nhân viên sản xuất: 3500 SP * 1000 = 3.5tr, > 3000 nên +5% = 3.675tr
        NhanVien nvSX = new NhanVienSanXuat("SX001", "Trần Thị B", 3500);

        // Xuất kết quả (đa hình: gọi TinhLuong() của từng lớp con)
        Console.WriteLine($"{nvKD.HoTen} ({nvKD.MaNV}) - Lương: {nvKD.TinhLuong():N0} VNĐ");
        Console.WriteLine($"{nvSX.HoTen} ({nvSX.MaNV}) - Lương: {nvSX.TinhLuong():N0} VNĐ");
    
        
        // --- Test Bài 3.6: Tính điểm thí sinh ---
        Console.WriteLine("\n=== BÀI 3.6: TÍNH ĐIỂM THÍ SINH ===");

        // Thí sinh thường: 8 + 7 + 9 = 24  (dùng object initializer vì không có constructor)
        ThiSinh ts1 = new ThiSinh
        {
            SBD = "TS001", HoTen = "Nguyễn Văn A",
            DiemToan = 8, DiemLy = 7, DiemHoa = 9
        };

        // Thí sinh chuyên: 24 + thưởng TA (9 điểm => +2) = 26
        ThiSinh ts2 = new ThiSinhChuyen
        {
            SBD = "TS002", HoTen = "Trần Thị B",
            DiemToan = 8, DiemLy = 7, DiemHoa = 9,
            DiemTiengAnh = 9
        };

        // Thí sinh siêu cúp: 9 + 9 + 8 + CSDL 10 = 36
        ThiSinh ts3 = new ThiSinhSieuCup
        {
            SBD = "TS003", HoTen = "Lê Văn C",
            DiemToan = 9, DiemLy = 9, DiemHoa = 8,
            DiemCSDL = 10
        };

        // Xuất kết quả (đa hình: gọi TinhTongDiem() của từng lớp con)
        Console.WriteLine($"[{ts1.SBD}] {ts1.HoTen} - Tổng điểm: {ts1.TinhTongDiem():F2}");
        Console.WriteLine($"[{ts2.SBD}] {ts2.HoTen} (Chuyên) - Tổng điểm: {ts2.TinhTongDiem():F2}");
        Console.WriteLine($"[{ts3.SBD}] {ts3.HoTen} (Siêu cúp) - Tổng điểm: {ts3.TinhTongDiem():F2}");

        // ================================================================

        Console.WriteLine("\n--- Hoàn tất ---");
        
        Console.ReadKey();

    }

}