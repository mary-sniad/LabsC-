using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static List<string> history = new List<string>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== КАЛЬКУЛЯТОР ===");
            Console.WriteLine("1. Вихід");
            Console.WriteLine("2. Обчислити вираз");
            Console.WriteLine("3. Показати історію");
            Console.Write("Оберіть пункт: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return;

                case "2":
                    CalculateExpression();
                    break;

                case "3":
                    ShowHistory();
                    break;

                default:
                    Console.WriteLine("Помилка: такого пункту меню немає.");
                    break;
            }
        }
    }

    static void CalculateExpression()
    {
        Console.Write("Введіть вираз (наприклад, 12 + 7): ");
        string input = Console.ReadLine();

        string[] parts = input.Split(
            new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries
        );

        if (parts.Length != 3)
        {
            Console.WriteLine("Помилка: введіть вираз у форматі: число оператор число");
            return;
        }

        if (!double.TryParse(
                parts[0],
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out double number1))
        {
            Console.WriteLine("Помилка: перше число введено неправильно.");
            return;
        }

        if (!double.TryParse(
                parts[2],
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out double number2))
        {
            Console.WriteLine("Помилка: друге число введено неправильно.");
            return;
        }

        string operation = parts[1];

        if (operation == "/" && number2 == 0)
        {
            Console.WriteLine("Помилка: ділення на нуль неможливе.");
            return;
        }

        if (operation != "+" &&
            operation != "-" &&
            operation != "*" &&
            operation != "/")
        {
            Console.WriteLine("Помилка: непідтримуваний оператор.");
            return;
        }

        double result = Calculate(number1, number2, operation);

        string historyRecord = $"{parts[0]} {operation} {parts[2]} = {result}";

        Console.WriteLine($"Результат: {result}");

        history.Add(historyRecord);
    }

    static double Calculate(double number1, double number2, string operation)
    {
        switch (operation)
        {
            case "+":
                return number1 + number2;

            case "-":
                return number1 - number2;

            case "*":
                return number1 * number2;

            case "/":
                return number1 / number2;

            default:
                return 0;
        }
    }

    static void ShowHistory()
    {
        Console.WriteLine("\n=== ІСТОРІЯ ОБЧИСЛЕНЬ ===");

        if (history.Count == 0)
        {
            Console.WriteLine("Історія порожня.");
            return;
        }

        for (int i = 0; i < history.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {history[i]}");
        }
    }
}