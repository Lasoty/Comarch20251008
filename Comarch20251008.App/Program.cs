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
        Console.Write("Podaj liczbe elementów do wylosowania: ");
        int.TryParse(Console.ReadLine(), out var itemCount);

        int[] tab = new int[itemCount];
        Random rand = new Random();

        for (int i = 0; i < itemCount; i++)
        {
            tab[i] = rand.Next(1, 1000);
        }

        Console.Write("[");
        foreach (int item in tab)
        {
            Console.Write($"{item} ");
        }
        Console.Write("]");
    }

}
