using System;

class Program
{
    static void Main()
    {
        Console.Write("Nhap a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Nhap b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Nhap phep toan (+, -, *, /, %): ");
        char op = char.Parse(Console.ReadLine());

        try
        {
            double result = op switch
            {
                '+' => a + b,
                '-' => a - b,
                '*' => a * b,
                '/' when b == 0 => throw new DivideByZeroException(),
                '/' => a / b,
                '%' when b == 0 => throw new DivideByZeroException(),
                '%' => a % b,
                _ => throw new InvalidOperationException("Phep toan không hop le!")
            };

            Console.WriteLine($"Ket qua: {result:F2}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Loi: Khong the chia cho 0!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}