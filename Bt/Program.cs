using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Nhập số thứ nhất
        Console.Write("Nhập số a: ");
        double a = double.Parse(Console.ReadLine() ?? "0");

        // Nhập số thứ hai
        Console.Write("Nhập số b: ");
        double b = double.Parse(Console.ReadLine() ?? "0");

        // Nhập phép toán
        Console.Write("Nhập phép toán (+, -, *, /, %): ");
        char op = Console.ReadKey().KeyChar;
        Console.WriteLine();

        // Sử dụng switch expression kết hợp pattern matching (guard clause)
        string resultMessage = (op, b) switch
        {
            ('+', _) => $"Ket qua: {a + b:F2}",
            ('-', _) => $"Ket qua: {a - b:F2}",
            ('*', _) => $"Ket qua: {a * b:F2}",
            ('/', 0) => "Lỗi: Không thể chia cho 0!",
            ('/', _) => $"Ket qua: {a / b:F2}",
            ('%', 0) => "Lỗi: Không thể chia cho 0!",
            ('%', _) => $"Ket qua: {a % b:F2}",
            _ => "Lỗi: Phép toán không hợp lệ!"
        };

        Console.WriteLine(resultMessage);
    }
}