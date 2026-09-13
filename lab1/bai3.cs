using System;

class Program
{
    static void Main()
    {
        // Nhập số nguyên x
        Console.Write("Nhap so nguyen x: ");
        int x = int.Parse(Console.ReadLine());

        // Nhập số nguyên y
        Console.Write("Nhap so nguyen y: ");
        int y = int.Parse(Console.ReadLine());

        // Khởi tạo kết quả bằng 1
        long ketQua = 1;

        // Tính x^y bằng cách nhân x với chính nó y lần
        for (int i = 0; i < y; i++)
        {
            ketQua *= x;
        }

        // Xuất kết quả
        Console.WriteLine($"Ket qua {x} mu {y} la: {ketQua}");
    }
}