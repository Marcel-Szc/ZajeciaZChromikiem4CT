Console.WriteLine("Wybierz matryce: 1. 4x4 lub 2. 6x6");
int liczba = int.Parse(Console.ReadLine());

int LiczbaWierszy;
int punkty_gracz1 = 0;
int punkty_gracz2 = 0;
int gracz = 1;
char[]znaki= {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','Q','P','R'};

char[,] matryca;

char[,] czyOdkryte;
int x1 = 0, y1 = 0,x2 = 0,y2 = 0;

if (liczba == 1)
{
    LiczbaWierszy = 4;
    WypelnijTablice(LiczbaWierszy);
}
else
{
    LiczbaWierszy = 6;
    WypelnijTablice(LiczbaWierszy);
}
void WypelnijTablice(int wiersz)
{
    int numerZnaku = 0;

    bool czyZwiekszycNumer = false;
    matryca = new char[wiersz, wiersz];
    czyOdkryte = new char[wiersz, wiersz];
    for (int i = 0; i < wiersz; i++)
    {
        for (int j = 0; j < wiersz; j++)
        {
            matryca[i, j] = znaki[numerZnaku];
            if (!czyZwiekszycNumer)
            {
                czyZwiekszycNumer=true;  
            }
            else if(czyZwiekszycNumer){
                numerZnaku++;
                czyZwiekszycNumer = false;
            }
            czyOdkryte[i, j] = '0';
        }

    }
    WyswietlZnaki(matryca);
    Console.WriteLine("Mieszanie znaków");
    Console.ReadLine();
    MieszanieZnakow(LiczbaWierszy,matryca);
    WyswietlZnaki(matryca);
    OdswiezTablice();
    Graj();


}

void WyswietlZnaki(char[,] matryca)
{

    for (int i = 0; i < LiczbaWierszy; i++) {
        for (int j = 0; j < LiczbaWierszy; j++) {
            Console.Write(matryca[i,j] + " ");
        }
        Console.WriteLine();
    }

}

void MieszanieZnakow(int LiczbaWierszy, char[,] matryca)
{
    Random rand = new Random();
    for(int k = 0; k < 50; k++)
    {
        int x1 = rand.Next(0, LiczbaWierszy);
        int y1 = rand.Next(0, LiczbaWierszy);
        int x2 = rand.Next(0, LiczbaWierszy);
        int y2 = rand.Next(0, LiczbaWierszy);
        char temp = matryca[x1, y1];
        matryca[x1,y1] = matryca[x2,y2];
        matryca[x2,y2] = temp;
    }
}

void OdswiezTablice()
{
    Console.Clear();
    Console.WriteLine($"Puntky gracza 1 - {punkty_gracz1}   Puntky gracza 2 - {punkty_gracz2}  |  teraz gra gracz: {gracz}");
    Console.WriteLine();
    Console.SetCursorPosition(2, 3);
    for (int i = 0; i < LiczbaWierszy; i++)
    {
        Console.Write(i + " ");

    }
    Console.WriteLine();
    for (int i = 0; i < LiczbaWierszy; i++)
    {
        Console.Write(i + " ");
        for (int j = 0; j < LiczbaWierszy; j++)
        {
            if (czyOdkryte[i,j] == '0')
            {
                Console.Write("X ");
            }
            else if (czyOdkryte[i, j] == '2')
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write(matryca[i, j]);
                Console.ResetColor();
                Console.Write(" ");
            }
            else
            {
                Console.Write(matryca[i, j] + " ");
            }
        }
        Console.Write("\n");
    }
}

bool SprawdzCzyKoniec()
{
    bool Koniec = false;
    bool jestzero = false;
    for (int i = 0; i < LiczbaWierszy; i++)
    {
        for (int j = 0; j < LiczbaWierszy; j++)
        {
            if (czyOdkryte[i, j] == 0)
            {
                jestzero = true;
            }
        }
    }
    if (jestzero == false)
    {
        Koniec = true;
    }
    return Koniec;
}

void Graj()
{
    char karta1 = ' ';
    char karta2 = ' ';
    while (SprawdzCzyKoniec()) {
        OdswiezTablice();
        
        karta1 = ZapytajOKarte(1);
        
        karta2 = ZapytajOKarte(2);
   
        if (karta1 == karta2)
        {
            czyOdkryte[x1, y1] = '2';
            czyOdkryte[x2, y2] = '2';
            if(gracz == 1)
            {
                punkty_gracz1++;
            }
            else
            {
                punkty_gracz2++;
            }
        }
        else
        {
            czyOdkryte[x1, y1] = '0';
            czyOdkryte[x2, y2] = '0';
            if (gracz == 1)
            {
                gracz = 2;
            }
            else
            {
                gracz = 1;
            }
        }
    Console.ReadLine();
    }
}
char ZapytajOKarte(int numerkarty)
{
    int x, y;
    while (true)
    {
        OdswiezTablice();
        Console.WriteLine($"Podaj wspolrzedna x dla karty {numerkarty}: ");
        x = int.Parse(Console.ReadLine());
        Console.WriteLine($"Podaj wspolrzedna y dla karty {numerkarty}: ");
        y = int.Parse(Console.ReadLine());
        if (czyOdkryte[x, y] == '0')
        {
            break;
        }
        else
        {
            Console.WriteLine("Podałeś już odkrytą kartę. ");
            Console.ReadLine();
        }
    }
    if (numerkarty == 1)
    {
        x1 = x;
        y1 = y;
    }
    else
    {
        x2 = x;
        y2 = y;
    }

    czyOdkryte[x, y] = '1';
    OdswiezTablice();


    return matryca[x, y];
}