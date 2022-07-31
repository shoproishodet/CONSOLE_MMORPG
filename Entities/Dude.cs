class Dude : IEntity, IHaveArmor, IHaveDamage, ICanEat
{
    private int penisLength = 20;
    private const int MAX_HEALTH = 200;
    private const int START_DAMAGE = 50;
    private const float MAX_ARMOR = 0.1f;
    public int Health { get; protected set; } = MAX_HEALTH;
    public float Armor { get; protected set; } = MAX_ARMOR;
    public int Damage { get => START_DAMAGE; }
    public bool IsAlive => Health > 0;

    public string Name { get; private set; } =  NameExtractor.GetNameFromConsole();

    public void Hurt(int damage)
    {
        Health -= (int)Math.Round(damage * (1 - Armor), MidpointRounding.AwayFromZero);
    }

    public void Eat(Food food)
    {
        Health = Math.Clamp(Health + food.GetHealth(), 0, MAX_HEALTH);
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