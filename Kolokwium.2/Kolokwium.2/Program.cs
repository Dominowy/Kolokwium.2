using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kolokwium._2
{
    //Zadanie1

    
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
                Console.WriteLine("Wyłącz");
                temperatura = 0;
            }
            Console.WriteLine(temperatura);
        }

        public int Moc()
        {
            return 1000;
        }
    }
    
    //Zadanie3

    public class StacjaKrwiodawstwa
    {
        public event EventHandler OddanoKrew;

        public void oddanoKrew()
        {
            OddanoKrew.Invoke(this, EventArgs.Empty);
        }
    }

    public class Szpital
    {
        private string grupa;
        private event EventHandler PotrzebnaKrew;
        private event EventHandler BraKrwi;
        public void potrzebaKrwi(string group)
        {
            PotrzebnaKrew.Invoke(this, EventArgs.Empty);
        }

        public void braKrwi()
        {
            BraKrwi.Invoke(this, EventArgs.Empty);
            Console.WriteLine("Brak Krwi");
        }
    }

    public class BanKrwi
    {
        
    }
    
    class Program
    {
        
        static void Main(string[] args)
        {
            //Zadanie1

            List<string> utwory = new List<string>();
            utwory.Add("White Room");
            utwory.Add("Sunshine of your Love");
            utwory.Add("Brave");
            utwory.Add("Like a rolling");
            utwory.Add("Layla");
            
            

            //Zadanie2

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
        }
    }
}