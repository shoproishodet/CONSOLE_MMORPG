class NameExtractor
{
    string[] names = File.ReadAllLines(@"D:\C#\MMORPG\npc_names.txt");
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