/*abstract class Enemie
{
    abstract public int FullHealth{ get; }
    public int Health { get; protected set; }
    abstract public int Damage { get; }

    public Enemie()
    {
        Health = FullHealth;
    }

    public void Hurt(int damage)
    {
        Health -= damage;
        if (Health < 0)
            Health = 0;
    }

}



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