﻿using System;
using static System.Console;

namespace LuhninAlgoritmi
{
    class Program
    {
        static void Main(string[] args)
        {
            //muuttujia
            string syote;
            bool status = true;
            bool onkoOikein = true;
            int laskuriVaarin = 0;
            int laskuriOikein = 0;
            //ohjelma alkaa
            while (true)
            {
                Write("Anna numerosarja: ");

                syote = (ReadLine());
                // tyhjällä lopetetaan 
                if (syote == "")
                {
                    break;
                }
                //lähetetään syote tarkistettavaksi
                bool status1 = TarkistaSyote(syote, status);
                              
                //jatketaan tarkistamaan luhninlauseen todenmukaisuutta mikäli syote sisältää vain numeroita
                if (status1 == true)
                {
                    //tarkistetaan vastaako syote luhninalgoritmia ja palautetaan bool arvo
                    onkoOikein = TarkistusNumero(syote, onkoOikein);
                    if(onkoOikein == true)
                    {
                        laskuriOikein = laskuriOikein + 1;
                        WriteLine($"syote on kelvollinen numerosarja");
                    }
                    else
                    {
                        laskuriVaarin = laskuriVaarin + 1;
                        WriteLine($"syote ei ole kelvollinen numerosarja");
                    }
                    
                }
                //jos syoteesta annettu arvo ei täytä vaatimuksia palataan while lauseen alkuun suorittamaan sitä uudelleen.
                else
                {
                    WriteLine("syöte ei ole numerosarja");
                }
            }
            WriteLine($"Kelvollisia numerosarjoja {laskuriOikein} kpl.");
            WriteLine($"Virheellisiä numerosarjoja {laskuriVaarin} kpl.");
        }
        //Tässä metodissa tarkistetaan onko syöte luhnin algoritmin mukainen
         static bool TarkistusNumero(string syote, bool onkoOikein)
        {
            //muuttujia
            bool vaihde = true;
            int luku2;
            int summa = 0, numero = 0;
            //otetaan merkkijonosta viimeinen kirjain talteen uuteen string muuttujaan
            string syotteenvikakirjain = syote.Substring(syote.Length - 1);
            //käydään kaikki merkit läpi ja kerrotaan ne halutuilla luvuilla    
            for (int u = syote.Length - 2; u >= 0 ; u--)
            {
                int.TryParse(syote[u].ToString(), out numero);
                
                //aloitetaan laskenta toiseksi viimeisestä luvusta alaspäin ja vaihdetaan aina kerrointa vaihtaessa lukua. Totuusarvolla -vaihde- muutetaan aina kertojaa 
                if ((u >= 0) && (vaihde == true))
                {
                    vaihde = false;
                    numero = numero * 2;
                    //jos luku menee yli 10, vähennetään luvusta 9 (7*7 = 14 -> 1+4 = 5 tai 7 * 7 = 14 - 9 = 5) 
                    if (numero > 9)
                    {
                        numero = numero - 9;                     
                    }                                   
                }
                //tässä vaihdetaan taas bool vaihde trueksi jotta seuraavalla kierroksella katsotaan seuraava luku eri kertoimella
                else
                {
                    vaihde = true;
                    numero = numero * 1;                                    
                }
                
                summa = summa + numero;             
            }
            //muutetaan syotteen viimeinen kirjain luvuksi
            int.TryParse(syotteenvikakirjain, out luku2);
            //tarkistetaan luvun jaollisuus ja palautetaan sen mukainen arvo
            if ((luku2 + summa) % 10 == 0)
            {
                onkoOikein = true;
                return onkoOikein;
            }
            else {               
                onkoOikein = false;
                return onkoOikein;
            }                           
        }

        //Tässä metodissa tarkistetaan onko syötteessä muita merkkejä kuin numeroita
        static bool TarkistaSyote(string syote, bool status)
        {
            
            for (int i = 0; i < syote.Length; i++)
            {
                //tarkistetaan sisältääkö syote jonkun näistä numeroista. Jos sisältää jatketaan tutkimista
                if (syote[i] == '0' || syote[i] == '1' || syote[i] == '2' || syote[i] == '3' || syote[i] == '4' || syote[i] == '5' || syote[i] == '6' || syote[i] == '7' || syote[i] == '8' || syote[i] == '9')
                {
                    continue;
                }
                //jos syote sisältää jonkin muun arvon kuin numeron muutetaan statuksen arvo falseksi ja palautetaan se kutsujalle
                else
                {
                    status = false;
                    return status;
                }                         
            }
            return status;    
        }
    }
}
