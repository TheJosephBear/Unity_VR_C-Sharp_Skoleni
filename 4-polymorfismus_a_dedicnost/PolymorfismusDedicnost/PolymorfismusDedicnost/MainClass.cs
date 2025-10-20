using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorfismusDedicnost
{
    internal class MainClass
    {
        public static void Main(string[] args)
        {

            // Úkol 2 - Zdraví a útok postav
            // a)
            // Vytvořte třídu "Postava"
            // Postava bude obsahovat:
            // - počet zdraví
            // - hodnotu útoku
            // - hodnotu brnění
            // - metodu na zaútočení na jinou postavu
            // - metodu na přijmutí poškozeni (když se na postavu zaútočí)
            // - metodu co bude obsahovat logiku na smrt postavy (stačí vypsat, že je postava mrtvá do konzole)
            // -> vytvořte dvě instance - hráč a nepřítel
            // -> zařiďte, aby hráč zaútočil na nepřitele


            Postava hrac = new Postava(jmeno: "Hráč", zdravi: 50, utok: 10, brneni: 2);
            Postava nepritel = new Postava("Nepřítel", 40, 8, 1);

    //        hrac.Utocit(nepritel);

            // b)
            // Přidejte do třídy postavy konstruktor pro nastavování hodnot atributů (zdraví, útok, brnění)
            // Nastavte různé hodnoty pro hráče a pro nepřítele
            // c) BITVA
            // Vytvořte dva LISTy několika postav s náhodnýma hodnotama
            // Zařiďte, aby každá postava v jednom listu zaútočila na každou postavu z druhého listu
            // BONUS: Pokud nějaká postava zemře, tak ji v pokračující bitvě přeskočte - Na mrtvou postavu nelze útočit a ona sama také neútočí.
            // (Tip: náhodné číslo se vytváří takto:
            //       int nahodneCislo = new Random().Next(1, 11); // číslo od 1 do 10
            // )
            // (Tip: využijte List<Postava> a smyčky "for" a "foreach")

            Random rand = new Random();
            List<Postava> team1 = new List<Postava>();
            List<Postava> team2 = new List<Postava>();

            for (int i = 0; i < 5; i++)
            {
                team1.Add(new Postava($"Hráč{i}", rand.Next(1, 21), rand.Next(1, 11), rand.Next(1, 11)));
                team2.Add(new Postava($"Nepřítel{i}", rand.Next(1, 11), rand.Next(1, 11), rand.Next(1, 11)));
            }

            for (int i = 0; i < team1.Count; i++)
            {
       /*         Postava team1Zastupce = team1[i];
                Postava team2Zastupce = team2[i];

                team1Zastupce.Utocit(team2Zastupce);
                team2Zastupce.Utocit(team1Zastupce);
       */
            }


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

        }
    }

}
