using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Linq;

namespace Kolokwium._2
{
    //Zadanie1

    public class Piosenka
    {
        private int _glosy;
        private string _nazwa;

        public int Glosy
        {
            get => _glosy;
            set => _glosy = value;
        }

        public string Nazwa
        {
            get => _nazwa;
            set => _nazwa = value;
        }

        public Piosenka(int glosy, string nazwa)
        {
            Glosy = glosy;
            Nazwa = nazwa;
        }
    }
    
    //Zadanie2
    interface IUrzadzenieElektryczne
    {
        void Zasilaj();
        int Moc();
    }

    public class Zarowka : IUrzadzenieElektryczne
    {
        public void Zasilaj()
        {
            Console.WriteLine("Świeci!!");
        }

        public int Moc()
        {
            return 50;
        }
    }

    public class Zelazko : IUrzadzenieElektryczne
    {
        public int temperatura = 0;
        public void Zasilaj()
        {
            temperatura += 20;
            if (temperatura > 150)
            {
                temperatura = 150;
            }
            Console.WriteLine(temperatura);
        }

        public int Moc()
        {
            return 1000;
        }
    }
    
    //Zadanie3

    public class KrewEventArgs : EventArgs
    {
        private string _grupaKrwi;

        public string GrupaKrwi
        {
            get => _grupaKrwi;
            set => _grupaKrwi = value;
        }
    }

    public class StacjaKrwiodastwa
    { 
        public event EventHandler<KrewEventArgs> OddanoKrew;
        public void oddanoKrew(BankKrwi krew)
        {
            OddanoKrew += krew.BankKrwi_OddanoKrew;
            OddanoKrew?.Invoke(this, new KrewEventArgs(){GrupaKrwi = krew.GrupaKrwi});
            OddanoKrew -= krew.BankKrwi_OddanoKrew;
        }
    }

    public class Szpital
    {
        public event EventHandler<KrewEventArgs> PotrzebnaKrew;

        public void potrzebnaKrew(BankKrwi krew)
        {
            PotrzebnaKrew += krew.BankKrwi_PotrzebnaKrew;
            PotrzebnaKrew?.Invoke(this, new KrewEventArgs(){GrupaKrwi = krew.GrupaKrwi});
            PotrzebnaKrew -= krew.BankKrwi_PotrzebnaKrew;
        }
        
        public void Szpital_BrakKrwi(object sender, KrewEventArgs e)
        {
            Console.WriteLine($"Brak krwi z grupy: {e.GrupaKrwi}");
        }
    }
    
    public class BankKrwi
    {
        public string GrupaKrwi;
        public int IloscKrwi = 0;
        public event EventHandler <KrewEventArgs> BrakKrwi;

        public void brakKrwi(string krew)
        {
            BrakKrwi?.Invoke(this, new KrewEventArgs(){GrupaKrwi = krew});
        }
        public void BankKrwi_OddanoKrew(object sender, EventArgs e)
        {
            IloscKrwi++;
            Console.WriteLine("Oddano Krew:" + GrupaKrwi + " Ilosć: " + IloscKrwi);
        }
        
        public void BankKrwi_PotrzebnaKrew(object sender, EventArgs e)
        {
            if (IloscKrwi == 0)
            {
                brakKrwi(GrupaKrwi);
            }
            else
            {
                Console.WriteLine("Potrzebna Krew: " + GrupaKrwi + " Ilosć: " + IloscKrwi); 
                IloscKrwi--;
            }
        }
    }
    
    class Program
    {
        static void Glosowanie(List<int> glosy)
        {


            for (int i = 0; i < glosy.Count; i++)
            {
                glosy[i] = (int)(glosy[i] - (glosy[i] * 0.1));
            }



            Dictionary<int, Piosenka> a = new Dictionary<int, Piosenka>();

            a.Add(1, new Piosenka(glosy[0], "Piosenka 1"));
            a.Add(2, new Piosenka(glosy[1], "Piosenka 2"));
            a.Add(3, new Piosenka(glosy[2], "Piosenka 3"));
            a.Add(4, new Piosenka(glosy[3], "Piosenka 4"));
            a.Add(5, new Piosenka(glosy[4], "Piosenka 5"));
            a.Add(6, new Piosenka(glosy[5], "Piosenka 6"));
            a.Add(7, new Piosenka(glosy[6], "Piosenka 7"));
            a.Add(8, new Piosenka(glosy[7], "Piosenka 8"));
            a.Add(9, new Piosenka(glosy[8], "Piosenka 9"));
            a.Add(10, new Piosenka(glosy[9], "Piosenka 10"));

            var b = a.OrderByDescending(x => x.Value.Glosy);

            foreach (var item in b)
            {
                Console.WriteLine($"Nazwa: {item.Value.Nazwa} Głosów: {item.Value.Glosy}");
            }
        }
        
        static void Main(string[] args)
        {
            //Zadanie1
            //
            // List<int> glosy = new List<int>();
            //
            // glosy.Add(51);
            // glosy.Add(65);
            // glosy.Add(86);
            // glosy.Add(92);
            // glosy.Add(51);
            // glosy.Add(55);
            // glosy.Add(52);
            // glosy.Add(15);
            // glosy.Add(353);
            // glosy.Add(656);
            //
            // Glosowanie(glosy);
            
            //Zadanie2

            //int moc_lacz = 0;

            // List<IUrzadzenieElektryczne> urzadzenia = new List<IUrzadzenieElektryczne>();
            // urzadzenia.Add(new Zarowka());
            // urzadzenia.Add(new Zelazko());
            // urzadzenia.Add(new Zarowka());
            // urzadzenia.Add(new Zelazko());

            // for (int i = 0; i < 10; i++)
            // {
            //     foreach (var value in urzadzenia)
            //     {
            //         value.Zasilaj();
            //         moc_lacz += value.Moc();
            //     }
            //
            //     Console.WriteLine(moc_lacz);
            //     moc_lacz = 0;
            // }
            
            //Zadanie3

            var stacja = new StacjaKrwiodastwa();
            var rhplus = new BankKrwi();
            var rhminus = new BankKrwi();
            var szpital = new Szpital();
            

            rhminus.GrupaKrwi = "RH-";
            rhplus.GrupaKrwi = "RH+";
            

            stacja.OddanoKrew += rhminus.BankKrwi_OddanoKrew;
            szpital.PotrzebnaKrew += rhminus.BankKrwi_PotrzebnaKrew;
            
            
            
            stacja.oddanoKrew(rhminus);
            szpital.potrzebnaKrew(rhminus);
            szpital.potrzebnaKrew(rhminus);
            

        }
    }
}