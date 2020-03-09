using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSimulator2019
{
    public class Pokoj
    {
         
         int numer;
       
         public string standard;
        public string przydzielonyklient;
        public bool przydzielenie;
        public int poziomSyfu;
          public int czasZajecia;
        public int przydzielonyBoj;
        public bool sprzatanie;
        
       
        public int numerpokoju
        {
            get
            {
                return numer;
            }
            set

            {
                if (true)
                {
                    numer = value;
                }
                else 
                {
                    throw new Exception("numer sie nie zgadza"); 
                }
                    
               
            }
        }
        public string standardpokoju
        {
            get
            {
                return standard;
            }
            set
            {
                
                standard = value;
            }
        }
        public Pokoj()
        {
            numerpokoju = 0;
            standardpokoju = string.Empty;
            poziomSyfu = 0;
            przydzielenie=false;
            czasZajecia=0;
            przydzielonyBoj = 0;
            sprzatanie = false;
        }
        public Pokoj(int numer, string standard) :this()
        {
            this.numerpokoju = numer;
            this.standardpokoju = standard;
        }
        public static int losujczas()
        {
            Random czas = new Random();
            return czas.Next(3, 12);
        }
        public void przydzielKlienta(string Imie, int czas)
        {
            przydzielonyklient = Imie;
            przydzielenie = true;
            czasZajecia = czas+1;
            poziomSyfu = losujczas();
        }
        public void zwolnijPokoj()
        {
            
            przydzielenie = false;
            czasZajecia = 0;
        }
        public void PrzydzielBoja(int przydzielonyBoj)
        {
            if (przydzielonyBoj > 3 || przydzielonyBoj < 1)
            {
                Console.WriteLine("Nie ma takiego Boja!");
            }
            else
            {
                sprzatanie = true;
                this.przydzielonyBoj = przydzielonyBoj;
                this.czasZajecia = this.poziomSyfu;
            }
        }
        public void zwolnijBoja()
        {
            sprzatanie = false;
            this.przydzielonyBoj = 0;
            czasZajecia = 0;
        }
       

    }
}
