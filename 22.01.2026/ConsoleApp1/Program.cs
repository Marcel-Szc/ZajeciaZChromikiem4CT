using System.Numerics;

namespace Gra_memory
{
    internal class Program
    {
        private int rozmiar = 0;
        private List<char> lista_znakow = new List<char>()
        {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','R','S' };
        private char[,] tablica;
        private char[,] tablicaStatus;
        private int punktyGracza1;
        private int punktyGracza2;
        private int numerGracza = 1;
        static void Main(string[] args)
        {
            Program program = new Program();
            program.WybierzTablice();
            program.WypelnijTablice();
            program.MieszanieZnakow();
            program.StartGry();
        }
        public void WybierzTablice()
        {
            Console.WriteLine("Wybierz matryce: 1 - 4x4, 2 - 6x6");
            int wybor = Convert.ToInt32(Console.ReadLine());
            if (wybor == 1)
            {
                rozmiar = 4;
            }
            else if (wybor == 2)
            {
                rozmiar = 6;
            }
            else
            {
                throw new Exception("");
            }
            tablica = new char[rozmiar, rozmiar];
            tablicaStatus = new char[rozmiar, rozmiar];
        }
        public void WypelnijTablice()
        {
            int zmienna = 0;
            bool czyZmianaZnaku = false;
            for (int i = 0; i < rozmiar; i++)
            {
                for (int j = 0; j < rozmiar; j++)
                {
                    tablica[i, j] = lista_znakow[zmienna];
                    tablicaStatus[i, j] = '0';
                    if (czyZmianaZnaku == false)
                    {
                        czyZmianaZnaku = true;
                    }
                    else if (czyZmianaZnaku == true)
                    {
                        zmienna++;
                        czyZmianaZnaku = false;
                    }
                }
            }
        }
        public void MieszanieZnakow()
        {
            Random random = new Random();
            for (int i = 0; i < 50; i++)
            {
                int x1 = random.Next(0, rozmiar);
                int y1 = random.Next(0, rozmiar);
                int x2;
                int y2;
                do
                {
                    x2 = random.Next(0, rozmiar);
                    y2 = random.Next(0, rozmiar);
                }
                while (x1 == x2 || y1 == y2);
                char temp = tablica[x1, y1];
                tablica[x1, y1] = tablica[x2, y2];
                tablica[x2, y2] = temp;
            }
        }
        public void WyswietlTablice()
        {
            Console.Clear();
            Console.WriteLine($"Punkty gracza 1: {punktyGracza1}, Punkty gracza 2: {punktyGracza2}" +
                $", Teraz ruch ma gracz numer: {numerGracza}");
            Console.WriteLine();
            Console.SetCursorPosition(2, 1);
            for (int i = 0; i < rozmiar; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < rozmiar; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < rozmiar; j++)
                {
                    if (tablicaStatus[i, j] == '0')
                    {
                        Console.Write("X ");
                    }
                    else if (tablicaStatus[i, j] == '1')
                    {
                        Console.Write(tablica[i, j] + " ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(tablica[i, j]);
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
        private void StartGry()
        {
            char karta1;
            char karta2;
            int wiersz1;
            int wiersz2;
            int kolumna1;
            int kolumna2;
            while (!SprawdzCzyKoniecGry())
            {
                WyswietlTablice();
                Console.WriteLine("");
                Console.WriteLine("Podaj wiersz karty 1");
                wiersz1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Podaj kolumne karty 1");
                kolumna1 = Convert.ToInt32(Console.ReadLine());

                tablicaStatus[wiersz1, kolumna1] = '1';
                WyswietlTablice();

                Console.WriteLine("Podaj wiersz karty 2");
                wiersz2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Podaj kolumne karty 2");
                kolumna2 = Convert.ToInt32(Console.ReadLine());

                tablicaStatus[wiersz2, kolumna2] = '1';
                WyswietlTablice();

                karta1 = tablica[wiersz1, kolumna1];
                karta2 = tablica[wiersz2, kolumna2];
                if (karta1 == karta2)
                {
                    if (numerGracza == 1)
                    {
                        punktyGracza1++;
                    }
                    else
                    {
                        punktyGracza2++;
                    }
                    tablicaStatus[wiersz1, kolumna1] = '2';
                    tablicaStatus[wiersz2, kolumna2] = '2';
                }
                else
                {
                    tablicaStatus[wiersz1, kolumna1] = '0';
                    tablicaStatus[wiersz2, kolumna2] = '0';
                    if (numerGracza == 1)
                    {
                        numerGracza = 2;
                    }
                    else
                    {
                        numerGracza = 1;
                    }
                }
                Console.ReadLine();
            }
            WyswietlTablice();
            if (SprawdzCzyKoniecGry())
            {
                if (punktyGracza1 > punktyGracza2)
                {
                    Console.WriteLine("Gratulacje wygral gracz 1");
                }
                if (punktyGracza1 < punktyGracza2)
                {
                    Console.WriteLine("Gratulacje wygral gracz 2");
                }
                else
                {
                    Console.WriteLine("Remis");
                }
            }
        }
        private bool SprawdzCzyKoniecGry()
        {
            bool koniecGry = true;
            for (int i = 0; i < rozmiar; i++)
            {
                for (int j = 0; j < rozmiar; j++)
                {
                    if (tablicaStatus[i, j] == '0' && koniecGry == true)
                    {
                        koniecGry = false;
                    }
                }
            }
            return koniecGry;
        }
    }
}