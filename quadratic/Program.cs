
using System.Collections;

namespace Quadratic
{
    internal class Program
    {
        public enum Severity
        {
            Error,
            Warning,
            Information,
        }

        static void Main()
        {
            Console.WriteLine($"Попробуем решить уравнение: \n");
            PrintEquation();

            int cursorTop = Console.CursorTop;
            Coef coefA = new("a", "", cursorTop, 0);
            Coef coefB = new("b", "", cursorTop + 1, 1);
            Coef coefC = new("c", "", cursorTop + 2, 2);
            Coef[] coefs = [coefA, coefB, coefC];

            var f = new Exception("Неверный формат параметра:");

            GetCoefs(coefs);
            foreach (var coef in coefs)
            {
                try
                {
                    coef.ValueToNumber = Int32.Parse(coef.Value);
                }
                catch (OverflowException ex)
                {
                    FormatData($"Введенное значение должно быть в диапазоне от {int.MinValue} до {int.MaxValue}", Severity.Information, ex.Data);
                    throw;
                }
                catch
                {
                    f.Data.Add(coef.Name, coef.Value);
                }
            }

            if (f.Data.Count != 0)
            {
                FormatData(f.Message, Severity.Error, f.Data);
                throw f;
            }

            try
            {
                GetResult(coefs);
            }
            catch (Exception ex)
            {
                FormatData(ex.Message, Severity.Error, ex.Data);
            }
        }

        class CalculateException : Exception 
        {
            public CalculateException(string message) : base(message)
            {
            }
        }

        private static void GetCoefs(Coef[] coefs)
        {
            int currentCoefIndex = 0;

            ConsoleKeyInfo keyEnteredInfo;
            ConsoleKey? keyEntered = null;
            char charEntered;

            while (keyEntered != ConsoleKey.Enter)
            {
                PrintCoefs(coefs, currentCoefIndex);
                keyEnteredInfo = Console.ReadKey();
                keyEntered = keyEnteredInfo.Key;
                charEntered = keyEnteredInfo.KeyChar;

                switch (keyEntered)
                {
                    case ConsoleKey.UpArrow:
                        if (currentCoefIndex > 0) currentCoefIndex -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentCoefIndex < 2) currentCoefIndex += 1;
                        break;
                    default:
                        coefs[currentCoefIndex].Value += charEntered;
                        break;
                }

                PrintEquation(coefs[0].Value, coefs[1].Value, coefs[2].Value);
            }
        }

        private static void GetResult(Coef[] coefs)
        {
            Console.SetCursorPosition(0, 8);
            int a = coefs[0].ValueToNumber;
            int b = coefs[1].ValueToNumber;
            int c = coefs[2].ValueToNumber;
            double x1, x2;
            double discriminant = 0;
            
            try
            {
                discriminant = Math.Pow(b, 2) - 4 * a * c;
                if (discriminant < 0)
                {
                    throw new CalculateException("");
                }
                else
                {
                    string exceptionText = "Ошибки вычислений";
                    if (discriminant == 0)
                    {
                        x1 = -b / (2 * a);
                        if (Double.IsNaN(x1))
                        {
                            throw new CalculateException(exceptionText);
                        }
                        Console.WriteLine($"x = {x1}");
                    }
                    else
                    {
                        x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                        x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                        if (Double.IsNaN(x1) || Double.IsNaN(x2))
                        {
                            throw new CalculateException(exceptionText);
                        }
                        Console.WriteLine($"x1 = {x1}, x2 = {x2}");
                    }
                }
            }
            catch (CalculateException ex) when (discriminant < 0)
            {
                FormatData("Вещественных значений не найдено", Severity.Warning, ex.Data);
            }
            catch (CalculateException)
            {
                throw;
            }
        }

        private static void PrintEquation(string a = "a", string b = "b", string c = "c")
        {
            string coefA = string.IsNullOrEmpty(a) ? "a" : a;
            string coefB = string.IsNullOrEmpty(b) ? "b" : b;
            string coefC = string.IsNullOrEmpty(c) ? "c" : c;
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"{coefA} * x^2 + {coefB} * x + {coefC} = 0\n");
        }

        private static void PrintCoefs(Coef[] coefs, int currentCoefIndex)
        {
            Console.SetCursorPosition(0, 4);
            foreach(var coef in coefs)
            {
                string currentIcon = currentCoefIndex == coef.Index ? ">" : " ";
                Console.WriteLine($"{currentIcon} {coef.Name}: {coef.Value}");
            }

            Console.SetCursorPosition(coefs[currentCoefIndex].CursorLeft, coefs[currentCoefIndex].CursorTop);
        }

        private static void FormatData(string message, Severity severity, IDictionary data)
        {
            Console.ForegroundColor = severity == Severity.Warning ? ConsoleColor.Black : ConsoleColor.White;
            switch (severity)
            {
                case Severity.Warning:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                case Severity.Error:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
            }
            Console.SetCursorPosition(0, 8);
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
            Console.WriteLine(message);
            foreach (DictionaryEntry param in data)
            {
                Console.WriteLine($"{param.Key} = {param.Value}");
            }
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
            Console.ResetColor();
        }
    }
}
