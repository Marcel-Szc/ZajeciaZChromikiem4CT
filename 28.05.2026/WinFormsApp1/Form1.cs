using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private LogikaSnake gra;
        private const int RozmiarKratki = 20;
        private const int SzerokoscSiatki = 20;
        private const int WysokoscSiatki = 20;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;

            this.ClientSize = new Size(SzerokoscSiatki * RozmiarKratki, WysokoscSiatki * RozmiarKratki);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            gra = new LogikaSnake(SzerokoscSiatki, WysokoscSiatki);

            gra.NaKoniecGry += ObslugaKoniecGry;
            gra.NaZjedzenieJedzenia += ObslugaZjedzeniaJedzenia;

            timer1.Interval = 100;
            timer1.Start();
        }

        private void ObslugaZjedzeniaJedzenia(object sender, EventArgs e)
        {
            lblPunkty.Text = "Punkty: " + gra.Punkty;
        }

        private void ObslugaKoniecGry(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show($"Koniec gry! Zdobyte punkty: {gra.Punkty}", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gra.ResetujGre();
            lblPunkty.Text = "Punkty: 0";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gra.Aktualizuj();
            this.Invalidate(); 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up: if (gra.AktualnyKierunek != Kierunek.Dol) gra.AktualnyKierunek = Kierunek.Gora; break;
                case Keys.Down: if (gra.AktualnyKierunek != Kierunek.Gora) gra.AktualnyKierunek = Kierunek.Dol; break;
                case Keys.Left: if (gra.AktualnyKierunek != Kierunek.Prawo) gra.AktualnyKierunek = Kierunek.Lewo; break;
                case Keys.Right: if (gra.AktualnyKierunek != Kierunek.Lewo) gra.AktualnyKierunek = Kierunek.Prawo; break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            using (Pen kolorLinii = new Pen(Color.FromArgb(30, 30, 30)))
            {
                for (int x = 0; x <= SzerokoscSiatki; x++)
                    g.DrawLine(kolorLinii, x * RozmiarKratki, 0, x * RozmiarKratki, WysokoscSiatki * RozmiarKratki);

                for (int y = 0; y <= WysokoscSiatki; y++)
                    g.DrawLine(kolorLinii, 0, y * RozmiarKratki, SzerokoscSiatki * RozmiarKratki, y * RozmiarKratki);
            }

            g.FillEllipse(Brushes.Red, gra.Jedzenie.X * RozmiarKratki, gra.Jedzenie.Y * RozmiarKratki, RozmiarKratki, RozmiarKratki);

            for (int i = 0; i < gra.Waz.Count; i++)
            {
                Brush kolor = (i == 0) ? Brushes.DarkGreen : Brushes.Green;
                g.FillRectangle(kolor, gra.Waz[i].X * RozmiarKratki, gra.Waz[i].Y * RozmiarKratki, RozmiarKratki, RozmiarKratki);
                g.DrawRectangle(Pens.Black, gra.Waz[i].X * RozmiarKratki, gra.Waz[i].Y * RozmiarKratki, RozmiarKratki, RozmiarKratki);
            }
        }
    }
}