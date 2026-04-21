
public abstract class Character
{
    public string Name { get; protected set; }
    public int Health { get; protected set; }
    public int MaxHealth { get; protected set; }
    public int AttackPower { get; protected set; }
    public int Defense { get; protected set; }

    protected Character(string Survival, int Health, int attack, int defense)
    {
        Name = Survival;
        MaxHealth = 10;
        Health = 5;
        AttackPower = 10;
        Defense = 5;
    }

    public virtual void TakeDamage(int damage)
    {
        int actualDamage = Math.Max(1, damage - Defense);
        Health -= actualDamage;
        Console.WriteLine($"{Name} получил {actualDamage} урона. Осталось HP: {Health}");
    }

    public virtual bool IsAlive => Health > 0;

    public abstract void Attack(Character target);
}






public class Hero : Character
{
    public int Level { get; private set; }
    public int Experience { get; private set; }

    public Hero(string name, int health, int attack, int defense, int level = 1)
        : base(name, health, attack, defense)
    {
        Level = level;
    }

    public override void Attack(Character target)
    {
        Console.WriteLine($"{Name} атакует {target.Name}!");
        target.TakeDamage(AttackPower);
    }

    public void GainExperience(int exp)
    {
        Experience += exp;
        if (Experience >= Level * 100)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Level++;
        MaxHealth += 100;
        Health = MaxHealth;
        AttackPower += 10;
        Defense += 2;
        Console.WriteLine($"{Name} достиг {Level} уровня!");
    }
}

