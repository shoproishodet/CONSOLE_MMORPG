class Dude : IEntity, IHaveArmor, IHaveDamage, ICanEat
{
    private int penisLength = 20;
    private const int MAX_HEALTH = 200;
    private const int START_DAMAGE = 50;
    private const float MAX_ARMOR = 0.1f;
    public char Icon { get => 'D'; }
    public Coordinate Position { get; private set; }

    public int Health { get; protected set; } = MAX_HEALTH;
    public float Armor { get; protected set; } = MAX_ARMOR;
    public int Damage { get => START_DAMAGE; }
    public bool IsAlive => Health > 0;
    public string Name { get; private set; }
    public Dude(string name)
    {
        Name = name;
        Position = Coordinate.Zero;
    }
    public void Hurt(int damage)
    {
        Health -= (int)Math.Round(damage * (1 - Armor), MidpointRounding.AwayFromZero);
    }
    public void Eat(Food food)
    {
        Health = Math.Clamp(Health + food.GetHealth(), 0, MAX_HEALTH);
    }
    public void Turn(char key)
    {
        switch (key)
        {
            case 'w':
                Position = new Coordinate(Position.x, Position.y + 1);
                break;
            case 's':
                Position = new Coordinate(Position.x, Position.y - 1);
                break;
            case 'a':
                Position = new Coordinate(Position.x - 1, Position.y);
                break;
            case 'd':
                Position = new Coordinate(Position.x + 1, Position.y);
                break;
        }
    }
}