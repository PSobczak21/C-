using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSimulator2019
{
    public class Klient
    {
        public string Imie;
        public string wymaganyStandard;
        public int potrzebnyCzas;
        public int przydzielonypokoj;
        public int numerKlienta;
        public bool przydzielony;
        public int czasZajecia;
       
        public Klient()
        {
            Imie = string.Empty;
            wymaganyStandard = string.Empty;
            potrzebnyCzas = 0;
            przydzielonypokoj = 0;
            numerKlienta = 0;
            przydzielony = false;
            czasZajecia = 0;
            
            

        }
        public Klient(int numer, string Imie, string wymaganyStandard, int potrzebnyCzas) :this()
        {
            this.Imie = Imie;
            this.wymaganyStandard = wymaganyStandard;
            this.potrzebnyCzas = potrzebnyCzas;
            this.numerKlienta = numer;
            
            


        }
        public void przydzielDoPokoju(int numerPokoju)
        {
            czasZajecia = potrzebnyCzas+1;
            przydzielonypokoj = numerPokoju;
            przydzielony = true;
        }
        public void zwolnijPokoj()
        {
            czasZajecia = 0;
            przydzielonypokoj = 0;
            przydzielony = false;

        }




    }
}
