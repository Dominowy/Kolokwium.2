﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Linq;

namespace Kolokwium._2
{
    //Zadanie1

    public class Piosenka
    {
        public int Glosy {get; set;}

        public string Nazwa {get; set;}

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
        public string grupaKrwi { get; set; }
    }

    public class StacjaKrwiodastwa
    { 
        public event EventHandler<KrewEventArgs> OddanoKrew;
        public void oddanoKrew(string krew)
        {
            OddanoKrew?.Invoke(this, new KrewEventArgs(){grupaKrwi = krew});
        }
    }

    public class Szpital
    {
        public event EventHandler<KrewEventArgs> PotrzebnaKrew;

        public void potrzebnaKrew(string krew)
        {
            PotrzebnaKrew?.Invoke(this, new KrewEventArgs(){grupaKrwi = krew});
        }
        
        public void Szpital_BrakKrwi(object sender, KrewEventArgs e)
        {
            Console.WriteLine($"Brak krwi z grupy: {e.grupaKrwi}");
        }
    }
    
    public class BankKrwi
    {
        public string grupaKrwi;
        public int iloscA;
        public int iloscB;
        public int iloscAB;
        public int ilosc0;
        
        public event EventHandler <KrewEventArgs> BrakKrwi;
        
        public void brakKrwi(string krew)
        {
            BrakKrwi?.Invoke(this, new KrewEventArgs(){grupaKrwi = krew});
        }
        
        public void BankKrwi_OddanoKrew(object sender, KrewEventArgs e)
        {
            if (e.grupaKrwi == "A")
            {
                iloscA++;
                Console.WriteLine("Oddano Krew" + e.grupaKrwi + " Ilosć: " + iloscA);
            }
            else if (e.grupaKrwi == "B")
            {
                iloscB++;
                Console.WriteLine("Oddano Krew" + e.grupaKrwi + " Ilosć: " + iloscB);
            }
            else if (e.grupaKrwi == "AB")
            {
                iloscAB++;
                Console.WriteLine("Oddano Krew" + e.grupaKrwi + " Ilosć: " + iloscAB);
            }
            else if (e.grupaKrwi == "0")
            {
                ilosc0++;
                Console.WriteLine("Oddano Krew" + e.grupaKrwi + " Ilosć: " + ilosc0);
            }
        }
        
        public void BankKrwi_PotrzebnaKrew(object sender, KrewEventArgs e)
        { 
            if (e.grupaKrwi == "A")
            { 
                if (iloscA == 0)
                { 
                    Console.WriteLine("Ilość Krwi z grupy " + e.grupaKrwi + ": " + iloscA); 
                    brakKrwi(e.grupaKrwi);
                }
                else 
                { 
                    iloscA--; 
                    Console.WriteLine("Potrzebna Krew " + e.grupaKrwi + " Ilosć: " + iloscA);
                }
            }
            else if (e.grupaKrwi == "B") 
            { 
                if (iloscB == 0) 
                { 
                    Console.WriteLine("Ilość Krwi z grupy: " + e.grupaKrwi + ": " + iloscB); 
                    brakKrwi(e.grupaKrwi);
                }
                else 
                { 
                    iloscB--; 
                    Console.WriteLine("Potrzebna Krew " + e.grupaKrwi + " Ilosć: " + iloscB);
                }
            }
            else if (e.grupaKrwi == "AB") 
            {
                if (iloscAB == 0) 
                { 
                    Console.WriteLine("Ilość Krwi z grupy " + e.grupaKrwi + ": " + iloscAB); 
                    brakKrwi(e.grupaKrwi);
                }
                else 
                { 
                    iloscAB--; 
                    Console.WriteLine("Potrzebna Krew " + e.grupaKrwi + " Ilosć: " + iloscAB);
                }
            }
            else if (e.grupaKrwi == "0") 
            { 
                if (ilosc0 == 0) 
                { 
                    Console.WriteLine("Ilość Krwi z grupy " + e.grupaKrwi + ": " + ilosc0); 
                    brakKrwi(e.grupaKrwi);
                }
                else 
                { 
                    ilosc0--; 
                    Console.WriteLine("Potrzebna Krew " + e.grupaKrwi + " Ilosć: " + ilosc0); 
                }
            }
        }
    }
    
