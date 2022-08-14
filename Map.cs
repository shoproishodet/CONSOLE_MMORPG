using RPG;

public class Map
{
    ConsoleBuffer console = new ConsoleBuffer();

    public void Print(List<IEntity> entities)
    {
        foreach (IEntity entity in entities)
        {
            console.Write(entity.Position.y, entity.Position.x, entity.Icon, entity.IconColor);
        }
        console.Print();
    }
}