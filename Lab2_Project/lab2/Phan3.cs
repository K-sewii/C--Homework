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
        // Delegate và Event
        public delegate void MenuHandler();
        public event MenuHandler Choose;

        protected abstract void ShowMenu();

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                ShowMenu();
                Console.Write("Thực hiện: ");
                string choice = Console.ReadLine();

                if (choice == "0") break;
                
                // Kích hoạt sự kiện
                Choose?.Invoke(); 
            }
        }
    }

    // Ứng dụng cho bài toán PTB2
    public class PTBac2Console : ConsoleMenu
    {
        protected override void ShowMenu()
        {
            Console.WriteLine("--- GIẢI PHƯƠNG TRÌNH BẬC 2 ---");
            Console.WriteLine("1. Nhập và giải PTB2");
            Console.WriteLine("0. Thoát");
        }

        public PTBac2Console()
        {
            // Đăng ký sự kiện
            this.Choose += XuLyChucNang;
        }

        private void XuLyChucNang()
        {
            Console.Write("Nhập a, b, c: ");
            // Giả sử nhập liệu đơn giản
            double a = double.Parse(Console.ReadLine());
            // ... (Logic giải PTB2)
            Console.WriteLine("Đang giải PTB2...");
            Console.ReadKey();
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