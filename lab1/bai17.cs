using System;
using System.Collections.Generic;

class MaTran
{
    // Mảng hai chiều
    private int[,] a;

    // Số dòng và số cột
    private int n;
    private int m;

    // Tạo ma trận ngẫu nhiên
    public void TaoMang()
    {
        // Nhập số dòng
        Console.Write("Nhap so dong n: ");
        n = int.Parse(Console.ReadLine());

        // Nhập số cột
        Console.Write("Nhap so cot m: ");
        m = int.Parse(Console.ReadLine());

        // Khởi tạo ma trận
        a = new int[n, m];

        // Tạo đối tượng Random
        Random random = new Random();

        // Sinh các phần tử ngẫu nhiên từ 10 đến 100
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                a[i, j] = random.Next(10, 101);
            }
        }
    }

    // In ma trận
    public void InMang()
    {
        Console.WriteLine("\nMa tran:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(a[i, j] + "\t");
            }

            Console.WriteLine();
        }
    }

    // Tách các phần tử chẵn và lẻ
    public void TachChanLe(
        out int[] mangChan,
        out int[] mangLe)
    {
        // Tạo hai danh sách tạm
        List<int> chan = new List<int>();
        List<int> le = new List<int>();

        // Duyệt toàn bộ ma trận
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                // Kiểm tra số chẵn
                if (a[i, j] % 2 == 0)
                {
                    chan.Add(a[i, j]);
                }
                else
                {
                    // Nếu không chẵn thì là số lẻ
                    le.Add(a[i, j]);
                }
            }
        }

        // Chuyển List thành mảng
        mangChan = chan.ToArray();
        mangLe = le.ToArray();
    }
}

class Program
{
    static void Main()
    {
        // Tạo đối tượng ma trận
        MaTran maTran = new MaTran();

        // Tạo ma trận
        maTran.TaoMang();

        // In ma trận
        maTran.InMang();

        // Tách số chẵn và số lẻ
        maTran.TachChanLe(
            out int[] mangChan,
            out int[] mangLe);

        // In các số chẵn
        Console.WriteLine("\nCac so chan:");

        foreach (int x in mangChan)
        {
            Console.Write(x + " ");
        }

        // In các số lẻ
        Console.WriteLine("\n\nCac so le:");

        foreach (int x in mangLe)
        {
            Console.Write(x + " ");
        }

        Console.WriteLine();
    }
}