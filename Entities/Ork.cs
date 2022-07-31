class Ork : IEntity, IHaveDamage, IHaveArmor
{
    private const int MAX_HEALTH = 500;
    private const int START_DAMAGE = 20;
    private const float ARMOR = 0.2f;
    public string Name { get; private set; }
    public int Health { get; private set; } = MAX_HEALTH;
    public int Damage { get; private set; } = START_DAMAGE;
    public float Armor => ARMOR;
    public bool IsAlive => Health > 0;
    
    public Ork(string name)
    {
        Name = name;
    }
    public void Hurt(int damage)
    {
        Health -= (int)Math.Round(damage * (1 - Armor), MidpointRounding.AwayFromZero);
        Damage = START_DAMAGE + (MAX_HEALTH - Health) / 50;
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