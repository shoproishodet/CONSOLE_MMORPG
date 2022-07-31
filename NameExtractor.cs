class NameExtractor
{
    static string[] names = File.ReadAllLines(@"D:\C#\MMORPG\npc_names.txt");
    static Random random = new Random();
    public static string GiveRandomeName()
    {
        return names[random.Next(names.Length)]; 
    }
    public static string GetNameFromConsole()
    {
        Console.WriteLine("введи имя еблан");
        var tmp = Console.ReadLine();
        while (tmp == null)
        {
            Console.WriteLine("Сказанно же введи имя еблан");
            tmp = Console.ReadLine();
        }
        return tmp;
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