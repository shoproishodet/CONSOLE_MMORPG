class Ork : IEntity, IHaveDamage, IHaveArmor
{
    private const int MAX_HEALTH = 500;
    private const int START_DAMAGE = 20;
    private const float ARMOR = 0.2f;
    public char Icon => 'O';
    public Coordinate Position { get; private set; }
    public ConsoleColor IconColor => ConsoleColor.Red;
    public string Name { get; private set; }
    public int Health { get; private set; } = MAX_HEALTH;
    public int Damage { get; private set; } = START_DAMAGE;
    public float Armor => ARMOR;
    public bool IsAlive => Health > 0;
    
    public Ork(string name)
    {
        Name = name;
        Position = new Coordinate(1,10);
    }
    public void Hurt(int damage)
    {
        Health -= (int)Math.Round(damage * (1 - Armor), MidpointRounding.AwayFromZero);
        Damage = START_DAMAGE + (MAX_HEALTH - Health) / 50;
    }
}