using System;

class SinhVien
{
    // Các thuộc tính của sinh viên
    private string maSinhVien;
    private string hoTen;
    private string diaChi;
    private int namThu;

    // Nhập thông tin sinh viên
    public void Nhap()
    {
        Console.Write("Nhap ma sinh vien: ");
        maSinhVien = Console.ReadLine();

        Console.Write("Nhap ho ten: ");
        hoTen = Console.ReadLine();

        Console.Write("Nhap dia chi: ");
        diaChi = Console.ReadLine();

        Console.Write("Nhap nam thu: ");
        namThu = int.Parse(Console.ReadLine());
    }

    // Xuất thông tin sinh viên
    public void Xuat()
    {
        Console.WriteLine("\n--- THONG TIN SINH VIEN ---");
        Console.WriteLine("Ma sinh vien: " + maSinhVien);
        Console.WriteLine("Ho ten: " + hoTen);
        Console.WriteLine("Dia chi: " + diaChi);
        Console.WriteLine("Nam thu: " + namThu);
    }
}

class Program
{
    static void Main()
    {
        // Tạo đối tượng sinh viên
        SinhVien sinhVien = new SinhVien();

        // Nhập thông tin
        sinhVien.Nhap();

        // Xuất thông tin
        sinhVien.Xuat();
    }
}