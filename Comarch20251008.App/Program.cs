namespace Comarch20251008.App;


/// <summary>
/// Klasa startowa aplikacji
/// </summary>
internal class Program
{
    /// <summary>
    /// Metoda startowa aplikacji <see cref="File"/> Sandcastle Help File Builder
    /// </summary>
    /// <param name="args">Parametry startowe aplikacji</param>
    static void Main(string[] args)
    {
        Console.WriteLine("KALKULATOR 1.0");
        Console.WriteLine("1. Dodawanie");
        Console.WriteLine("2. Odejmowanie");
        Console.WriteLine("3. Mnożenie");
        Console.WriteLine("4. Dzielenie");
        Console.WriteLine("5. Reszta z dzielenia");
        Console.WriteLine("6. Sortowanie");
        Console.Write("Podaj pozycję menu: ");

        string sWybor = Console.ReadLine();
        if (int.TryParse(sWybor, out int iWybor))
        {
            Console.Write("Podaj X: ");
            int x = int.Parse(Console.ReadLine());            
            Console.Write("Podaj Y: ");
            int y = Convert.ToInt32(Console.ReadLine());

            switch (iWybor)
            {
                case 1:
                    Console.WriteLine($"Wynik działania {x} + {y} to {x + y}.");
                    break;
                case 2:
                    Console.WriteLine($"Wynik działania {x} - {y} to {x - y}.");
                    break;
                case 3:
                    Console.WriteLine($"Wynik działania {x} * {y} to {x * y}.");
                    break;
                case 4:
                    Console.WriteLine($"Wynik działania {x} / {y} to {x / (float)y}.");
                    break;
                case 5:
                    Console.WriteLine($"Wynik działania {x} % {y} to {x % y}.");
                    break;
                case 6:
                    Sortuj(x, y);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wprowadzono wartość spoza zakresu menu.");
                    Console.ResetColor();
                    break;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wprowadzono niepoprawną wartość.");
            Console.ResetColor();
        }

    }

    private static void Sortuj(int x, int y)
    {
        // 1. Stwórz tablicę 20 elementową w zakresie od x do y z wartościami losowymi
        // 2. Stosując algorytm sortowania bąbelkowego posortuj tablicę rosnąco
        // 3. Wyświetl tablicę.
    }
}
