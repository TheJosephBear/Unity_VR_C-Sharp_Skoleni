using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstraktniTridyAIntrefaces {
    internal class MainClass {
        public static void Main(string[] args) {
            Zvire zvire = new Zvire(); // Tohle udělá chybu
            Zvire hafan = new Pes(); // Tohle jde
        }
    }
}
