using System;

class Program
{
    static void Main()
    {
        // Nhập x dưới dạng chuỗi
        Console.Write("Nhap so nguyen x: ");
        string inputX = Console.ReadLine();

        // Kiểm tra x có phải số nguyên hay không
        if (!int.TryParse(inputX, out int x))
        {
            Console.WriteLine("Loi: x khong phai la so nguyen.");
            return;
        }

        // Nhập y
        Console.Write("Nhap so nguyen y: ");
        string inputY = Console.ReadLine();

        // Kiểm tra y có phải số nguyên hay không
        if (!int.TryParse(inputY, out int y))
        {
            Console.WriteLine("Loi: y khong phai la so nguyen.");
            return;
        }

        // Kiểm tra số mũ không âm
        if (y < 0)
        {
            Console.WriteLine("Loi: y phai lon hon hoac bang 0.");
            return;
        }

        // Khởi tạo kết quả
        long ketQua = 1;

        // Tính x^y
        for (int i = 0; i < y; i++)
        {
            ketQua *= x;
        }

        // Xuất kết quả
        Console.WriteLine($"Ket qua {x} mu {y} la: {ketQua}");
    }
}