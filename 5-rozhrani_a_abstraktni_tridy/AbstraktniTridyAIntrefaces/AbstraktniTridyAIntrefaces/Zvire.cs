using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstraktniTridyAIntrefaces {
    public abstract class Zvire {

        public string Jmeno { get; protected set; } // Jde nastavit jen v potomcich a číst všude

        public abstract void UdelejZvuk();
        public abstract void Kousej();

        // Každý zvíře nějak funí dejme tomu stejně, pokud se najde nějaké co ne
        // Tak je metoda virtualní a může si ji přetížit
        public virtual void Dychej() {
            Console.WriteLine("Funím!");
        }
    }

    public interface IMluvic {
        void Mluv();
    }

    class Pes : Zvire, IMluvic {
        public override void Kousej() {
            Console.WriteLine("RAF!");
        }

        public void Mluv() {
            Console.WriteLine("Dobrý den, jmenuji se Evžen a takhle mluvím.");
        }

        public override void UdelejZvuk() {
            Console.WriteLine("HAF!");
        }
    }
}
