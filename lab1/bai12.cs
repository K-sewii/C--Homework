using System;

class Chuoi
{
    // Xử lý chuỗi
    public void XuLyChuoi(string s)
    {
        // Chuyển toàn bộ chuỗi thành chữ thường
        string chuoiThuong = s.ToLower();

        // Chuyển toàn bộ chuỗi thành chữ hoa
        string chuoiHoa = s.ToUpper();

        // Tách chuỗi thành các từ
        string[] cacTu = s.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries);

        // Xuất chuỗi chữ thường
        Console.WriteLine("Chuoi thuong: " + chuoiThuong);

        // Xuất chuỗi chữ hoa
        Console.WriteLine("Chuoi hoa: " + chuoiHoa);

        // Xuất số lượng từ
        Console.WriteLine("So luong tu: " + cacTu.Length);
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

        // Xử lý chuỗi
        chuoi.XuLyChuoi(s);
    }
}