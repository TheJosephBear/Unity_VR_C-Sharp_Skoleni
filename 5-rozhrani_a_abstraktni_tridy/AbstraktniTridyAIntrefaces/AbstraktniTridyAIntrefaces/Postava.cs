using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstraktniTridyAIntrefaces {
    internal class Postava {
        public string Jmeno { get; set; }
        public int Zdravi { get; set; }
        public int Utok { get; set; }
        public int Brneni { get; set; }
        public bool JeMrtva { get; set; }

        public Postava(string jmeno, int zdravi, int utok, int brneni) {
            Jmeno = jmeno;
            Zdravi = zdravi;
            Utok = utok;
            Brneni = brneni;
        }

        public virtual void Utocit(Postava cilovaPostava) {
            if (JeMrtva) return;
            if (cilovaPostava.JeMrtva) return;

            Console.WriteLine($"{Jmeno} utoci na {cilovaPostava.Jmeno}");
            cilovaPostava.PrijmiPoskozeni(this.Utok);
            SpecialSchopnost(cilovaPostava);
        }

        public void PrijmiPoskozeni(int poskozeni) {
            int celkovePoskozeni = poskozeni - Brneni;
            if (poskozeni < 0) poskozeni = 0;

            Zdravi -= celkovePoskozeni;
            Console.WriteLine($"{Jmeno} schytal {celkovePoskozeni} poškození!");
            Console.WriteLine($"{Jmeno} má nyní {Zdravi} životů!");
            if (Zdravi <= 0) {
                Umri();
            }
        }

        protected virtual void Umri() {
            JeMrtva = true;
            Console.WriteLine($"{Jmeno} je mrtvý!!!");
        }

        protected virtual void SpecialSchopnost(Postava cilovaPostava) {

        }

        // =============================================
        // ==========  D) STATISTIKY POSTAVY ============
        // =============================================

        // Základní přehled – jen jméno a zdraví
        public void Stats() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("─────────────");
            Console.WriteLine($" {Jmeno}");
            Console.WriteLine($"❤ Zdraví: {Zdravi}");
            Console.WriteLine("─────────────");
            Console.ResetColor();
        }

        // Rozšířený přehled 1 – jméno, zdraví, útok
        public void Stats(int level) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("══════════════════════════════");
            Console.WriteLine($" Statistika postavy: {Jmeno}");

            Console.WriteLine($" Zdraví: {Zdravi}");

            if (level >= 1)
                Console.WriteLine($"  Útok: {Utok}");

            if (level >= 2)
                Console.WriteLine($"  Brnění: {Brneni}");

            Console.WriteLine("══════════════════════════════");
            Console.ResetColor();
        }

        // Porovnání se soupeřem
        public void Stats(Postava souper) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("══════════════════════════════");
            Console.WriteLine($"⚔  Srovnání statistik: {Jmeno} vs {souper.Jmeno}");
            Console.WriteLine("══════════════════════════════");

            Console.WriteLine($" Zdraví:   {Zdravi}  |  {souper.Zdravi}  (rozdíl: {Zdravi - souper.Zdravi})");
            Console.WriteLine($"  Útok:     {Utok}   |  {souper.Utok}   (rozdíl: {Utok - souper.Utok})");
            Console.WriteLine($"  Brnění:  {Brneni}  |  {souper.Brneni}  (rozdíl: {Brneni - souper.Brneni})");

            Console.WriteLine("══════════════════════════════");
            Console.ResetColor();
        }
    }
}
