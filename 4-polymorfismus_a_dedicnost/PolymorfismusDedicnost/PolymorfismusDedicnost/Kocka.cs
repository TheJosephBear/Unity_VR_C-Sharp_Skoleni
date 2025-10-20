using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorfismusDedicnost
{
    internal class Kocka : Zvire
    {
        public Kocka(string jmeno) : base(jmeno)
        {

        }

        public override void UdelejZvuk()
        {
            Console.WriteLine("Mńau Mńau");
        }

        public override void Kousni()
        {
            base.Kousni();
            Console.WriteLine("Podrápala tě a ještě kousla!");
        }

        public void ChytMys()
        {
            Console.WriteLine("Chytla jsem myš");
        }

        public void ChytMys(int pocet)
        {
            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine("Chytla jsem myš");
            }
        }
    }
}
