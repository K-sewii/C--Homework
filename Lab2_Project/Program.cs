using System;
using Phan1CoBan;
using Phan2NangCao;
using Phan3KeThua;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Hiển thị tiếng Việt

        // ================================================================
        // ======================= PHẦN 1 =================================
        // ================================================================
        Console.WriteLine("========== PHẦN 1 ==========");

        // --- Bài 1.1: Sinh viên ---
        Console.WriteLine("\n=== BÀI 1.1: TÍNH TUỔI SINH VIÊN ===");
        SinhVien sv1 = new SinhVien("Nguyễn Văn A", 2003);
        SinhVien sv2 = new SinhVien("Trần Thị B", 2005);
        sv1.XuatThongTin();
        sv2.XuatThongTin();

        // --- Bài 1.2: Point ---
        Console.WriteLine("\n=== BÀI 1.2: POINT ===");
        Point p1 = new Point(1, 2);
        Point p2 = new Point(4, 6);
        Console.WriteLine($"Khoảng cách tĩnh: {Point.TinhKhoangCach(p1, p2)}");
        Console.WriteLine($"Trung điểm: {Point.TimTrungDiem(p1, p2)}");

        // --- Bài 1.3: Person ---
        Console.WriteLine("\n=== BÀI 1.3: PERSON ===");
        // (Bỏ phần Input() để không phải nhập tay — dùng constructor thay thế)
        Person per2 = new Person(2, "Lê Văn C", 1990);
        Console.WriteLine("Person tạo bằng constructor có tham số:");
        per2.Output();
        Console.WriteLine($"Còn sống? {per2.IsLiving()}");

        Person per3 = new Person(per2); // Copy constructor
        Console.WriteLine("\nPerson sao chép từ per2 (Copy Constructor):");
        per3.Output();

        Person per4 = new Person(4, "Người Đã Mất", 0);
        Console.WriteLine("\nPerson có yob = 0:");
        per4.Output();
        Console.WriteLine($"Còn sống? {per4.IsLiving()}");

        // --- Bài 1.4: Phân số ---
        Console.WriteLine("\n=== BÀI 1.4: PHÂN SỐ ===");
        PhanSo ps1 = new PhanSo(1, 2);
        PhanSo ps2 = new PhanSo(3, 4);
        Console.WriteLine($"{ps1} + {ps2} = {ps1 + ps2}");
        Console.WriteLine($"{ps1} - {ps2} = {ps1 - ps2}");
        Console.WriteLine($"{ps1} * {ps2} = {ps1 * ps2}");
        Console.WriteLine($"{ps1} / {ps2} = {ps1 / ps2}");

        // --- Bài 1.5: Đơn thức ---
        Console.WriteLine("\n=== BÀI 1.5: ĐƠN THỨC ===");
        DonThuc dt = new DonThuc(3, 2); // 3x^2
        Console.WriteLine($"Đơn thức: {dt}");
        Console.WriteLine($"Giá trị tại x=2: {dt.TinhGiaTri(2)}");
        Console.WriteLine($"Đạo hàm: {dt.DaoHam()}");

        // ================================================================
        // ======================= PHẦN 2 =================================
        // ================================================================
        Console.WriteLine("\n\n========== PHẦN 2 ==========");

        // --- Bài 2.1: ArrayPoint ---
        Console.WriteLine("\n=== BÀI 2.1: ARRAYPOINT ===");
        ArrayPoint arrP = new ArrayPoint();
        arrP.Add(new Point(1, 1));
        arrP.Add(new Point(2, 3));
        arrP.Add(new Point(-4, 5));
        Console.WriteLine($"Số điểm: {arrP.Count}");
        for (int i = 0; i < arrP.Count; i++)
        {
            Console.Write($"Phần tử [{i}]: ");
            arrP[i].Xuat();
            Console.WriteLine();
        }

        // --- Bài 2.2: PersonList ---
        Console.WriteLine("\n=== BÀI 2.2: PERSONLIST ===");
        PersonList pl = new PersonList();
        // Thêm trực tiếp để tránh Input() phải nhập tay
        pl.AddPerson(new Person(1, "Nguyễn Văn A", 1995));
        pl.AddPerson(new Person(2, "Trần Thị B", 0));       // đã mất
        pl.AddPerson(new Person(3, "Lê Văn C", 2000));
        pl.AddPerson(new Person(4, "Phạm Thị D", 0));       // đã mất

        Console.WriteLine("Danh sách đầy đủ:");
        pl.Output();

        Console.WriteLine("\nDanh sách người còn sống:");
        PersonList plLiving = pl.LivingPeople();
        plLiving.Output();

        Console.WriteLine("\nDanh sách sao chép (Copy Constructor):");
        PersonList plCopy = new PersonList(pl);
        plCopy.Output();

        // --- Bài 2.3: Mảng 1 chiều ---
        Console.WriteLine("\n=== BÀI 2.3: MẢNG 1 CHIỀU ===");
        // Dùng constructor truyền mảng có sẵn (khỏi phải nhập tay)
        Mang1Chieu m1 = new Mang1Chieu(new int[] { 4, 7, 10, 15, 22, 33, 8 });
        m1.Xuat();
        m1.TimSoChan();

        // --- Bài 2.4: Mảng 2 chiều ---
        Console.WriteLine("\n=== BÀI 2.4: MẢNG 2 CHIỀU ===");
        // Tạo ma trận 3x3 và set giá trị trực tiếp qua indexer
        Mang2Chieu m2 = new Mang2Chieu(3, 3);
        int[,] data = {
            { 2, 4, 6 },
            { 7, 11, 13 },
            { 15, 8, 9 }
        };
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                m2[i, j] = data[i, j];

        Console.WriteLine("Ma trận:");
        m2.Xuat();
        m2.TimNguyenTo();

        // --- Bài 2.3 (lặp): Đa thức ---
        Console.WriteLine("\n=== BÀI 2.3 (LẶP): ĐA THỨC ===");
        // Đa thức bậc 3: P(x) = 1 + 2x + 3x^2 + 4x^3
        DaThuc daThuc = new DaThuc(3);
        daThuc[0] = 1;
        daThuc[1] = 2;
        daThuc[2] = 3;
        daThuc[3] = 4;

        Console.Write("Đa thức: ");
        daThuc.Xuat();
        Console.WriteLine($"Giá trị tại x=2: {daThuc.TinhGiaTri(2)}");

        // --- Bài 2.4 (lặp): Dãy phân số ---
        Console.WriteLine("\n=== BÀI 2.4 (LẶP): DÃY PHÂN SỐ ===");
        DayPhanSo dayPS = new DayPhanSo(3);
        Console.WriteLine("Nhập 3 phân số từ bàn phím:");  // <-- NHẬP TAY
        dayPS.Nhap();
        PhanSo tong = dayPS.TinhTong();
        Console.WriteLine($"Tổng dãy phân số = {tong}");

        // --- Bài 2.5: Nhân viên cơ bản ---
        Console.WriteLine("\n=== BÀI 2.5: LƯƠNG NHÂN VIÊN CƠ BẢN ===");
        NhanVienCoBan nv1 = new NhanVienCoBan
        {
            HoTen = "Nguyễn Văn A",
            LuongCoBan = 8000000,
            SoNgayVang = 2
        };
        NhanVienCoBan nv2 = new NhanVienCoBan
        {
            HoTen = "Trần Thị B",
            LuongCoBan = 10000000,
            SoNgayVang = 0
        };
        Console.WriteLine($"{nv1.HoTen} - Vắng {nv1.SoNgayVang} ngày - Lương: {nv1.TinhLuong():N0} VNĐ");
        Console.WriteLine($"{nv2.HoTen} - Vắng {nv2.SoNgayVang} ngày - Lương: {nv2.TinhLuong():N0} VNĐ");

        // ================================================================
        // ======================= PHẦN 3 =================================
        // ================================================================
        Console.WriteLine("\n\n========== PHẦN 3 ==========");

        // --- Bài 3.1 & 3.2: Sắp xếp ---
        Console.WriteLine("\n=== BÀI 3.1 & 3.2: SẮP XẾP SINH VIÊN ===");
        SinhVienSapXep[] arrSV = new SinhVienSapXep[]
        {
            new SinhVienSapXep("An", 8.5),
            new SinhVienSapXep("Binh", 7.0),
            new SinhVienSapXep("Cuong", 9.0)
        };
        Array.Sort(arrSV); // Sử dụng IComparable (theo điểm tăng dần)
        Console.WriteLine("Sắp xếp theo điểm tăng dần:");
        foreach (var sv in arrSV) Console.WriteLine("  " + sv);

        Array.Sort(arrSV, new SinhVienComparerByName());
        Console.WriteLine("Sắp xếp theo tên (IComparer):");
        foreach (var sv in arrSV) Console.WriteLine("  " + sv);

        // --- Bài 3.4: Console Menu ---
        Console.WriteLine("\n=== BÀI 3.4: CONSOLE MENU ===");
        ConsoleMenu menu = new PTBac2Console();
        Console.WriteLine("(Bỏ comment dòng menu.Run() trong code để chạy thử menu tương tác)");
        menu.Run();

        // --- Bài 3.5: Lương nhân viên (kế thừa) ---
        Console.WriteLine("\n=== BÀI 3.5: LƯƠNG NHÂN VIÊN (KẾ THỪA) ===");
        NhanVien nvKD = new NhanVienKinhDoanh("KD001", "Nguyễn Văn A", 5000000, 12);
        NhanVien nvSX = new NhanVienSanXuat("SX001", "Trần Thị B", 3500);
        Console.WriteLine($"{nvKD.HoTen} ({nvKD.MaNV}) - Lương: {nvKD.TinhLuong():N0} VNĐ");
        Console.WriteLine($"{nvSX.HoTen} ({nvSX.MaNV}) - Lương: {nvSX.TinhLuong():N0} VNĐ");

        // --- Bài 3.6: Điểm thí sinh ---
        Console.WriteLine("\n=== BÀI 3.6: TÍNH ĐIỂM THÍ SINH ===");
        ThiSinh ts1 = new ThiSinh
        {
            SBD = "TS001", HoTen = "Nguyễn Văn A",
            DiemToan = 8, DiemLy = 7, DiemHoa = 9
        };
        ThiSinh ts2 = new ThiSinhChuyen
        {
            SBD = "TS002", HoTen = "Trần Thị B",
            DiemToan = 8, DiemLy = 7, DiemHoa = 9,
            DiemTiengAnh = 9
        };
        ThiSinh ts3 = new ThiSinhSieuCup
        {
            SBD = "TS003", HoTen = "Lê Văn C",
            DiemToan = 9, DiemLy = 9, DiemHoa = 8,
            DiemCSDL = 10
        };
        Console.WriteLine($"[{ts1.SBD}] {ts1.HoTen} - Tổng điểm: {ts1.TinhTongDiem():F2}");
        Console.WriteLine($"[{ts2.SBD}] {ts2.HoTen} (Chuyên) - Tổng điểm: {ts2.TinhTongDiem():F2}");
        Console.WriteLine($"[{ts3.SBD}] {ts3.HoTen} (Siêu cúp) - Tổng điểm: {ts3.TinhTongDiem():F2}");

        // ================================================================
        Console.WriteLine("\n--- Hoàn tất ---");
        Console.ReadKey();
    }
}