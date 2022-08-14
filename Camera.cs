using RPG;

public class Camera
{
    Coordinate cameraPos = new Coordinate();

    private const int SIDE = 15;

    ConsoleBuffer console = new ConsoleBuffer();

    public Camera(Dude dude)
    {
        cameraPos = dude.Position;
    }
    public void Print(List<IEntity> entities)
    {
        console.Clear();
        foreach (IEntity entity in entities)
        {
            if (entity is Dude && !IsVisible(entity.Position))
            {
                //cameraPos = entity.Position;
                if (entity.Position.x < cameraPos.x) cameraPos.x -= 1;
                else if (entity.Position.x > cameraPos.x + SIDE) cameraPos.x += 1;
                else if (entity.Position.y < cameraPos.y) cameraPos.y -= 1;
                else if (entity.Position.y > cameraPos.y + SIDE) cameraPos.y += 1;
                Coordinate currentEntity = AdaptingCoordinate(entity.Position);
                console.Write(currentEntity.x, currentEntity.y, entity.Icon, entity.IconColor);

            }
            else if (IsVisible(entity.Position))
            {
                Coordinate currentEntity = AdaptingCoordinate(entity.Position);
                console.Write(currentEntity.x, currentEntity.y, entity.Icon, entity.IconColor);
            }
        }
        console.Print();
    }

    private Coordinate AdaptingCoordinate(Coordinate coordinate)
    {
        coordinate.x -= cameraPos.x;
        coordinate.y -= cameraPos.y;
        return coordinate;
    }

    private bool IsVisible(Coordinate coordinate)
    {
        if (coordinate.x < cameraPos.x) return false;
        else if (coordinate.x > cameraPos.x + SIDE) return false;
        else if (coordinate.y < cameraPos.y) return false;
        else if (coordinate.y > cameraPos.y + SIDE) return false;
        return true;
    }
}