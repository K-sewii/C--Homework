using System;
using System.Collections.Generic;

namespace Phan2NangCao
{
    // ================= BÀI 2.1: LỚP ARRAYPOINT =================
    public class ArrayPoint
    {
        private List<Phan1CoBan.Point> arr;

        public ArrayPoint()
        {
            arr = new List<Phan1CoBan.Point>();
        }

        // Indexer để truy cập Point thứ i
        public Phan1CoBan.Point this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }

        public void Add(Phan1CoBan.Point p) => arr.Add(p);
        public int Count => arr.Count;
    }

    // ================= BÀI 2.2: LỚP PERSONLIST =================
    public class PersonList
    {
        private List<Phan1CoBan.Person> list;

        public PersonList() { list = new List<Phan1CoBan.Person>(); }

        // Copy Constructor
        public PersonList(PersonList other)
        {
            list = new List<Phan1CoBan.Person>();
            foreach (var p in other.list)
            {
                list.Add(new Phan1CoBan.Person(p)); // Sử dụng copy constructor của Person
            }
        }

        public void Input()
        {
            Console.Write("Nhập số lượng người: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhập người thứ {i + 1}:");
                Phan1CoBan.Person p = new Phan1CoBan.Person();
                p.Input();
                list.Add(p);
            }
        }

        public void Output()
        {
            foreach (var p in list) p.Output();
        }

        public void AddPerson(Phan1CoBan.Person x) => list.Add(x);

        // Trả về danh sách những người còn sống
        public PersonList LivingPeople()
        {
            PersonList result = new PersonList();
            foreach (var p in list)
            {
                if (p.IsLiving()) result.AddPerson(p);
            }
            return result;
        }
    }

    // ================= BÀI 2.3: LỚP CHỨA MẢNG 1 CHIỀU =================
    public class Mang1Chieu
    {
        private int[] arr;

        public Mang1Chieu(int n) { arr = new int[n]; }
        public Mang1Chieu(int[] a) { arr = a; }

        // Indexer
        public int this[int i]
        {
            get => arr[i];
            set => arr[i] = value;
        }

        public void Nhap()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Nhập phần tử [{i}]: ");
                arr[i] = int.Parse(Console.ReadLine());
            }
        }

        public void Xuat()
        {
            Console.WriteLine("Mảng: " + string.Join(", ", arr));
        }

        // Tìm các số chẵn
        public void TimSoChan()
        {
            Console.Write("Các số chẵn: ");
            foreach (int x in arr)
            {
                if (x % 2 == 0) Console.Write(x + " ");
            }
            Console.WriteLine();
        }
    }

    // ================= BÀI 2.4: LỚP CHỨA MẢNG 2 CHIỀU =================
    public class Mang2Chieu
    {
        private int[,] arr;
        private int n, m;

        public Mang2Chieu(int n, int m)
        {
            this.n = n; this.m = m;
            arr = new int[n, m];
        }

        // Indexer
        public int this[int i, int j]
        {
            get => arr[i, j];
            set => arr[i, j] = value;
        }

        public void Nhap()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Nhập [{i},{j}]: ");
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
        }

        public void Xuat()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++) Console.Write(arr[i, j] + "\t");
                Console.WriteLine();
            }
        }

        // Kiểm tra số nguyên tố
        private bool IsNguyenTo(int x)
        {
            if (x < 2) return false;
            for (int i = 2; i <= Math.Sqrt(x); i++)
                if (x % i == 0) return false;
            return true;
        }

        public void TimNguyenTo()
        {
            Console.Write("Các số nguyên tố trong mảng: ");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (IsNguyenTo(arr[i, j])) Console.Write(arr[i, j] + " ");
            Console.WriteLine();
        }
    }

    // ================= BÀI 2.3 (LẶP): LỚP ĐA THỨC =================
    public class DaThuc
    {
        private double[] heSo; // heSo[i] là hệ số của x^i

        public DaThuc(int bac)
        {
            heSo = new double[bac + 1];
        }

        // Indexer truy cập đơn thức thứ i
        public double this[int i]
        {
            get => heSo[i];
            set => heSo[i] = value;
        }

        public void Nhap()
        {
            for (int i = 0; i < heSo.Length; i++)
            {
                Console.Write($"Nhập hệ số x^{i}: ");
                heSo[i] = double.Parse(Console.ReadLine());
            }
        }

        public void Xuat()
        {
            for (int i = heSo.Length - 1; i >= 0; i--)
            {
                if (heSo[i] != 0)
                {
                    Console.Write($"{heSo[i]}x^{i}");
                    if (i > 0) Console.Write(" + ");
                }
            }
            Console.WriteLine();
        }

        // Tính giá trị đa thức tại x
        public double TinhGiaTri(double x)
        {
            double ketQua = 0;
            for (int i = 0; i < heSo.Length; i++)
            {
                ketQua += heSo[i] * Math.Pow(x, i);
            }
            return ketQua;
        }
    }

    // ================= BÀI 2.4 (LẶP): DÃY PHÂN SỐ =================
    public class DayPhanSo
    {
        private Phan1CoBan.PhanSo[] arr;

        public DayPhanSo(int n) { arr = new Phan1CoBan.PhanSo[n]; }

        public void Nhap()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Nhập phân số thứ {i + 1}:");
                Console.Write("Tử: "); int t = int.Parse(Console.ReadLine());
                Console.Write("Mẫu: "); int m = int.Parse(Console.ReadLine());
                arr[i] = new Phan1CoBan.PhanSo(t, m);
            }
        }

        // Tính tổng dãy phân số
        public Phan1CoBan.PhanSo TinhTong()
        {
            Phan1CoBan.PhanSo tong = new Phan1CoBan.PhanSo(0, 1);
            foreach (var ps in arr)
            {
                tong = tong + ps;
            }
            return tong;
        }
    }

    // ================= BÀI 2.5: TÍNH LƯƠNG NHÂN VIÊN (CƠ BẢN) =================
    public class NhanVienCoBan
    {
        public string HoTen { get; set; }
        public double LuongCoBan { get; set; }
        public int SoNgayVang { get; set; }

        public double TinhLuong()
        {
            // Mỗi ngày vắng trừ 100.000 VNĐ
            return LuongCoBan - (SoNgayVang * 100000);
        }
    }
}