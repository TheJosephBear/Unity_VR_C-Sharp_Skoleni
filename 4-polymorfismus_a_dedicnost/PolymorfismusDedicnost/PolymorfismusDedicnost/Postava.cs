using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PolymorfismusDedicnost
{
    internal class Postava
    {
        public string Jmeno { get; set; }
        public int Zdravi { get; set; }
        public int Utok { get; set; }
        public int Brneni { get; set; }
        public bool JeMrtva { get; set; }

        public Postava(string jmeno, int zdravi, int utok, int brneni)
        {
            Jmeno = jmeno;
            Zdravi = zdravi;
            Utok = utok;
            Brneni = brneni;
        }

        public void Utocit(Postava cilovaPostava)
        {
            if (JeMrtva) return;
            if (cilovaPostava.JeMrtva) return;

            Console.WriteLine($"{Jmeno} utoci na {cilovaPostava.Jmeno}");
            cilovaPostava.PrijmiPoskozeni(this.Utok);
        }

        public void PrijmiPoskozeni(int poskozeni)
        {
            int celkovePoskozeni = poskozeni - Brneni;
            if (poskozeni < 0) poskozeni = 0;

            Zdravi -= celkovePoskozeni;
            Console.WriteLine($"{Jmeno} schytal {celkovePoskozeni} poškození!");
            Console.WriteLine($"{Jmeno} má nyní {Zdravi} životů!");
            if (Zdravi <= 0)
            {
                Umri();
            }
        }

        void Umri()
        {
            JeMrtva = true;
            Console.WriteLine($"{Jmeno} je mrtvý!!!");
        }

    }
}
