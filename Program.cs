using System;

class Program
{
    static void Main()
    {
        decimal initialAmount = GetDecimal("Podaj kwotę początkową na koncie: ");
        decimal interestRate = GetDecimal("Podaj oprocentowanie konta w skali roku: ");
        int months = GetNumber("Podaj liczbę miesięcy oszczędzania: ");

        decimal finalAmount = CalculateFinalAmount(initialAmount, interestRate, months);

        Console.WriteLine($"Kwota końcowa na koncie oszczędnościowym wynosi: {finalAmount} zł");

        Console.ReadKey();
    }

    static decimal CalculateFinalAmount(decimal initialAmount, decimal interestRate, int months)
    {
        decimal taxRate = 0.19m; // Stawka podatku Belki wynosi 19%
        decimal monthlyInterestRate = interestRate / 12 / 100;
        decimal finalAmount = initialAmount * (decimal)Math.Pow(1 + (double)monthlyInterestRate, months);

        decimal taxedInterest = finalAmount - initialAmount;
        decimal taxAmount = taxedInterest * taxRate;
        finalAmount -= taxAmount;

        return finalAmount;
    }

    static decimal GetDecimal(string message)
    {
        decimal number;
        while (true)
        {
            Console.Write(message);
            if (decimal.TryParse(Console.ReadLine(), out number) && number >= 0)
            {
                break;
            }
            Console.WriteLine("Błędne dane. Podaj poprawną kwotę.");
        }

        return number;
    }

    static int GetNumber(string message)
    {
        int number;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out number) && number >= 0)
            {
                break;
            }
            Console.WriteLine("Błędne dane. Podaj liczbę naturalną.");
        }

        return number;
    }
}