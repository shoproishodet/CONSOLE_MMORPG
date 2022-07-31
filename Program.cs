using System;

class Program
{
    public static void Main(string[] args)
    {
        var Levi = new Dude();
        var GuulDan = new Ork(NameExtractor.GiveRandomeName());

        Fight(Levi, GuulDan);
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


/*
 * проверяем не мертвы ли у нас чувак и энэми
 * если кто то мертв выводим это в консоль
 * иначе они начинают хуяриться пока кто-то не умрет
 * чел бьет энэми
 * проверяем не умер ли энэми
 * если помер то прерываем цикл и выводим в консоль что энэми мертв
 * энэми бьет чела
 * проверяем не умер ли чел
 * если помер то прерываем цикл и выводим в консоль что чел мертв
 * колесо сансары дает оборот
*/