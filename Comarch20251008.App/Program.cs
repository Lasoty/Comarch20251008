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
        do
        {

            ShowMenu();

            string stringChoise = Console.ReadLine();
            if (int.TryParse(stringChoise, out int intChoise))
            {
                GetXY(out int x, out int y);
                Calculator calc = new Calculator();

                switch (intChoise)
                {
                    case 1:
                        Console.WriteLine($"Wynik działania {x} + {y} to {calc.Add(x, y)}.");
                        break;
                    case 2:
                        Console.WriteLine($"Wynik działania {x} - {y} to {calc.Subtract(x, y)}.");
                        break;
                    case 3:
                        Console.WriteLine($"Wynik działania {x} * {y} to {calc.Multiply(x, y)}.");
                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine($"Wynik działania {x} / {y} to {calc.Dividy(x, y)}.");
                        }
                        catch (Exception ex)
                        {
                            ShowError(ex.Message);
                            Environment.Exit(100);
                        }
                        break;
                    case 5:
                        try
                        {
                            Console.WriteLine($"Wynik działania {x} % {y} to {calc.Modulo(x, y)}.");
                        }
                        catch (DivideByZeroException ex)
                        {
                            ShowError(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            ShowError("Wystąpił nieprzewidziany wyjątek.");
                        }
                        break;
                    case 6:
                        Sortuj(x, y);
                        Program.Sortuj(x, y);
                        break;
                    default:
                        ShowError("Wprowadzono wartość spoza zakresu menu.");
                        break;
                }
            }
            else
            {
                ShowError("Wprowadzono niepoprawną wartość.");
            }

        } while (AskToClose());

        // YAGNI
        // DRY
        // KISS
        // SOLID

    }

    private static bool AskToClose()
    {
        Console.Write("Czy chcesz wykonać kolejną operację [T|n]: ");
        var userChoise = Console.ReadKey();

        return userChoise.Key != ConsoleKey.N;
    }

    private static void ShowError(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.ResetColor();
    }

    private static void GetXY(out int x, out int y)
    {
        Console.Clear();
        Console.Write("Podaj X: ");
        x = int.Parse(Console.ReadLine());
        Console.Write("Podaj Y: ");
        y = Convert.ToInt32(Console.ReadLine());
    }

    private static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("KALKULATOR 1.0");
        Console.WriteLine("1. Dodawanie");
        Console.WriteLine("2. Odejmowanie");
        Console.WriteLine("3. Mnożenie");
        Console.WriteLine("4. Dzielenie");
        Console.WriteLine("5. Reszta z dzielenia");
        Console.WriteLine("6. Sortowanie");
        Console.Write("Podaj pozycję menu: ");
    }

    static void Sortuj(int x, int y)
    {
        Console.Clear();
        // 1. Zapytaj użytkownika o ilość elementów
        Console.Write("Podaj ilość elementów tablicy: ");
        int n = int.Parse(Console.ReadLine());

        // 2. Stwórz tablicę n-elementową z losowymi wartościami w zakresie x–y
        int[] tablica = new int[n];
        Random rnd = new Random();

        //int max = (new int[] { x, y }).Max();
        //int min = (new int[] { x, y }).Min();

        for (int i = 0; i < n; i++)
        {
            tablica[i] = rnd.Next(x, y);
        }

        Console.WriteLine("Tablica przed sortowaniem:");
        WyswietlTablice(tablica);

        // 3. Sortowanie bąbelkowe (rosnąco)
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (tablica[j] > tablica[j + 1])
                {
                    // zamiana miejscami
                    int temp = tablica[j];
                    tablica[j] = tablica[j + 1];
                    tablica[j + 1] = temp;
                }
            }
        }

        // 4. Wyświetl posortowaną tablicę
        Console.WriteLine("\nTablica po sortowaniu:");
        WyswietlTablice(tablica);
    }

    static void WyswietlTablice(int[] tab)
    {
        Console.Write("[");
        for (int i = 0; i < tab.Length; i++)
        {
            Console.Write(tab[i] + " ");
        }
        Console.WriteLine("]");
    }
}
