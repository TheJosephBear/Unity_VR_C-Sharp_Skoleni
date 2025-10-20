using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstraktniTridyAIntrefaces {
    internal class Mag : Postava {

        bool _oziveny = false; // už byl jednou oživený?

        public Mag(string jmeno, int zdravi, int utok, int brneni) : base(jmeno, zdravi, utok, brneni) {
            Zdravi = (int)(zdravi * 0.4f);
            Utok = (int)(utok * 5f);
            Brneni = (int)(brneni * 0.1f);
        }

        public override void Utocit(Postava cilovaPostava) {
            if (JeMrtva) return;
            if (cilovaPostava.JeMrtva) return;

            int poskozeni = this.Utok;
            int celkovePoskozeni = poskozeni + cilovaPostava.Brneni; // Bude ignorovat brnění

            Console.WriteLine($"{Jmeno} magicky útočí na {cilovaPostava.Jmeno}");
            cilovaPostava.PrijmiPoskozeni(celkovePoskozeni);
            SpecialSchopnost(cilovaPostava);
        }

        void Ozivni() {
            Zdravi = 15; // oživí se s nějakým pevně daným počtem životů
        }

        protected override void Umri() {
            if (!_oziveny) {
                Ozivni();
            } else {
                base.Umri();
            }
        }

        protected override void SpecialSchopnost(Postava cilovaPostava) {
            // FIREBALL
            int fireballDamage = 50;
            int chanceToHit = 5;

            if (new Random().Next(0, 100) < chanceToHit) {
                cilovaPostava.PrijmiPoskozeni(fireballDamage);
            }
        }

    }
}
