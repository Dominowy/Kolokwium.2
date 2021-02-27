using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Poprawa
{
    //Zadanie1
    
    public class Ankieta
    {
        public List<Sekcja> sekcje = new List<Sekcja>();

        public Ankieta(Sekcja _sekcja)
        {
            foreach (var var in sekcje)
            {
                
            }
        }
    }

    public class Sekcja
    {
        public List<Pytanie> pytania = new List<Pytanie>();

        public Sekcja(Pytanie _pytania)
        {
            pytania.Add(new Pytanie(_pytania.tresc, _pytania.typ, _pytania.czyOdpowiedziano));
        }
    }

    public class Pytanie
    {
        public string tresc { get; set; }
        public string typ { get; set; }
        public bool czyOdpowiedziano { get; set; }

        public Pytanie(string _tresc, string _typ, bool _czOdpowiedziano)
        {
            tresc = _tresc;
            typ = _typ;
            czyOdpowiedziano = _czOdpowiedziano;
        }
    }
    
    //Zadanie2

    public interface IOsiagniecia
    {
        bool Sprawdz(Gracz gracz);
    }
    
    public class Gracz
    {
        public string nazwa { get; set; }
        public int punkty { get; set; }
        public DateTime czas { get; set; }

        public List<IOsiagniecia> osiagniecia = new List<IOsiagniecia>();
        
        public void Skanuj()
        {
            
        }
    }

    public class HighScore : IOsiagniecia
    {
        public bool Sprawdz(Gracz gracz)
        {
            if (gracz.punkty < 10000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class DoswiadocznyGracz : IOsiagniecia
    {
        public bool Sprawdz(Gracz gracz)
        {
            if ((gracz.czas.Year)-(DateTime.Now.Year-1) < 1 )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class PrawdziwyMistrz : IOsiagniecia
    {
        public bool Sprawdz(Gracz gracz)
        {
            throw new NotImplementedException();
        }
    }
    
    //Zadanie3

    
    class Program
    {
        static void Main(string[] args)
        {
            //Zadanie1

            List<Pytanie> p = new List<Pytanie>();
            
            p.Add(new Pytanie("Pytanie", "Zadanie", false));
            p.Add(new Pytanie("Pytanie", "Zadanie", false));
            p.Add(new Pytanie("Pytanie", "Zadanie", false));
            
            List<Pytanie> p1 = new List<Pytanie>();
            
            p1.Add(new Pytanie("Pytanie", "Zadanie", false));
            p1.Add(new Pytanie("Pytanie", "Zadanie", false));
            p1.Add(new Pytanie("Pytanie", "Zadanie", false));
            
            List<Pytanie> p2 = new List<Pytanie>();
            
            p2.Add(new Pytanie("Pytanie", "Zadanie", false));
            p2.Add(new Pytanie("Pytanie", "Zadanie", false));
            p2.Add(new Pytanie("Pytanie", "Zadanie", false));
            
            
           


        }
    }
}