    class Program
    {
        static void Glosowanie(List<int> glosy, Dictionary<int, Piosenka> piosenka)
        {


            for (int i = 0; i < glosy.Count; i++)
            {
                piosenka[i].Glosy = (int)(piosenka[i].Glosy - (piosenka[i].Glosy * 0.1));
                piosenka[i].Glosy = piosenka[i].Glosy + glosy[i];
            }
            
            var b = piosenka.OrderByDescending(x => x.Value.Glosy);

            foreach (var item in b)
            {
                Console.WriteLine($"Nazwa: {item.Value.Nazwa} Głosów: {item.Value.Glosy}");
            }
        }
        
        static void Main(string[] args)
        {
             //Zadanie1
            
             List<int> glosy = new List<int>();
            
             glosy.Add(51);
             glosy.Add(65);
             glosy.Add(86);
             glosy.Add(92);
             glosy.Add(51);
             glosy.Add(55);
             glosy.Add(52);
             glosy.Add(15);
             glosy.Add(353);
             glosy.Add(656);
            
             Dictionary<int, Piosenka> a = new Dictionary<int, Piosenka>();
            
             a.Add(0, new Piosenka(0, "Piosenka 1"));
             a.Add(1, new Piosenka(0, "Piosenka 2"));
             a.Add(2, new Piosenka(0, "Piosenka 3"));
             a.Add(3, new Piosenka(0, "Piosenka 4"));
             a.Add(4, new Piosenka(0, "Piosenka 5"));
             a.Add(5, new Piosenka(0, "Piosenka 6"));
             a.Add(6, new Piosenka(0, "Piosenka 7"));
             a.Add(7, new Piosenka(0, "Piosenka 8"));
             a.Add(8, new Piosenka(0, "Piosenka 9"));
             a.Add(9, new Piosenka(0, "Piosenka 10"));
            
             Glosowanie(glosy, a);
             Glosowanie(glosy, a);
             Glosowanie(glosy, a);
             Glosowanie(glosy, a);
            
            
             foreach (var item in a)
             {
                 Console.WriteLine($"Nazwa: {item.Value.Nazwa} Głosów: {item.Value.Glosy}");
             }
            
             // //Zadanie2
            
             int moc_lacz = 0;
            
              List<IUrzadzenieElektryczne> urzadzenia = new List<IUrzadzenieElektryczne>();
              urzadzenia.Add(new Zarowka());
              urzadzenia.Add(new Zelazko());
              urzadzenia.Add(new Zarowka());
              urzadzenia.Add(new Zelazko());
            
              for (int i = 0; i < 10; i++)
              {
                  foreach (var value in urzadzenia)
                  {
                      value.Zasilaj();
                      moc_lacz += value.Moc();
                  }
            
                  Console.WriteLine(moc_lacz);
                  moc_lacz = 0;
              }
            
            //Zadanie3

            
            var stacja = new StacjaKrwiodastwa();
            var bank = new BankKrwi();
            var szpital = new Szpital();
            
            szpital.PotrzebnaKrew += bank.BankKrwi_PotrzebnaKrew;
            bank.BrakKrwi += szpital.Szpital_BrakKrwi;
            stacja.OddanoKrew += bank.BankKrwi_OddanoKrew;
            
            stacja.oddanoKrew("A");
            stacja.oddanoKrew("A");
            stacja.oddanoKrew("A");
            szpital.potrzebnaKrew("A");
            szpital.potrzebnaKrew("A");
            szpital.potrzebnaKrew("A");
            szpital.potrzebnaKrew("A");
            
            stacja.oddanoKrew("0");
            stacja.oddanoKrew("0");
            stacja.oddanoKrew("0");
            stacja.oddanoKrew("0");
            stacja.oddanoKrew("0");
            szpital.potrzebnaKrew("0");
            szpital.potrzebnaKrew("0");
            szpital.potrzebnaKrew("0");
            szpital.potrzebnaKrew("0");
        }
    }
}