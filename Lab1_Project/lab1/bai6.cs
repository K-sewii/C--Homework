using System;

class SoNguyen
{
    // Tìm giá trị lớn nhất của ba số nguyên
    public int TimMax(int a, int b, int c)
    {
        // Tạm thời xem a là số lớn nhất
        int max = a;

        // So sánh b với max
        if (b > max)
        {
            max = b;
        }

        // So sánh c với max
        if (c > max)
        {
            max = c;
        }

        // Trả về giá trị lớn nhất
        return max;
    }
}

class Program
{
    static void Main()
    {
        // Nhập ba số nguyên
        Console.Write("Nhap a: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Nhap b: ");
        int b = int.Parse(Console.ReadLine());

        Console.Write("Nhap c: ");
        int c = int.Parse(Console.ReadLine());

        // Tạo đối tượng SoNguyen
        SoNguyen soNguyen = new SoNguyen();

        // Gọi phương thức tìm max
        int max = soNguyen.TimMax(a, b, c);

        // Xuất kết quả
        Console.WriteLine("Gia tri lon nhat: " + max);
    }
}