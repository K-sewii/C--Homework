using System;

class Chuoi
{
    // Đảo ngược chuỗi
    public string DaoChuoi(string s)
    {
        // Chuyển chuỗi thành mảng ký tự
        char[] mangKyTu = s.ToCharArray();

        // Đảo ngược mảng ký tự
        Array.Reverse(mangKyTu);

        // Chuyển mảng ký tự trở lại thành chuỗi
        return new string(mangKyTu);
    }
}

class Program
{
    static void Main()
    {
        // Nhập chuỗi
        Console.Write("Nhap chuoi: ");
        string s = Console.ReadLine();

        // Tạo đối tượng
        Chuoi chuoi = new Chuoi();

        // Gọi phương thức đảo chuỗi
        string ketQua = chuoi.DaoChuoi(s);

        // Xuất kết quả
        Console.WriteLine("Chuoi sau khi dao: " + ketQua);
    }
}