using System;
class NameExtractor
{
    string[] names = MMORPG.Properties.Resources.npc_names.Split('\n');
    Random random = new Random();

    public string GiveRandomName()
    {
        return names[random.Next(names.Length)];
    }

    public string GetNameFromConsole()
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