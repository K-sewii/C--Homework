using System;

class MangHoTen
{
    // Mảng lưu danh sách họ tên
    private string[] danhSach;

    // Nhập danh sách họ tên
    public void Nhap()
    {
        // Nhập số lượng người
        Console.Write("Nhap n: ");
        int n = int.Parse(Console.ReadLine());

        // Khởi tạo mảng
        danhSach = new string[n];

        // Nhập từng họ tên
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Ho ten [{i}]: ");
            danhSach[i] = Console.ReadLine();
        }
    }

    // Sắp xếp danh sách họ tên
    public void SapXep()
    {
        // Sắp xếp theo thứ tự hiện tại của chuỗi
        Array.Sort(
            danhSach,
            StringComparer.CurrentCulture);
    }

    // In danh sách
    public void InMang()
    {
        for (int i = 0; i < danhSach.Length; i++)
        {
            Console.WriteLine(danhSach[i]);
        }
    }
}

class Program
{
    static void Main()
    {
        // Tạo đối tượng
        MangHoTen mang = new MangHoTen();

        // Nhập danh sách
        mang.Nhap();

        // Sắp xếp
        mang.SapXep();

        // Xuất danh sách sau khi sắp xếp
        Console.WriteLine("\nDanh sach sau khi sap xep:");
        mang.InMang();
    }
}