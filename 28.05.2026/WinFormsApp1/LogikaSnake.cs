using System;
using System.Collections.Generic;
using System.Drawing;

namespace WinFormsApp1
{
    public enum Kierunek
    {
        Gora,
        Dol,
        Lewo,
        Prawo
    }

    public class LogikaSnake
    {
        public List<Point> Waz { get; private set; }
        public Point Jedzenie { get; private set; }
        public int Punkty { get; private set; }
        public Kierunek AktualnyKierunek { get; set; }

        private readonly int maxSzerokosc;
        private readonly int maxWysokosc;
        private readonly Random random = new Random();

        public event EventHandler NaKoniecGry;
        public event EventHandler NaZjedzenieJedzenia;

        public LogikaSnake(int szerokoscSiatki, int wysokoscSiatki)
        {
            maxSzerokosc = szerokoscSiatki;
            maxWysokosc = wysokoscSiatki;
            ResetujGre();
        }

        public void ResetujGre()
        {
            Punkty = 0;
            AktualnyKierunek = Kierunek.Prawo;

            Waz = new List<Point>
            {
                new Point(10, 10),
                new Point(9, 10),
                new Point(8, 10)
            };

            GenerujJedzenie();
        }

        public void GenerujJedzenie()
        {
            int losowyX, losowyY;
            do
            {
                losowyX = random.Next(0, maxSzerokosc);
                losowyY = random.Next(0, maxWysokosc);
                Jedzenie = new Point(losowyX, losowyY);
            } while (Waz.Contains(Jedzenie));
        }

        public void Aktualizuj()
        {
            Point nowaGlowa = Waz[0];

            switch (AktualnyKierunek)
            {
                case Kierunek.Gora: nowaGlowa.Y -= 1; break;
                case Kierunek.Dol: nowaGlowa.Y += 1; break;
                case Kierunek.Lewo: nowaGlowa.X -= 1; break;
                case Kierunek.Prawo: nowaGlowa.X += 1; break;
            }

            if (nowaGlowa.X < 0 || nowaGlowa.X >= maxSzerokosc ||
                nowaGlowa.Y < 0 || nowaGlowa.Y >= maxWysokosc ||
                Waz.Contains(nowaGlowa))
            {
                NaKoniecGry?.Invoke(this, EventArgs.Empty);
                return;
            }

            Waz.Insert(0, nowaGlowa);

            if (nowaGlowa == Jedzenie)
            {
                Punkty += 10;
                NaZjedzenieJedzenia?.Invoke(this, EventArgs.Empty);
                GenerujJedzenie();
            }
            else
            {
                Waz.RemoveAt(Waz.Count - 1);
            }
        }
    }
}