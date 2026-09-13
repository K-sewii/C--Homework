using System;

class Program
{
    // Nhập hai số thực x và y
    // ref cho phép thay đổi trực tiếp giá trị của x và y
    static void NhapSo(ref double x, ref double y)
    {
        Console.Write("Nhap x: ");
        x = double.Parse(Console.ReadLine());

        Console.Write("Nhap y: ");
        y = double.Parse(Console.ReadLine());
    }

    // Tính x^y
    static double TinhLuyThua(double x, double y)
    {
        return Math.Pow(x, y);
    }

    // Tính căn bậc hai của x và y
    // out dùng để trả về hai kết quả
    static void TinhCanBacHai(
        double x,
        double y,
        out double canX,
        out double canY)
    {
        canX = x >= 0 ? Math.Sqrt(x) : double.NaN;
        canY = y >= 0 ? Math.Sqrt(y) : double.NaN;
    }

    static void Main()
    {
        double x = 0;
        double y = 0;
        int luaChon;

        // Lặp menu cho đến khi chọn 4
        do
        {
            Console.WriteLine("\nMENU");
            Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
            Console.WriteLine("2. Tinh x^y");
            Console.WriteLine("3. Tinh can bac 2 cua x va y");
            Console.WriteLine("4. Thoat");
            Console.Write("Chon chuc nang: ");

            // Kiểm tra lựa chọn
            if (!int.TryParse(Console.ReadLine(), out luaChon))
            {
                Console.WriteLine("Lua chon khong hop le.");
                continue;
            }

            switch (luaChon)
            {
                case 1:
                    // Nhập x và y bằng ref
                    NhapSo(ref x, ref y);
                    break;

                case 2:
                    // Tính lũy thừa
                    double ketQua = TinhLuyThua(x, y);
                    Console.WriteLine($"x^y = {ketQua}");
                    break;

                case 3:
                    // Tính căn bậc hai bằng out
                    TinhCanBacHai(
                        x,
                        y,
                        out double canX,
                        out double canY);

                    Console.WriteLine($"Can bac hai cua x = {canX}");
                    Console.WriteLine($"Can bac hai cua y = {canY}");
                    break;

                case 4:
                    Console.WriteLine("Thoat chuong trinh.");
                    break;

                default:
                    Console.WriteLine("Lua chon khong hop le.");
                    break;
            }

        } while (luaChon != 4);
    }
}