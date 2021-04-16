using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versenyzok
{
    class Program
    {
        static List<Pilota> pilotak = new List<Pilota>();
        static void Main(string[] args)
        {
            BeolvasasF_02();
            F_03();
            F_04();
            F_05();
            F_06();
            F_07();
            Console.ReadLine();
        }

        private static void F_07()
        {
            Console.WriteLine($"7. feladat:");
            pilotak.GroupBy(j => j.rajtszam).Where(g => g.Count() > 1 && g.Key != 0).ToList().ForEach(a => Console.Write(a.Key + " "));
        }

        private static void F_06()
        {
            Console.WriteLine($"6. feladat: {pilotak.FindAll(b => b.rajtszam > 0).OrderBy(a => a.rajtszam).First().nemzetiseg}");
        }

        private static void F_05()
        {
            Console.WriteLine("5. feladat:");
            pilotak.Where(x => x.szuletesi_datum < DateTime.Parse("1901.01.01")).ToList().ForEach(a => Console.WriteLine($"\t{a.nev} ({a.szuletesi_datum.ToShortDateString()})"));
        }

        private static void F_04()
        {
            Console.WriteLine($"4. feladat: {pilotak.Last().nev}");
        }

        private static void F_03()
        {
            Console.WriteLine($"3. feladat: {pilotak.Count}");
        }

        private static void BeolvasasF_02()
        {
            using (StreamReader sr = new StreamReader("pilotak.csv"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    pilotak.Add(new Pilota(sr.ReadLine()));
                }
            }
        }
    }
    class Pilota
    {
        public string nev { get; set; }
        public DateTime szuletesi_datum { get; set; }
        public string nemzetiseg { get; set; }
        public int rajtszam { get; set; }

        public Pilota(string sor)
        {
            string[] darab = sor.Split(';');
            this.nev = darab[0];
            this.szuletesi_datum = DateTime.Parse(darab[1]);
            this.nemzetiseg = darab[2];
            if (!string.IsNullOrEmpty(darab[3]))
            {
                this.rajtszam = int.Parse(darab[3]);
            }
        }
    }
}
