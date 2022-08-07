public interface IEntity
{
    string Name { get; }
    int Health { get; }
    bool IsAlive { get; }
    Coordinate Position { get; }
    char Icon { get; }
    public void Hurt(int damage);
}