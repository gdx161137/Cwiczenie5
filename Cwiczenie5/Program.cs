using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cwiczenie5;

namespace Cwiczenie5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\aaMag\\test.txt";
            List<Osoba> osoby = Metody.WczytajOsobyZPliku(filePath);

            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Dodaj nową osobę");
            Console.WriteLine("2. Wyświetl wszystkie osoby");
            string opcja = Console.ReadLine();

            switch (opcja)
            {
                case "1":
                    Metody.DodajOsobe(osoby);
                    break;
                case "2":
                    Metody.WyswietlOsoby(osoby);
                    break;
                default:
                    Console.WriteLine("Niepoprawna opcja.");
                    break;
            }

            Metody.ZapiszOsobyDoPliku(osoby, filePath);
            Console.ReadKey();
        }

    }
}
