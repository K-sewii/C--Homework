using System;

class Chuoi
{
    // Kiểm tra chuỗi có phải chuỗi đối xứng hay không
    public bool LaChuoiDoiXung(string s)
    {
        // left bắt đầu từ đầu chuỗi
        int left = 0;

        // right bắt đầu từ cuối chuỗi
        int right = s.Length - 1;

        // So sánh từng cặp ký tự
        while (left < right)
        {
            // Nếu hai ký tự khác nhau thì không đối xứng
            if (s[left] != s[right])
            {
                return false;
            }

            left++;
            right--;
        }

        // Tất cả ký tự đều đối xứng
        return true;
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

        // Kiểm tra chuỗi
        bool ketQua = chuoi.LaChuoiDoiXung(s);

        // Xuất kết quả
        if (ketQua)
        {
            Console.WriteLine("Chuoi doi xung.");
        }
        else
        {
            Console.WriteLine("Chuoi khong doi xung.");
        }
    }
}