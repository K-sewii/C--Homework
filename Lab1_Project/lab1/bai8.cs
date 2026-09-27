using System;

class HoanVi
{
    // Hoán vị hai số thực bằng ref
    public void Swap(ref double a, ref double b)
    {
        // Lưu tạm giá trị của a
        double temp = a;

        // Đưa b vào a
        a = b;

        // Đưa giá trị ban đầu của a vào b
        b = temp;
    }
}

class Program
{
    static void Main()
    {
        // Nhập a
        Console.Write("Nhap a: ");
        double a = double.Parse(Console.ReadLine());

        // Nhập b
        Console.Write("Nhap b: ");
        double b = double.Parse(Console.ReadLine());

        // In trước khi hoán vị
        Console.WriteLine(
            $"Truoc khi hoan vi: a = {a}, b = {b}");

        // Tạo đối tượng
        HoanVi hoanVi = new HoanVi();

        // Hoán vị a và b
        hoanVi.Swap(ref a, ref b);

        // In sau khi hoán vị
        Console.WriteLine(
            $"Sau khi hoan vi: a = {a}, b = {b}");
    }
}