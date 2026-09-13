using System;
using System.Collections.Generic;

class MangSoNguyen
{
    // Mảng số nguyên
    private int[] a;

    // Nhập mảng
    public void Nhap()
    {
        // Nhập số lượng phần tử
        Console.Write("Nhap n: ");
        int n = int.Parse(Console.ReadLine());

        // Khởi tạo mảng
        a = new int[n];

        // Nhập từng phần tử
        for (int i = 0; i < n; i++)
        {
            Console.Write($"a[{i}] = ");
            a[i] = int.Parse(Console.ReadLine());
        }
    }

    // In mảng
    public void InMang()
    {
        Console.WriteLine("Mang:");

        for (int i = 0; i < a.Length; i++)
        {
            Console.Write(a[i] + " ");
        }

        Console.WriteLine();
    }

    // Tìm giá trị lớn nhất và nhỏ nhất
    public void TimMaxMin(out int max, out int min)
    {
        // Ban đầu lấy phần tử đầu tiên làm max và min
        max = a[0];
        min = a[0];

        // Duyệt các phần tử còn lại
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] > max)
            {
                max = a[i];
            }

            if (a[i] < min)
            {
                min = a[i];
            }
        }
    }

    // Kiểm tra một số có phải số nguyên tố hay không
    private bool LaSoNguyenTo(int n)
    {
        if (n < 2)
        {
            return false;
        }

        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    // Lấy các số nguyên tố trong mảng
    public int[] LayMangSoNguyenTo()
    {
        List<int> ketQua = new List<int>();

        // Duyệt từng phần tử
        foreach (int x in a)
        {
            // Nếu là số nguyên tố thì thêm vào danh sách
            if (LaSoNguyenTo(x))
            {
                ketQua.Add(x);
            }
        }

        // Chuyển List thành mảng
        return ketQua.ToArray();
    }
}

class Program
{
    static void Main()
    {
        // Tạo đối tượng mảng
        MangSoNguyen mang = new MangSoNguyen();

        // Nhập mảng
        mang.Nhap();

        // In mảng
        mang.InMang();

        // Tìm max và min
        mang.TimMaxMin(out int max, out int min);

        Console.WriteLine("Gia tri lon nhat: " + max);
        Console.WriteLine("Gia tri nho nhat: " + min);

        // Lấy các số nguyên tố
        int[] mangNguyenTo = mang.LayMangSoNguyenTo();

        Console.WriteLine("Cac so nguyen to:");

        foreach (int x in mangNguyenTo)
        {
            Console.Write(x + " ");
        }

        Console.WriteLine();
    }
}