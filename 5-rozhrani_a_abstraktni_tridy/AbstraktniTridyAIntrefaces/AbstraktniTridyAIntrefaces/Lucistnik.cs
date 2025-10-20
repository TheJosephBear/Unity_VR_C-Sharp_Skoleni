using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstraktniTridyAIntrefaces {
    internal class Lucistnik : Postava {
        public Lucistnik(string jmeno, int zdravi, int utok, int brneni) : base(jmeno, zdravi, utok, brneni) {
            Zdravi = (int)(zdravi * 0.7f);
            Utok = (int)(utok * 1.5f);
            Brneni = (int)(brneni * 0.8f);
        }

        public override void Utocit(Postava cilovaPostava) {
            if (JeMrtva) return;
            if (cilovaPostava.JeMrtva) return;

            int poskozeni = Utok;
            // 50% na kritcký zásah
            if (new Random().Next(0, 100) < 20) {
                poskozeni = (int)(poskozeni * 2.5f);
            }

            Console.WriteLine($"{Jmeno} válečnicky útočí na {cilovaPostava.Jmeno}");
            cilovaPostava.PrijmiPoskozeni(poskozeni);
            SpecialSchopnost(cilovaPostava);
        }

        protected override void SpecialSchopnost(Postava cilovaPostava) {
            Utok += 5; // Zvedne si útok protože proč ne
        }
    }
}
