using System;
using System.Collections.Generic;

namespace Phan3KeThua
{
    // ================= BÀI 3.1 & 3.2 & 3.3: SẮP XẾP MẢNG =================
    // Lớp SinhVien implements IComparable để dùng Array.Sort()
    public class SinhVienSapXep : IComparable<SinhVienSapXep>
    {
        public string HoTen { get; set; }
        public double Diem { get; set; }

        public SinhVienSapXep(string hoTen, double diem)
        {
            HoTen = hoTen; Diem = diem;
        }

        // Bài 3.1: Sắp xếp mặc định theo điểm tăng dần
        public int CompareTo(SinhVienSapXep other)
        {
            return this.Diem.CompareTo(other.Diem);
        }

        public override string ToString() => $"{HoTen} - {Diem}";
    }

    // Bài 3.2: Sắp xếp tổng quát bằng Interface IComparer
    public class SinhVienComparerByName : IComparer<SinhVienSapXep>
    {
        public int Compare(SinhVienSapXep x, SinhVienSapXep y)
        {
            return string.Compare(x.HoTen, y.HoTen, StringComparison.Ordinal);
        }
    }

    // ================= BÀI 3.4: LỚP CONSOLEMENU TỔNG QUÁT =================
    public abstract class ConsoleMenu
    {
        // Delegate và Event (không tham số, theo đúng gợi ý đề bài)
        public delegate void MenuHandler();
        public event MenuHandler Choose;

        // Lưu lựa chọn hiện tại để handler biết user vừa chọn gì
        protected int CurrentChoice { get; private set; }

        // Lớp con override để cung cấp menu
        protected abstract void ShowMenu();

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                ShowMenu();
                Console.Write("Thực hiện: ");
                string input = Console.ReadLine();

                // Thoát chương trình
                if (input == "0") break;

                // Kiểm tra lựa chọn hợp lệ (1..9)
                int n;
                if (int.TryParse(input, out n) && n >= 1)
                {
                    CurrentChoice = n;
                    Console.WriteLine($"Bạn thực hiện chức năng {n}");

                    // Kích hoạt sự kiện → gọi handler đã đăng ký
                    Choose?.Invoke();
                }
                else
                {
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                }

                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                Console.ReadKey();
            }
        }
    }

    // ================= ÁP DỤNG CHO BÀI TOÁN PTB2 =================
    public class PTBac2Console : ConsoleMenu
    {
        protected override void ShowMenu()
        {
            Console.WriteLine("--- GIẢI PHƯƠNG TRÌNH BẬC 2 ---");
            Console.WriteLine("1. Nhập và giải PTB2");
            Console.WriteLine("0. Thoát chương trình");
        }

        public PTBac2Console()
        {
            // Đăng ký sự kiện
            this.Choose += XuLyChucNang;
        }

        // Handler trung tâm: dựa vào CurrentChoice để phân nhánh
        private void XuLyChucNang()
        {
            switch (CurrentChoice)
            {
                case 1:
                    NhapVaGiai();
                    break;
                default:
                    Console.WriteLine($"Chức năng {CurrentChoice} chưa được cài đặt.");
                    break;
            }
        }

        private void NhapVaGiai()
        {
            // Nhập a, b, c trên từng dòng riêng (tránh FormatException)
            Console.Write("Nhập a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Nhập b: ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Nhập c: ");
            double c = double.Parse(Console.ReadLine());

            Console.WriteLine(GiaiPTB2(a, b, c));
        }

        // Hàm giải PTB2 thuần túy, trả về chuỗi kết quả
        private string GiaiPTB2(double a, double b, double c)
        {
            string pt = $"\nPhương trình: {a}x² + {b}x + {c} = 0";

            // Trường hợp a = 0 → PT bậc 1
            if (a == 0)
            {
                if (b == 0)
                    return pt + "\n→ " + (c == 0 ? "Vô số nghiệm." : "Vô nghiệm.");
                return pt + $"\n→ PT bậc 1, nghiệm x = {-c / b}";
            }

            // Tính delta
            double delta = b * b - 4 * a * c;
            string kq = pt + $"\n→ Delta = {delta}\n";

            if (delta < 0)
                kq += "→ Phương trình vô nghiệm (trong ℝ).";
            else if (delta == 0)
                kq += $"→ Nghiệm kép x1 = x2 = {-b / (2 * a)}";
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                kq += $"→ 2 nghiệm phân biệt:\n   x1 = {x1}\n   x2 = {x2}";
            }
            return kq;
        }
    }

    // ================= BÀI 3.5: TÍNH LƯƠNG NHÂN VIÊN (KẾ THỪA) =================
    public abstract class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }

        public NhanVien(string ma, string ten) { MaNV = ma; HoTen = ten; }
        public abstract double TinhLuong();
    }

    public class NhanVienKinhDoanh : NhanVien
    {
        public double MucLuongCoBan { get; set; }
        public int SoHopDong { get; set; }

        public NhanVienKinhDoanh(string ma, string ten, double luongCB, int soHD) : base(ma, ten)
        {
            MucLuongCoBan = luongCB; SoHopDong = soHD;
        }

        public override double TinhLuong()
        {
            return MucLuongCoBan + (SoHopDong * 500000);
        }
    }

    public class NhanVienSanXuat : NhanVien
    {
        public int SoSanPham { get; set; }

        public NhanVienSanXuat(string ma, string ten, int soSP) : base(ma, ten)
        {
            SoSanPham = soSP;
        }

        public override double TinhLuong()
        {
            double luong = SoSanPham * 1000;
            if (SoSanPham > 3000) luong += luong * 0.05; // Thưởng 5%
            return luong;
        }
    }

    // ================= BÀI 3.6: TÍNH ĐIỂM THÍ SINH =================
    public class ThiSinh
    {
        public string SBD { get; set; }
        public string HoTen { get; set; }
        public double DiemToan { get; set; }
        public double DiemLy { get; set; }
        public double DiemHoa { get; set; }

        public virtual double TinhTongDiem()
        {
            return DiemToan + DiemLy + DiemHoa;
        }
    }

    public class ThiSinhChuyen : ThiSinh
    {
        public double DiemTiengAnh { get; set; }

        public override double TinhTongDiem()
        {
            double tong = base.TinhTongDiem();
            // Điểm thưởng tiếng Anh
            if (DiemTiengAnh >= 7 && DiemTiengAnh <= 8) tong += 1;
            else if (DiemTiengAnh >= 9 && DiemTiengAnh <= 10) tong += 2;
            return tong;
        }
    }

    public class ThiSinhSieuCup : ThiSinh
    {
        public double DiemCSDL { get; set; }

        public override double TinhTongDiem()
        {
            // Tổng điểm 4 bài
            return base.TinhTongDiem() + DiemCSDL;
        }
    }
}