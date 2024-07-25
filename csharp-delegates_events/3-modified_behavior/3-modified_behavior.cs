using System;

/// <summary> ENUM </summary>
public enum Modifier
{
    /// <summary> WEAK </summary>
    Weak,
    /// <summary> BASE </summary>
    Base,
    /// <summary> STRONG </summary>
    Strong
}

/// <summary> Delegate </summary>
public delegate float CalculateModifier(float baseValue, Modifier modifier);

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
        ValidateHP(this.hp - damage);
        Console.WriteLine($"{this.name} takes {damage} damage!");
    }

    /// <summary> Heal </summary>
    public void HealDamage(float heal)
    {
        if (heal < 0)
            heal = 0;
        ValidateHP(this.hp + heal);
        Console.WriteLine($"{this.name} heals {heal} HP!");
    }

    /// <summary> Validate </summary>
    public void ValidateHP(float newHp)
    {
        if (newHp < 0)
            this.hp = 0;
        else if (newHp > maxHp)
            this.hp = this.maxHp;
        else
            this.hp = newHp;
    }

    /// <summary> Apply </summary>
    public float ApplyModifier(float baseValue, Modifier modifier)
    {
        if (modifier is Modifier.Weak)
            return baseValue / 2;
        else if (modifier is Modifier.Base)
            return baseValue;
        else
            return baseValue * 1.5f;
    }
}
