class Zombie : IEntity, IHaveDamage
{
    private const int MAX_HEALTH = 200;
    private const int START_DAMAGE = 50;

    public int Health { get; private set; } = MAX_HEALTH;
    public int Damage => START_DAMAGE;
    public bool IsAlive => Health > 0;
    public string Name { get; private set; } = NameExtractor.GiveRandomeName();
    public void Hurt(int damage)
    {
        Health -= damage;
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