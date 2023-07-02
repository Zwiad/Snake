using System;
using System.Windows.Input;
namespace Snake
{
    public class Program
    {
        
        public static bool przegrana;
        public static int wynik;
        
        static int Main(string[] args)
        {
            Console.CursorVisible = false;
            Warunki.Start();
            while (przegrana == false) 
            {
                Plansza.rysowanie();
                Klawiatura.Sterowanie();
                Klawiatura.Logika();
                //System.Threading.Thread.Sleep(10);
            } 
            

            return 0;
        }
    }

    public class Plansza
    {
        public const int szerokosc = 20;
        public const int wysokosc = 20;
       public static void rysowanie()
        {

            Console.Clear();

            for (int i = 0; i < szerokosc; i++)
            {

                Console.Write("o");

            }

            Console.Write('\n');

            for (int i = 0; i < wysokosc - 2; i++)
            {

                for (int j = 0; j < szerokosc; j++)
                {
                    if (j == 0 || j == szerokosc - 1)
                    {

                        Console.Write("o");

                    }
                    else if (i == Warunki.y && j == Warunki.x)
                    {
                        Console.Write("O");
                    }
                    else if (i == Warunki.owocY && j == Warunki.owocX)
                    {
                        Console.Write("F");
                    }
                    else 
                    {

                        Console.Write(" ");

                    }
                }
                Console.Write("\n");
            }

            for (int i = 0; i < szerokosc; i++)
            {

                Console.Write("o");

            }
        }
    }
    public class Warunki
    {
        public static int x, y, owocX, owocY;
        public static void Start()
        {
            Program.przegrana = false;
            Program.wynik = 0;
            x = Plansza.szerokosc / 2;
            y = Plansza.wysokosc / 2;

            Random rng = new Random();
            owocX = rng.Next(1, Plansza.szerokosc - 1);
            owocY = rng.Next(1, Plansza.wysokosc - 1);
        }
    }
    public class Klawiatura
    {
        enum Kierunki
        {
            Gora,
            Dol,
            Lewo,
            Prawo
        }
        static Kierunki dir;
        public static void Logika()
        {
            ConsoleKey key;
            key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.W:
                    dir = Kierunki.Gora;
                    break;
                case ConsoleKey.S:
                    dir = Kierunki.Dol;
                    break;
                case ConsoleKey.A:
                    dir = Kierunki.Lewo;
                    break;
                case ConsoleKey.D:
                    dir = Kierunki.Prawo;
                    break;
                default:
                    break;
            }
        }
        public static void Sterowanie()
        {
            switch (dir) 
            {
                case Kierunki.Gora:
                Warunki.y--;
                    break;
                case Kierunki.Dol:
                    Warunki.y++;
                    break;
                case Kierunki.Lewo:
                    Warunki.x--;
                    break;
                case Kierunki.Prawo:
                    Warunki.x++;
                    break;
                default:
                    break;
            } 
        }
    }
}