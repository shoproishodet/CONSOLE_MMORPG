using System;

class Program
{
    public static void Main(string[] args)
    {
        List<IEntity> entities = new List<IEntity>();
        var field = new Map();
        var nameExtractor = new NameExtractor();

        var Levi = new Dude(nameExtractor.GetNameFromConsole());
        entities.Add(Levi);

        var GuulDan = new Ork(nameExtractor.GiveRandomeName());
        entities.Add(GuulDan);

        field.Add(entities);
        field.Print();
        //Fight(Levi, GuulDan);

        while(true)
        {
            if (Console.KeyAvailable)
            {
                char key = Console.ReadKey().KeyChar;
                Console.Clear();
                Levi.Turn(key);
                field.Add(entities);
                field.Print();
            }
        }
    }

    private static void Punch(IEntity puncher, IEntity victim)
    {
        if (puncher is IHaveDamage puncherDamage)
        {
            victim.Hurt(puncherDamage.Damage);
            Console.WriteLine($"{puncher.Name} hit {victim.Name} for {puncherDamage.Damage}");
            return;
        }
        Console.WriteLine($"{puncher.Name} just lookin");
    }
    public static void Fight(IEntity entityFirst, IEntity entitySecond)
    {
        while (entityFirst.IsAlive && entitySecond.IsAlive)
        {
            Punch(entityFirst, entitySecond);

            if (!entitySecond.IsAlive)
            {
                return;
            }
            Punch(entitySecond, entityFirst);
        }

        if (!entityFirst.IsAlive && !entitySecond.IsAlive)
        {
            Console.WriteLine("They are all dead!");
        }
        else if (!entitySecond.IsAlive)
        {
            Console.WriteLine($"{entityFirst.Name} kill {entitySecond.Name}");
        }
        else if (!entityFirst.IsAlive)
        {
            Console.WriteLine($"{entitySecond.Name} kill {entityFirst.Name}");
        }
    }
}

public class Map
{
    private const int WIDTH = 20;
    private const int HEIGHT = 20;
    char[,] field = new char[WIDTH, HEIGHT];
    private void Init()
    {
        for (int i = 0; i < WIDTH; i++)
        {
            for (int j = 0; j < HEIGHT; j++)
            {
                field[i,j] = '-';
            }
        }
    }
    public void Add(List<IEntity> entities)
    {
        Init();
        foreach (IEntity entity in entities)
        {
            field[entity.Position.y, entity.Position.x] = entity.Icon;
        }
    }
    public void Print()
    {
        for (int i = 0; i < WIDTH; i++)
        {
            for (int j = 0; j < HEIGHT; j++)
            {
                Console.Write(field[i, j]);
            }
            Console.Write("\n");
        }
    }

}
public struct Coordinate
{
    public int x;
    public int y;
    public static Coordinate Zero => new Coordinate(0, 0);
    public Coordinate(int x = 0, int y = 0)
    {
        this.x = x;
        this.y = y;
    }
}
