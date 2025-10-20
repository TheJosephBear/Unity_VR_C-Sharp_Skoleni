using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstraktniTridyAIntrefaces {
    internal class MainClass {
        public static void Main(string[] args) {

            // =======================
            //   *******************
            //     ÚKOL Z MINULE
            //   *******************
            // =======================
            // ====================
            //    Polymorfismus
            // ====================
            //
            // a)
            // Vytvořte tři potomky třídy Postava - bojovnik, lukostrelec, mag
            // Nastavte hodnoty tak, aby hodnoty potomku byly ruzne (můžete hodnoty dané parametry vydělit - slabý útok bude např. hodnota utok/2):
            //  - Bojovnik – slabý útok, silný brnění, velké životy
            //  - Lukostrelec – střední útok, menší brnění
            //  - Mag – slabý útok, ale silná kouzla
            // Přepiš metodu Utocit(Postava cil) v každém potomkovi tak, aby se chovala odlišně (např. Mag může přeskočit brnění,
            // Lukostřelec má šanci na kritický zásah).

            // b)
            // Přidejte magovi schopnost - pokud poprvé umře tak se oživí s polovinou životů

            // c) 
            // Přidejte Postavě "specialni schopnost"
            // Každý potomek bude implementovat specialni schopnost uplně jinak
            // V bitvě pokaždé po útoku vyvolejte i specialni schopnost

            // d)
            // přidejte funkce pro získání statistik (hodnoty atributů postavy)
            // Pokuste se nadesignovat výpis tak aby v konzoli vypadal hezky
            // využijte statického polymorfismu (stejná funkce, různé parametry) abyste mohli vypsat zakladni nebo rozširene informace
            // Stats() -> jen jmeno a zivoty
            // Stats(1) -> Jmeno, zivoty, Utok
            // Stats(2) -> Jmeno, zivoty, utok, brneni
            // Přidejte ještě možnost porovnání se statistik se soupeřem
            // Stats(souper) -> vypíše statistiky obou postav + jejich rozdíly

            Postava lukous = new Lucistnik("Lukouš", 15,321,49685);
            Postava warak = new Bojovnik("Warák", 2,36456451,496565685);

            lukous.Stats();
            lukous.Stats(0);
            lukous.Stats(1);
            lukous.Stats(2);
            lukous.Stats(warak);


            // ============================================================
            //        Vylepšení pomocí abstraktních tříd a rozhraní
            // ============================================================
            //  REFAKTOROVÁNÍ
            //
            // a)
            // Udělejte z postavy abstraktní třídu
            //
            // b)
            // Přidejte rozhraní IDamageable(Objekt umí přijmout poškození) a IAttacker(Objekt umí zaútočit na IDamageable cíl)
            //
            // c)
            // Přidáme soubojový systém jako vlastní třídu (oddělení logiky boje od samotných postav)


        }
    }
}
