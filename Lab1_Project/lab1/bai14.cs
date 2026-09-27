using System;

class NhanVien
{
    // Các thuộc tính của nhân viên
    private string hoTen;
    private double mucLuong;
    private int soNgayVang;

    // Nhập thông tin nhân viên
    public void Nhap()
    {
        Console.Write("Nhap ho ten: ");
        hoTen = Console.ReadLine();

        Console.Write("Nhap muc luong: ");
        mucLuong = double.Parse(Console.ReadLine());

        Console.Write("Nhap so ngay vang: ");
        soNgayVang = int.Parse(Console.ReadLine());
    }

    // Tính lương sau khi trừ tiền nghỉ
    public double TinhLuong()
    {
        // Mỗi ngày vắng bị trừ 100000 đồng
        return mucLuong - soNgayVang * 100000;
    }

    // Xuất thông tin nhân viên
    public void Xuat()
    {
        Console.WriteLine("\n--- THONG TIN NHAN VIEN ---");
        Console.WriteLine("Ho ten: " + hoTen);
        Console.WriteLine("Muc luong: " + mucLuong);
        Console.WriteLine("So ngay vang: " + soNgayVang);
        Console.WriteLine("Luong thuc nhan: " + TinhLuong());
    }
}

class Program
{
    static void Main()
    {
        // Tạo đối tượng nhân viên
        NhanVien nhanVien = new NhanVien();

        // Nhập thông tin
        nhanVien.Nhap();

        // Xuất thông tin
        nhanVien.Xuat();
    }
}