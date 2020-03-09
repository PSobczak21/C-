using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSimulator2019
{
    class Program
    {
        private static readonly Random getrandom = new Random();
        private static readonly Random zdarzenie = new Random();
        private static readonly Random klient = new Random();
        private static readonly Random czas = new Random();
        public static int GetRandomNumber()
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(1,4);
            }
        }
        public static int losujZdarzenie()
        {
            lock (zdarzenie) // synchronize
            {
                return zdarzenie.Next(1, 5);
            }
        }
        static string losujStandard()
        {

            if (GetRandomNumber() == 1)
            {
                return "niski";

            }
            else if (GetRandomNumber() == 2)
            {
                return "sredni";
            }
            else if (GetRandomNumber() == 3)
            {
                return "wysoki";
            }
            else
            {
                return "luksja";
            }


        }
        public static int losujLiczbe()
        {
            Random liczba = new Random();
            int losowa = liczba.Next(1, 3);
            return losowa;
        }
        public static int losuj47()
        {
            lock (klient) // synchronize
            {
                return klient.Next(1, 46);
            }
        }
        public static int losujczas()
        {
            
            return czas.Next(4,15);
        }

        static void Main(string[] args)
        {
            //Utworzenie wszystkich potrzebnych obiektów i uruchomienie podstawowej pętli programu
            int wolnePokoje = 0;
            int zajetePokoje = 0;
            int tura = 0;
            string opcja;
            
            //46 imion
            string[] imiona = { "Antek", "Bartek", "Cezary", "Damian","Edward", "Franek","Grzegorz","Henryk","Ignacy","Janek", "Krzysztof","Leszek","Lukasz","Maciej","Norbert","Olek","Pawel","Robert","Sebastian","Tomek","Urban","Wladek","Zbigniew","Aneta","Beata","Cecylia","Dominika","Elzbieta","Faustyna","Grazyna","Halina","Iza","Janina","Kazimiera","Laura","Lucja","Natalia","Marta","Ola","Patrycja","Renata","Sandra","Tamara","Ula","Wiktoria","Zosia"};
            List<Klient> Klienci = new List<Klient>();
            for (int i = 1; i <= 45; i++)
            {
                Klienci.Add(new Klient(i, imiona[i], losujStandard(), losujczas()));
            }
            List<Pokoj> ListaPokoi = new List<Pokoj>();
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    int numer = int.Parse(i.ToString() + j.ToString());
                    ListaPokoi.Add(new Pokoj(numer, losujStandard()));

                }
            }
            List<Boj> Boje = new List<Boj>();
            for (int i = 1; i <= 3; i++)
            {
                Boje.Add(new Boj(i));
            }
            Console.WriteLine("=|_|Hotel Simulator 2019 logo|_|=");
            do
            {

                switch (losujZdarzenie())
                {
                    case 1:
                        menu();
                        break;
                    case 2:
                    case 3:
                    case 4:
                        nowyKlient();
                        break;
                    default:
                        menu();
                        break;
                }
            } while (true);
            //Wyświetla listę pokoi
            void wyswielListe()
            {
                Console.WriteLine("Lista Pokoi: ");
                foreach (var Pokoj in ListaPokoi)
                {
                    
                    if (Pokoj.przydzielenie == true)
                    {
                        Console.WriteLine(Pokoj.numerpokoju + "; Standard:" + Pokoj.standard + "; Przydzielony Klient: " + Pokoj.przydzielonyklient+"; Pozostaly czas: "+Pokoj.czasZajecia);
                    }
                    else
                    {
                        Console.WriteLine(Pokoj.numerpokoju + "; Standard:" + Pokoj.standard + "; Pokój wolny; Brud: " + Pokoj.poziomSyfu);
                    }
                    Console.WriteLine(" ");
                }
            }
            //Nowy klient
            void nowyKlient()
            {
                foreach (var klient in Klienci.FindAll(x => x.numerKlienta == losuj47()))
                {

                    if (klient.przydzielony == true)
                    {
                        losujLiczbe();
                        
                    }
                    
                        string wpiszNumer;
                    //Przychodzi klient i mówi czego potrzebuje
                    Console.WriteLine("------------------------------------\nPrzyszedł klient: " + klient.Imie);
                    Console.WriteLine(klient.Imie + " potrzebuje pokój o standardzie " + klient.wymaganyStandard + " na " + klient.potrzebnyCzas + " t");
                    //Wybieramy co zrobić z klientem
                    do
                    {
                        Console.WriteLine("------------------------------------\nWybierz opcję:\n1. Przydziel klientowi pokój\n2. Wyświetl dostępne pokoje o wymaganym standardzie\n3. Wygon klienta");
                        opcja = Console.ReadLine();
                        int.TryParse(opcja, out int wybranaOpcja);
                        switch (wybranaOpcja)
                        {
                            case 1:
                                Console.Write("Wpisz numer pokoju: ");
                                wpiszNumer = Console.ReadLine();
                                int.TryParse(wpiszNumer, out int wpisanyNumer);

                                foreach (var Pokoj in ListaPokoi.FindAll(x => x.numerpokoju == wpisanyNumer))
                                {
                                    if (klient.wymaganyStandard == Pokoj.standard && Pokoj.przydzielenie == false && Pokoj.poziomSyfu==0)
                                    {
                                        //klient.przydzielonypokoj = Pokoj.numerpokoju;
                                        //klient.przydzielony=true;
                                        klient.przydzielDoPokoju(Pokoj.numerpokoju);
                                        //Pokoj.przydzielonyklient = klient.Imie;
                                        //Pokoj.przydzielenie = true;
                                        //Pokoj.czasZajecia = klient.potrzebnyCzas;
                                        //Pokoj.poziomSyfu = losujLiczbe();
                                        Pokoj.przydzielKlienta(klient.Imie, klient.potrzebnyCzas);
                                        break;
                                    }
                                    else if (Pokoj.przydzielenie == true)
                                    {
                                        Console.WriteLine("Ten pokój jest zajęty");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Klient nie chce tego pokoju.");
                                        if (Pokoj.poziomSyfu>0)
                                        { Console.WriteLine("Pokój jest brudny"); }
                                    }
                                }
                                break;
                            case 2:
                                //Wyświetla pokoje, które mogą interesować klienta
                                foreach (var Pokoj in ListaPokoi.FindAll(x => x.standard == klient.wymaganyStandard && x.przydzielenie == false && x.poziomSyfu==0))
                                {
                                    Console.WriteLine(Pokoj.numerpokoju + " " + Pokoj.standard);
                                }
                                break;
                            case 3:
                                klient.przydzielony = true;
                                Console.WriteLine("Zdenerwowany " + klient.Imie + " wychodzi");
                                break;
                            default:
                                Console.WriteLine("Nie ma takiej opcji! Wybierz jeszcze raz.");
                                break;
                        }

                        if (klient.przydzielony != false)
                            break;


                    } while (true);
                    Tura(); 
                    break;
                }
            }
            
            
            
            //menu
            void menu()
            {
                do
                {
                    Console.WriteLine("------------------------------------\n1. Wyswietl pokoje\n2. Zarzadzenie bojami\n3. Zakoncz ture");
                    Console.WriteLine("Tura: " + tura + " ; Zajete pokoje: " + liczZajetePokoje() + " ; Wolne pokoje: " + liczWolnePokoje()); ; ;
                    Console.Write("Wybierz opcje: ");
                    opcja = Console.ReadLine();
                    int.TryParse(opcja, out int wybranaOpcja);
                    switch (wybranaOpcja)
                    {
                        case 1:
                            wyswielListe();
                            break;
                        case 2:
                            Console.WriteLine("------------------------------------\n1. Wyswietl bojow\n2. Przydziel boja do pokoju\n>=3. Powrot do menu");
                            opcja = Console.ReadLine();
                            int.TryParse(opcja, out int opcja2);
                            switch (opcja2)
                            {
                                case 1:
                                    wyswietlBojow();
                                    break;
                                case 2: 
                                    Console.WriteLine("Wybierz boja ktorym chcesz zarzadzać: ");
                                    wyswietlBojow();
                                    Console.Write("Wybierz boja: ");
                                    string wpiszNumerBoja = Console.ReadLine();
                                    int.TryParse(wpiszNumerBoja, out int wpisanyNumerBoja);
                                    Console.WriteLine("Wybierz pokoj do posprzatania: ");
                                    foreach (var Pokoj in ListaPokoi.FindAll(x=>x.poziomSyfu>0))
                                    {
                                        wyswielListe();
                                    }
                                    Console.Write("Wybierz pokoj: ");
                                    string wpiszNumerPokoju = Console.ReadLine();
                                    int.TryParse(wpiszNumerPokoju, out int wpisanyNumerPokoju);
                                    przydzielBoja(wpisanyNumerPokoju,wpisanyNumerBoja);
                                    break;
                                default:
                                    Console.WriteLine("Powrot do menu");
                                    break;
                            }
                            break;
                        case 3:
                            wybranaOpcja = 4;
                            Tura();
                            break;
                        default:
                            Console.WriteLine("Nie ma takiej opcji!");
                            break;
                    }
                    if (wybranaOpcja == 4)
                        break;
                } while (true);
            }
            //Wyświetla listę Bojów
            void wyswietlBojow()
            {
                foreach (var Boj in Boje)
                {
                    Boj.daneBoja();
                }
            }
            //Przydzielenie boja do sprzątania pokoju
            void przydzielBoja(int wybor, int wybranyBoj)
            {
                foreach (var Pokoj in ListaPokoi.FindAll(x=>x.numerpokoju==wybor))
                {
                    Pokoj.PrzydzielBoja(wybranyBoj);
                }
                foreach (var Boj in Boje.FindAll(x => x.numer == wybranyBoj))
                {
                    Boj.przydzielBoja(wybor, wybranyBoj);
                }
            }
            
            int liczZajetePokoje()
            {
                
                zajetePokoje = 0;
                foreach (var Pokoj in ListaPokoi.FindAll(x => x.przydzielenie == true))
                {
                    zajetePokoje++;
                }
                return zajetePokoje;
            }
            int liczWolnePokoje()
            {
                wolnePokoje = 0;
                
                foreach (var Pokoj in ListaPokoi.FindAll(x => x.przydzielenie == false))
                {
                    wolnePokoje++;
                }
                return wolnePokoje;
            }
            //sprawdzenie czy pokoje są już wolne i czy boje już są wolni
            void Tura()
            {
                tura++;
                foreach(var Pokoj in ListaPokoi)
                {
                    if (Pokoj.czasZajecia > 1)
                    {
                        Pokoj.czasZajecia--;
                    }
                    else if(Pokoj.czasZajecia == 1)
                    {
                        Pokoj.zwolnijPokoj();
                        Console.WriteLine("=================================\nZwolnil sie pokoj: " + Pokoj.numerpokoju);
                    }

                    if (Pokoj.poziomSyfu > 1 && Pokoj.sprzatanie == true)
                    {
                        Pokoj.poziomSyfu--;
                    }
                    else if (Pokoj.poziomSyfu == 1&& Pokoj.sprzatanie==true)
                    {
                        Pokoj.zwolnijBoja();
                        Console.WriteLine("=================================\nBoj nr "+Pokoj.przydzielonyBoj+" skonczyl sprzatac pokoj nr "+Pokoj.numerpokoju);
                    }


                }
                foreach (var Boj in Boje)
                {
                    if (Boj.czasZajecia > 1)
                    {
                        Boj.czasZajecia--;

                    }
                    else if (Boj.czasZajecia == 1)
                    {
                        Boj.zwolnijBoja();
                    }
                }
                foreach (var Klient in Klienci)
                {
                    if (Klient.czasZajecia > 1)
                    {
                        Klient.czasZajecia--;
                    }
                    else if (Klient.czasZajecia==1)
                    {
                        Klient.zwolnijPokoj();
                    }
                }
            }
            

          

            Console.ReadKey();
        }
        

    }
}
