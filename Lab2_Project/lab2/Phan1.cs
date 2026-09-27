using System;
using System.Collections.Generic;
using System.Linq;

namespace Phan1CoBan
{
    // ================= BÀI 1.1: TÍNH TUỔI SINH VIÊN =================
    public class SinhVien
    {
        private string hoTen;
        private int namSinh;

        public SinhVien(string hoTen, int namSinh)
        {
            this.hoTen = hoTen;
            this.namSinh = namSinh;
        }

        // Tính tuổi dựa trên năm hiện tại
        public int TinhTuoi()
        {
            return DateTime.Now.Year - namSinh;
        }

        public void XuatThongTin()
        {
            Console.WriteLine($"Họ tên: {hoTen}, Năm sinh: {namSinh}, Tuổi: {TinhTuoi()}");
        }
    }

    // ================= BÀI 1.2: LỚP POINT =================
    public class Point
    {
        // Fields
        private double x;
        private double y;

        // Properties
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        // Default Constructor: Khởi tạo x, y = 0
        public Point()
        {
            x = 0;
            y = 0;
        }

        // Constructor có tham số
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Phương thức nhập
        public void Nhap()
        {
            Console.Write("Nhập x: "); x = double.Parse(Console.ReadLine());
            Console.Write("Nhập y: "); y = double.Parse(Console.ReadLine());
        }

        // Phương thức xuất
        public void Xuat()
        {
            Console.Write($"({x}, {y})");
        }

        // Override ToString()
        public override string ToString()
        {
            return $"({x}, {y})";
        }

        // Overload toán tử một ngôi (-)
        public static Point operator -(Point p)
        {
            return new Point(-p.x, -p.y);
        }

        // Overload toán tử hai ngôi (+, -)
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.x + p2.x, p1.y + p2.y);
        }
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.x - p2.x, p1.y - p2.y);
        }

        // (a) Tính khoảng cách - Phương thức thành viên
        public double TinhKhoangCach(Point p)
        {
            return Math.Sqrt(Math.Pow(this.x - p.x, 2) + Math.Pow(this.y - p.y, 2));
        }

        // (a) Tính khoảng cách - Phương thức tĩnh
        public static double TinhKhoangCach(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2));
        }

        // (b) Trung điểm - Phương thức thành viên
        public Point TimTrungDiem(Point p)
        {
            return new Point((this.x + p.x) / 2, (this.y + p.y) / 2);
        }

        // (b) Trung điểm - Phương thức tĩnh
        public static Point TimTrungDiem(Point p1, Point p2)
        {
            return new Point((p1.x + p2.x) / 2, (p1.y + p2.y) / 2);
        }
    }

    // ================= BÀI 1.3: LỚP PERSON =================
    public class Person
    {
        private int id;
        private string name;
        private int yob;

        // Default Constructor
        public Person() { id = 0; name = ""; yob = 0; }

        // Copy Constructor
        public Person(Person other)
        {
            this.id = other.id;
            this.name = other.name;
            this.yob = other.yob;
        }

        public Person(int id, string name, int yob)
        {
            this.id = id; this.name = name; this.yob = yob;
        }

        public void Input()
        {
            Console.Write("Nhập ID: "); id = int.Parse(Console.ReadLine());
            Console.Write("Nhập tên: "); name = Console.ReadLine();
            Console.Write("Nhập năm sinh: "); yob = int.Parse(Console.ReadLine());
        }

        public void Output()
        {
            Console.WriteLine($"ID: {id}, Tên: {name}, Năm sinh: {yob}");
        }

        // Kiểm tra còn sống (yob != 0)
        public bool IsLiving()
        {
            return yob != 0;
        }
    }

    // ================= BÀI 1.4: LỚP PHÂN SỐ =================
    public class PhanSo
    {
        private int tuSo;
        private int mauSo;

        public int TuSo { get => tuSo; set => tuSo = value; }
        public int MauSo { get => mauSo; set => mauSo = value; }

        // Constructor mặc định
        public PhanSo() { tuSo = 0; mauSo = 1; }

        // Constructor sao chép
        public PhanSo(PhanSo other) { tuSo = other.tuSo; mauSo = other.mauSo; }

        // Constructor có tham số
        public PhanSo(int tuSo, int mauSo)
        {
            this.tuSo = tuSo;
            this.mauSo = mauSo == 0 ? 1 : mauSo; // Tránh mẫu số bằng 0
        }

        // Hàm tìm Ước Chung Lớn Nhất để rút gọn
        private int UCLN(int a, int b)
        {
            a = Math.Abs(a); b = Math.Abs(b);
            while (b != 0) { int temp = b; b = a % b; a = temp; }
            return a;
        }

        // Rút gọn phân số
        public void RutGon()
        {
            int ucln = UCLN(tuSo, mauSo);
            tuSo /= ucln;
            mauSo /= ucln;
            if (mauSo < 0) { tuSo = -tuSo; mauSo = -mauSo; } // Đưa dấu âm lên tử
        }

        public override string ToString()
        {
            RutGon();
            return mauSo == 1 ? $"{tuSo}" : $"{tuSo}/{mauSo}";
        }

        // Overload toán tử một ngôi (-)
        public static PhanSo operator -(PhanSo p)
        {
            return new PhanSo(-p.tuSo, p.mauSo);
        }

        // Overload toán tử hai ngôi (+, -, *, /)
        public static PhanSo operator +(PhanSo a, PhanSo b)
            => new PhanSo(a.tuSo * b.mauSo + b.tuSo * a.mauSo, a.mauSo * b.mauSo);

        public static PhanSo operator -(PhanSo a, PhanSo b)
            => new PhanSo(a.tuSo * b.mauSo - b.tuSo * a.mauSo, a.mauSo * b.mauSo);

        public static PhanSo operator *(PhanSo a, PhanSo b)
            => new PhanSo(a.tuSo * b.tuSo, a.mauSo * b.mauSo);

        public static PhanSo operator /(PhanSo a, PhanSo b)
            => new PhanSo(a.tuSo * b.mauSo, a.mauSo * b.tuSo);
    }

    // ================= BÀI 1.5: LỚP ĐƠN THỨC =================
    public class DonThuc
    {
        private double a; // Hệ số
        private int n;    // Số mũ

        public DonThuc(double a, int n)
        {
            this.a = a;
            this.n = n;
        }

        // (a) Tính giá trị đơn thức tại x
        public double TinhGiaTri(double x)
        {
            return a * Math.Pow(x, n);
        }

        // (b) Đạo hàm của đơn thức: Q(x) = a * n * x^(n-1)
        public DonThuc DaoHam()
        {
            if (n == 0) return new DonThuc(0, 0); // Đạo hàm của hằng số là 0
            return new DonThuc(a * n, n - 1);
        }

        public override string ToString()
        {
            return $"{a}x^{n}";
        }
    }
}