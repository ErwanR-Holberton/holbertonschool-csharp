using System;

/// <summary> Player </summary>
public class Player
{
    private string name;
    private float maxHp;
    private float hp;

    private delegate void CalculateHealth(float amount);


    /// <summary> Constructor </summary>
    public Player(string name = "Player", float maxHp = 100f)
    {
        this.name = name;
        if (maxHp > 0)
            this.maxHp = maxHp;
        else
        {
            this.maxHp = 100f;
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
        }
        this.hp = this.maxHp;
    }

    /// <summary> Print Health </summary>
    public void PrintHealth()
    {
        Console.WriteLine($"{this.name} has {this.hp} / {this.maxHp} health");
    }

    /// <summary> Damage </summary>
    public void TakeDamage(float damage)
    {
        if (damage < 0)
            damage = 0;
        this.hp -= damage;
        Console.WriteLine($"{this.name} takes {damage} damage!");
    }

    /// <summary> Heal </summary>
    public void HealDamage(float heal)
    {
        if (heal < 0)
            heal = 0;
        this.hp += heal ;
        Console.WriteLine($"{this.name} heals {heal} HP!");
    }
}

