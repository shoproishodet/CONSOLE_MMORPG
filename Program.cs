class Program
{
    public static void Main(string[] args)
    {
        Console.CursorVisible = false;

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