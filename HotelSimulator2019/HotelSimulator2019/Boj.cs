using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSimulator2019
{
    class Boj
    {
        public int numer;
        public int sprzatanyPokoj;
        public bool zajetosc;
        public int czasZajecia;
        public Boj()
        {
            numer = 0;
            sprzatanyPokoj = 0;
            zajetosc = false;
        }
        public Boj(int numer) : this()
        {
            this.numer = numer;
        }
        public void daneBoja()
        {
            if (zajetosc == true)
            {
                Console.WriteLine("Numer: "+numer+" ; Sprzatany pokoj: "+sprzatanyPokoj);
            }
            else
            {
                Console.WriteLine("Numer: "+numer+" ; Ten boj jest teraz wolny");
            }
        }
        public void przydzielBoja(int sprzatanyPokoj, int czasZajecia)
        {
            if (this.zajetosc == false)
            {
                this.sprzatanyPokoj = sprzatanyPokoj;
                this.zajetosc = true;
                this.czasZajecia = czasZajecia;
            }
            else if (sprzatanyPokoj>24|| sprzatanyPokoj<1)
            {
                Console.WriteLine("Nie ma takiego pokoju!");
            }
            else
            {
                Console.WriteLine("Boj jest zajety!");
            }
        }
        public void zwolnijBoja()
        {
            sprzatanyPokoj = 0;
            zajetosc = false;
            czasZajecia = 0;
        }
    }
}
