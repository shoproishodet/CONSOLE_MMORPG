class Zombie : IEntity, IHaveDamage
{
    private const int MAX_HEALTH = 200;
    private const int START_DAMAGE = 50;
    public char Icon { get => 'Z'; }
    public Coordinate Position { get; private set; }
    public int Health { get; private set; } = MAX_HEALTH;
    public int Damage => START_DAMAGE;
    public bool IsAlive => Health > 0;
    public string Name { get; private set; }
    public Zombie(string name)
    {
        Name = name;
    }
    public void Hurt(int damage)
    {
        Health -= damage;
    }

   
}