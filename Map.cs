using RPG;

public class Map
{
    private const int WIDTH = 20;
    private const int HEIGHT = 20;
    char[,] field = new char[WIDTH, HEIGHT];
    ConsoleBuffer console = new ConsoleBuffer();

    private void Init()
    {
        for (int i = 0; i < WIDTH; i++)
        {
            for (int j = 0; j < HEIGHT; j++)
            {
                field[i, j] = '-';
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
        console.Clear();
        for (int i = 0; i < WIDTH; i++)
        {
            for (int j = 0; j < HEIGHT; j++)
            {
                console.Write(j, i, field[i, j], ConsoleColor.Blue);
            }
            //Console.Write("\n");
        }

        console.Print();
    }
}