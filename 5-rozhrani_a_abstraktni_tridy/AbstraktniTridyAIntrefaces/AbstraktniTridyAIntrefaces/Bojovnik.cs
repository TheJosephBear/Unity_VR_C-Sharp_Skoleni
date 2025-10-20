using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstraktniTridyAIntrefaces {
    internal class Bojovnik : Postava {
        public Bojovnik(string jmeno, int zdravi, int utok, int brneni) : base(jmeno, zdravi, utok, brneni) {
            Zdravi = (int)(zdravi * 1.8f);
            Utok = (int)(utok * 0.7f);
            Brneni = (int)(brneni * 1.2f);
        }

        public override void Utocit(Postava cilovaPostava) {
            if (JeMrtva) return;
            if (cilovaPostava.JeMrtva) return;


            Console.WriteLine($"{Jmeno} válečnicky útočí na {cilovaPostava.Jmeno}");
            cilovaPostava.PrijmiPoskozeni(this.Utok);

            // 20% na zaútočení dvakrát
            if(new Random().Next(0,100) < 20) {
                Console.WriteLine($"{Jmeno} válečnicky ZNOVU útočí na {cilovaPostava.Jmeno}");
                cilovaPostava.PrijmiPoskozeni(this.Utok);
            }
            SpecialSchopnost(cilovaPostava);
        }

        protected override void SpecialSchopnost(Postava cilovaPostava) {
            Zdravi += 2; // Uzdraví se
            cilovaPostava.Brneni -= 2; // Sníží brnění nepříteli
        }
    }
}
