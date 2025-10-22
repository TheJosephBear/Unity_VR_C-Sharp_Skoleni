# Návrhové vzory
## Co to je a proč to používat
Návrhové vzory(NV) jsou obecné řešení často se vyskytujících problémů při OOP vývoji softwaru. NV slouží jako koncepty pro řešení problémů, které se musí každý upravit tak, aby ho mohl správně použít. Nejsou to algoritmy, ale spíš popisy struktury.

## Kritika návrhových vzorů
NV nemusí být vždy nejlepším řešením daného problému, často existuje jednodušší řešení. Častá chyba co začátečníci dělají je, že se snaží použít NV na sílu a zbytek programu staví okolo něj.

# Specifické návrhové vzory
## Creational patterns
Tyto vzory řeší problémy spojené s vytvářením objektů. Poskytují mechanismus, který obaluje logiku vytváření. Přidávají kontrolu a lepší oddělení kódu, který objekt používá, od kódu, který ho vytváří. (nemusím se starat v mainu abych měl pouze jednu instanci, singleton to udělá sám)

### Singleton (Jedináček)
- [Odkaz na refactoring guru](https://refactoring.guru/design-patterns/singleton)

Zajišťuje, že třída má pouze jednu instanci v celém běhu aplikace, a poskytuje k ní globální přístupový bod. (GameManager, ConsoleManager)

```c#
public class GameManager
{
    int skore = 0;
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }
    }

    private GameManager() { } // zabrání přímému vytvoření instance

    public void ZvedniSkore(){
        skore += 1;
    }
}

public class MainClass {
    public  static void Main(string[] args){
            GameManager.Instance.ZvedniSkore();
    }
}

```


### Builder (Stavitel)
- [Odkaz na refactoring guru](https://refactoring.guru/design-patterns/builder)

Odděluje konstrukci složitých objektů od jejich reprezentace. Umožňuje vytvářet různé varianty objektu (různé konfigurace) postupnými kroky pomocí stejného procesu.

```c#

public class Enemy
{
    public string Name;
    public int Health;
    public int Damage;
}

public class EnemyBuilder
{
    private Enemy enemy = new Enemy();

    public EnemyBuilder SetName(string name) { enemy.Name = name; return this; }
    public EnemyBuilder SetHealth(int health) { enemy.Health = health; return this; }
    public EnemyBuilder SetDamage(int damage) { enemy.Damage = damage; return this; }

    public Enemy Build() => enemy;
}

public class MainClass {
    public  static void Main(string[] args){
            Enemy boss = new EnemyBuilder().SetName("Dragon").SetHealth(500).SetDamage(50).Build();
    }
}
```

### Factory
- [Odkaz na refactoring guru](https://refactoring.guru/design-patterns/factory-method)

Definuje rozhraní pro vytváření objektu, ale nechává rozhodnutí o tom, jakou třídu vytvořit, na podtřídách (subtřídách). Umožňuje třídě delegovat instanciaci na "tovární" metodu.

### Prototype
- [Odkaz na refactoring guru](https://refactoring.guru/design-patterns/prototype)

Umožňuje vytvářet nové objekty kopírováním (klonováním) existujícího objektu (prototypu), místo vytváření instancí od nuly.

Vestavěné v unity (Instantiate pracuje jako Clone()) a v samotném C# (System.ICloneable interface)

Vlastní implementace pokud potřebujeme speciálně definovat jak vytvářet kopie (například přidat za jméno "(clone)").

## Behavioral patterns
Tyto vzory se zabývají komunikací, interakcí a rozdělením odpovědnosti mezi objekty. Zaměřují se na algoritmy a řízení toku.

### Observer
- [Odkaz na refactoring guru](https://refactoring.guru/design-patterns/observer)

```c#
public interface IObservable
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

public class WeatherStation : IObservable
{
    private List<IObserver> observers = new();
    private float temperature;

    public void SetTemperature(float newTemp)
    {
        Console.WriteLine($"\n[WeatherStation] New temperature: {newTemp}°C");
        temperature = newTemp;
        NotifyObservers();
    }

    public float GetTemperature() => temperature;

    public void AddObserver(IObserver observer) => observers.Add(observer);
    public void RemoveObserver(IObserver observer) => observers.Remove(observer);

    public void NotifyObservers()
    {
        foreach (var observer in observers)
            observer.Update(this);
    }
}

// === Observer ===
public interface IObserver
{
    void Update(IObservable observable);
}

public class Display : IObserver
{
    public void Update(IObservable observable)
    {
        if (observable is WeatherStation station)
            Console.WriteLine($"[Display] Updating screen: {station.GetTemperature()}°C");
    }
}

public class Logger : IObserver
{
    public void Update(IObservable observable)
    {
        if (observable is WeatherStation station)
            Console.WriteLine($"[Logger] Logged temperature: {station.GetTemperature()}°C");
    }
}

// === Main Program ===
public class Program
{
    public static void Main()
    {
        WeatherStation station = new();
        Display screen = new();
        Logger logger = new();

        station.AddObserver(screen);
        station.AddObserver(logger);

        station.SetTemperature(22.5f);
        station.SetTemperature(25.0f);

        station.RemoveObserver(screen);

        station.SetTemperature(18.3f);
    }
}
```

Definuje vztah jedna-ku-mnoha, kde změna stavu jednoho objektu (subjektu) automaticky upozorní všechny jeho závislé objekty (pozorovatele), aniž by o sobě navzájem nutně věděli.

### Strategy
- [Odkaz na refactoring guru](https://refactoring.guru/design-patterns/strategy)

Definuje rodinu algoritmů, zapouzdří každý z nich do samostatné třídy a umožní jejich vzájemnou zaměnitelnost za běhu programu.

```c#
public interface IAttackStrategy {
    void Attack(); 
}

public class MeleeAttack : IAttackStrategy { 
    public void Attack() => Console.WriteLine("Melee attack!"); 
}
public class RangedAttack : IAttackStrategy { 
    public void Attack() => Console.WriteLine("Ranged attack!"); 
    
}

public class Enemy
{
    private IAttackStrategy strategy;
    public Enemy(IAttackStrategy s){
        strategy = s;
    }
    public void PerformAttack() {
        strategy.Attack();
    }
}
```


### Command
- [Odkaz na refactoring guru](https://refactoring.guru/design-patterns/command)

Zapouzdří akci(například smazaní souboru) jako objekt. Díky commandu potom lze jít zpět/vpřed (ctrl+z), dělat frontu požadavků, atd.

```c#
public interface ICommand { 
    void Execute(); 
    void Undo(); 
}

public class MoveCommand : ICommand
{
    private string direction;
    public MoveCommand(string dir) {
        direction = dir;
    }

    public void Execute() { 
        Console.WriteLine($"Moving {direction}");
    }

    public void Undo() { 
        Console.WriteLine($"Undo move {direction}");
    }
}
```


### State
- [Odkaz na refactoring guru](https://refactoring.guru/design-patterns/state)

Umožňuje objektu měnit své chování, když se změní jeho interní stav. Objekt se zdá, jako by změnil svou třídu.

### Iterator
- [Odkaz na refactoring guru](https://refactoring.guru/design-patterns/iterator)

Poskytuje standardní způsob, jak procházet prvky agregované kolekce (např. seznam, pole, strom) bez odhalení její vnitřní struktury.

V C# vestavěné (pomocí rozhraní IEnumerable a IEnumerator - používá se ve smyčkách foreach).

Vlastní implementace pokud potřebujeme nějaký speciální způsob jak procházet prvky.

## Structural patterns
Tyto vzory se zabývají skládáním tříd a objektů do větších, flexibilnějších struktur. Pomáhají zajistit, aby změna v jedné části systému nevyžadovala změnu celého systému.

### Adapter
- [Odkaz na refactoring guru](https://refactoring.guru/design-patterns/adapter)
Umožňuje spolupráci tříd s nekompatibilními rozhraními. Funguje jako překladač mezi dvěma různými rozhraními.

```c#
public interface IAudioPlayer { void Play(string file); }

public class LegacyPlayer { public void PlayFile(string path) => Console.WriteLine($"Playing {path}"); }

public class Adapter : IAudioPlayer
{
    private LegacyPlayer legacy = new();
    public void Play(string file) => legacy.PlayFile(file);
}
```


### Decorator
- [Odkaz na refactoring guru](https://refactoring.guru/design-patterns/decorator)

Dynamicky přidává nové odpovědnosti k objektu jeho obalováním (wrapping) do speciálních objektů, aniž by byla nutná dědičnost.

### Flyweight
- [Odkaz na refactoring guru](https://refactoring.guru/design-patterns/flyweight)

Umožňuje sdílení mnoha malých objektů (objektů s malou paměťovou stopou) pro úsporu paměti. Odděluje neměnná (sdílená) data od měnících se (unikátních) dat.



## Zdroje pro samostudium
Návrhové vzory jsou sami o sobě velké téma, které nejde pochopit během dvouhodinové lekce, takže tentokrát přikládám zdroje, které vám s tímto tématem pomůžou.

Doporučuji všem aby si přečetli minimálně vysvětlení z refactoring guru o jednotlivých návrhových vzorech. Tato stránka má vše velmi obsahově i graficky zpracované velmi hezky.

- [Fireship video](https://www.youtube.com/watch?v=tv-_1er1mWI)
- [Podcast o návrhových vzorech](https://www.youtube.com/watch?v=LRUw50hRG3c)

### **Refactoring guru**
- [Teorie k návrhovým vzorům](https://refactoring.guru/design-patterns/what-is-pattern).
- [Refactoring guru kniha](https://refactoring.guru/design-patterns/book)


## Samostatná práce
Nejlepší způsob jak pochopit většinu programovacích technik je samotným programováním.
Zkuste si splnit následující zadání:

### Zadání 1
#### Konzolový UI systém

Vytvořte aplikaci, která bude umět pracovat s uživatelským vstupem. Aplikace bude zobrazovat různá okna, kde jdou dělat různé příkazy a budou se vypisovat různé informace. Zařiďte, aby byla možná pouze jedna instance konzolového systému, který konzoli ovládá. Tématiku aplikace si můžete libovolně zvolit nebo si vybrat následující:
- Videohra, kde bude: 
  - hlavní menu (hrát, nastavení, ukončit)
  - nastavení (zpět do menu, změna barvy + kód barvy, ...)
  - hra (nějaký výpis a logika toho že jste ve hře, případně rozšíření textové adventury, pokud jste již zkoušeli)

### Zadání 2
Rozšiřte vaši konzolovou aplikaci o:
- Funkcionalita UNDO (ctrl+z)
    - přidejte možnost "vzít zpět" svůj poslední příkaz
    - (Command)

### Zadání 3
Rozšiřte vaši konzolovou aplikaci o:
- Ukládání dat aplikace různými způsoby pomocí Save systému (ukládání do .txt, ukládání do .json, ...)
- Pokud pracujete s textovou adventurou (nebo jinou hrou) přidejte různé obtížností
    - (Strategy)

### Zadání 4
Rozšiřte vaši konzolovou aplikaci o:



