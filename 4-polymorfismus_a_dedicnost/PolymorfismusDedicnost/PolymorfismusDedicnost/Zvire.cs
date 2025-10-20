using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorfismusDedicnost
{
    internal class Zvire
    {
        public string Jmeno { get; set; }

        public Zvire(string jmeno)
        {
            Jmeno = jmeno;
        }

        public virtual void UdelejZvuk()
        {
            Console.WriteLine("Defaultní pazvuk!");
        }
             
        protected void DefinujZvireProtected()
        {
            Console.WriteLine("Zvíře je podle defincice něco něco!");
        }

        private void DefinujZvirePrivate()
        {
            Console.WriteLine("Zvíře je podle defincice něco něco!");
        }

        public virtual void Kousni()
        {
            Console.WriteLine($"{Jmeno} cení zuby...");
        }
    }
}
