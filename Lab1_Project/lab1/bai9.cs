using System;

class TimGiaTri
{
    // Tìm giá trị lớn nhất và nhỏ nhất
    // out dùng để trả về hai kết quả
    public void TimMaxMin(
        double a,
        double b,
        double c,
        out double max,
        out double min)
    {
        // Ban đầu lấy a làm max và min
        max = a;
        min = a;

        // Tìm max
        if (b > max)
        {
            max = b;
        }

        if (c > max)
        {
            max = c;
        }

        // Tìm min
        if (b < min)
        {
            min = b;
        }

        if (c < min)
        {
            min = c;
        }
    }
}

class Program
{
    static void Main()
    {
        // Nhập ba số thực
        Console.Write("Nhap a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Nhap b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Nhap c: ");
        double c = double.Parse(Console.ReadLine());

        // Tạo đối tượng
        TimGiaTri timGiaTri = new TimGiaTri();

        // Gọi phương thức và nhận kết quả bằng out
        timGiaTri.TimMaxMin(
            a,
            b,
            c,
            out double max,
            out double min);

        // Xuất kết quả
        Console.WriteLine("Gia tri lon nhat: " + max);
        Console.WriteLine("Gia tri nho nhat: " + min);
    }
}