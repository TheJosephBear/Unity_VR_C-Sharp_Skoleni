# Rozhraní a abstraktní třídy
## Opakování -  Dědičnost a polymorfismus
Minule jsme si ukázali, že třídy mohou mít mezi sebou vztah rodič-potomek.
Dědění umožňuje znovu použít kód, a měnit chování potomků přepisováním (override)

### Princip dědičnosti

- Potomek dědí vlastnosti a metody rodiče.
- Potomek může přepsat (`override`) chování rodiče.
- Dědičnost umožňuje **polymorfismus**.
- **polymorfismus** = různé chování při volání stejné metody.

## Abstraktní třída
Abstraktní třída slouží jako šablona pro jiné třídy.
Nemůže být sama o sobě vytvořena (instanciována) – pouze děděna.

- Může obsahovat abstraktní metody (bez implementace).
- Může obsahovat i běžné metody s implementací – často sdílenou logiku.
- Potomek může dědit pouze z jedné abstraktní třídy.

### Abstraktní metoda
- Nemá tělo (implementaci).
- Každý potomek musí implementovat tuto metodu.
- Používá se pro zajištění, že všechny potomky budou mít stejné rozhraní metod.

### Syntax

```c#
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

class Pes : Zvire {
    public override void Kousej() {
        Console.WriteLine("RAF!");
    }

    public override void UdelejZvuk() {
        Console.WriteLine("HAF!");
    }
}
```

Rozdíl mezi využitím abstraktní třídy a klasického dědění je, že nejde udělat instanci zvířete:


```c#
public static void Main(string[] args) {
    Zvire zvire = new Zvire(); // Tohle udělá chybu
    Zvire hafan = new Pes(); // Tohle jde
}
```


## Rozhraní
Rozhraní definuje kontrakt – tedy, co třída musí umět.
Neobsahuje žádnou konkrétní implementaci (jen deklarace metod a vlastností).

- Třída může implementovat několik rozhraní zároveň.
- Jméno rozhraní se obvykle zapisuje s prefixem I (např. IMovable, IDamageable).

### Syntax

```c#
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
```

## Kdy co použít

### Klasická dědičnost
Kdy se vyplatí:
- Když máš jasnou hierarchii objektů typu „je to X“
- Když potřebuješ znovupoužít implementaci z rodiče
- Když se neočekává výrazná rozdílnost chování

#### Příklad
Malé systémy nebo úzce svázané entity
- jednoduchá hra, kde se všechny postavy chovají podobně/stejně jen s malými rozdíly

### Abstraktní třída
Kdy se vyplatí:
- Když máš společnou logiku + povinné metody, které se liší implementací
- Když chceš zajistit, že potomci musí doplnit určité chování
- Když se dá všechno dědit z jednoho konceptu

#### Příklad
- "Postava" ve videohře - nepřítel, přítel i hráč mají životy, můžou umřít, ale každý reaguje na smrt jinak

### Rozhraní
Kdy se vyplatí:
- Potřebuju, aby měl objekt nějakou vlastnost, která není vázaná na větší předpis (třeba abstraktní třídu)
- Vlastnost může mít několik různých nezávislých objektů

#### Příklad
- IDamageable, ve videohře jde poškodit nejen postavy, ale i barely, dveře, stromy, ...

### Kombinace
V praxi se nejčastěji kombinuje abstraktních tříd a rozhraní
- Abstraktní třída pro společný základ postav
- Rozhraní pro schopnosti (damage, pohyb, interakce)
- Klasická dědičnost pro konkrétní role
