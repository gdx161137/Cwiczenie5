using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenie5
{
    internal class Metody
    {
        public static List<Osoba> WczytajOsobyZPliku(string filePath)
        {
            List<Osoba> osoby = new List<Osoba>();

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string linia;
                    while ((linia = sr.ReadLine()) != null)
                    {
                        string[] czesci = linia.Split(';');
                        if (czesci.Length == 3)
                        {
                            osoby.Add(new Osoba
                            {
                                Imie = czesci[0],
                                Wiek = int.Parse(czesci[1]),
                                Adres = czesci[2]
                            });
                        }
                    }
                }
            }
            return osoby;
        }

        public static void DodajOsobe(List<Osoba> osoby)
        {
            Console.WriteLine("Podaj imię:");
            string imie = Console.ReadLine();

            Console.WriteLine("Podaj wiek:");
            int wiek;
            while (!int.TryParse(Console.ReadLine(), out wiek) || wiek <= 0)
            {
                Console.WriteLine("Wiek musi być liczbą dodatnią.");
            }

            Console.WriteLine("Podaj adres:");
            string adres = Console.ReadLine();

            osoby.Add(new Osoba
            {
                Imie = imie,
                Wiek = wiek,
                Adres = adres
            });

            Console.WriteLine("Osoba została dodana.");
        }

        public static void WyswietlOsoby(List<Osoba> osoby)
        {
            Console.WriteLine("Lista osób:");
            foreach (Osoba osoba in osoby)
            {
                Console.WriteLine($"Imię: {osoba.Imie}, Wiek: {osoba.Wiek}, Adres: {osoba.Adres}");
            }
        }
        public static void ZapiszOsobyDoPliku(List<Osoba> osoby, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (Osoba osoba in osoby)
                {
                    sw.WriteLine($"{osoba.Imie};{osoba.Wiek};{osoba.Adres}");
                }
            }
        }
    }
}
