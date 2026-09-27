using System;

class SoNguyen
{
    // Kiểm tra n có phải số nguyên tố hay không
    public bool LaSoNguyenTo(int n)
    {
        // Số nhỏ hơn 2 không phải số nguyên tố
        if (n < 2)
        {
            return false;
        }

        // Chỉ cần kiểm tra đến căn bậc hai của n
        for (int i = 2; i * i <= n; i++)
        {
            // Nếu n chia hết cho i thì không phải số nguyên tố
            if (n % i == 0)
            {
                return false;
            }
        }

        // Không tìm được ước nên n là số nguyên tố
        return true;
    }
}

class Program
{
    static void Main()
    {
        // Nhập n
        Console.Write("Nhap n: ");
        int n = int.Parse(Console.ReadLine());

        // Tạo đối tượng
        SoNguyen soNguyen = new SoNguyen();

        // Kiểm tra số nguyên tố
        bool ketQua = soNguyen.LaSoNguyenTo(n);

        // Xuất kết quả
        if (ketQua)
        {
            Console.WriteLine($"{n} la so nguyen to.");
        }
        else
        {
            Console.WriteLine($"{n} khong phai la so nguyen to.");
        }
    }
}