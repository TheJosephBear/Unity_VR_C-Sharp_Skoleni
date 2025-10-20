using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorfismusDedicnost
{
    // Class Pes : TridaZeKtereDedim
    internal class Pes : Zvire
    {

        // Doplnění parametru konstruktoru rodiče
        public Pes(string jmeno) : base(jmeno)
        {

        }

        public override void UdelejZvuk()
        {
            Console.WriteLine("Haf Haf!");
        }

        public void Neco() {
            DefinujZvireProtected();
        //    DefinujZvirePrivate();
        }

        public override void Kousni()
        {
            base.Kousni();
            Console.WriteLine("Rafnul tě!");
        }


    }
}
