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
            Console.Clear();
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
