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
        Console.WriteLine("Witaj!");
        Console.Write("Jak masz na imię: ");
        string imie = Console.ReadLine();
        Console.Write("Jak masz na nazwisko: ");
        string nazwisko = Console.ReadLine();
        Console.Write("Ile masz lat: ");
        string sWiek = Console.ReadLine();
        int wiek = Convert.ToInt32(sWiek);
        int rokUrodzenia = DateTime.Now.Year - wiek;

        //Console.WriteLine("Urodziłeś się w " + rokUrodzenia + ".");
        Console.WriteLine($"Urodziłeś się w {rokUrodzenia}.");

    }
  
}
