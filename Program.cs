using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Conversii_date


{
    using System;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Introduceti numarul in virgula fixa:");
            string numarInput = Console.ReadLine();

            Console.WriteLine("Introduceti baza de plecare (intre 2 si 16):");
            int baza1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti baza de sosire (intre 2 si 16):");
            int baza2 = int.Parse(Console.ReadLine());

            if (baza1 < 2 || baza1 > 16 || baza2 < 2 || baza2 > 16)
            {
                Console.WriteLine("Bazele trebuie sa fie intre 2 si 16.");
                return;
            }

            string rezultat = ConversieBazaCuVirgulaFixa(numarInput, baza1, baza2);

            Console.WriteLine($"Rezultatul: {rezultat}");
        }

        static string ConversieBazaCuVirgulaFixa(string numar, int baza1, int baza2)
        {
            try
            {
                string[] parti = numar.Split('.');
                int parteIntreagaBaza10 = Convert.ToInt32(parti[0], baza1);

                double parteZecimalaBaza10 = 0;
                if (parti.Length == 2)
                {
                    parteZecimalaBaza10 = ConvertParteZecimalaLaBaza10(parti[1], baza1);
                }
                string parteIntreagaBaza2 = Convert.ToString(parteIntreagaBaza10, baza2);
                string parteZecimalaBaza2 = "";
                if (parti.Length == 2)
                {
                    parteZecimalaBaza2 = ConvertParteZecimalaLaBaza2(parteZecimalaBaza10, baza2);
                }

                if (parti.Length == 1)
                {
                    return parteIntreagaBaza2;
                }
                else
                {
                    return $"{parteIntreagaBaza2}.{parteZecimalaBaza2}";
                }
            }
            catch (FormatException)
            {
                return "Numarul introdus nu este valid.";
            }
        }

        static double ConvertParteZecimalaLaBaza10(string parteZecimala, int baza1)
        {
            double rezultat = 0;
            for (int i = 0; i < parteZecimala.Length; i++)
            {
                int cifra = CharToDigit(parteZecimala[i]);
                rezultat += cifra / Math.Pow(baza1, i + 1);
            }
            return rezultat;
        }

        static string ConvertParteZecimalaLaBaza2(double parteZecimalaBaza10, int baza2)
        {
            string rezultat = "";
            for (int i = 0; i < 12; i++) 
            {
                parteZecimalaBaza10 *= baza2;
                int cifra = (int)parteZecimalaBaza10;
                rezultat += DigitToChar(cifra);
                parteZecimalaBaza10 -= cifra;
            }
            return rezultat;
        }

        static int CharToDigit(char cifra)
        {
            if (char.IsDigit(cifra))
            {
                return cifra - '0';
            }
            else
            {
                return char.ToUpper(cifra) - 'A' + 10;
            }
        }

        static char DigitToChar(int digit)
        {
            if (digit < 10)
            {
                return (char)(digit + '0');
            }
            else
            {
                return (char)(digit - 10 + 'A');
            }
        }
    }
}



