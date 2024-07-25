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
    private string name, status;
    private float maxHp, hp;

    private delegate void CalculateHealth(float amount);
    /// <summary> Event with hp </summary>
    public event EventHandler<CurrentHPArgs> HPCheck;


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
        this.status = $"{name} is ready to go!";
        HPCheck += CheckStatus;
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
        Console.WriteLine($"{this.name} takes {damage} damage!");
        ValidateHP(this.hp - damage);
    }

    /// <summary> Heal </summary>
    public void HealDamage(float heal)
    {
        if (heal < 0)
            heal = 0;
        Console.WriteLine($"{this.name} heals {heal} HP!");
        ValidateHP(this.hp + heal);
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
        HPCheck?.Invoke(this, new CurrentHPArgs(this.hp));
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

    /// <summary> Checks the status </summary>
    private void CheckStatus(object sender, CurrentHPArgs e)
    {
        float value = this.hp;

        if (value == maxHp)
            Console.WriteLine($"{name} is in perfect health!");
        else if (this.maxHp / 2 <= value && value < this.maxHp)
            Console.WriteLine($"{name} is doing well!");
        else if (this.maxHp / 4 <= value && value < this.maxHp / 2)
            Console.WriteLine($"{name} isn't doing too great...");
        else if (0 < value && value < this.maxHp / 4)
            Console.WriteLine($"{name} needs help!");
        else if (value == 0)
            Console.WriteLine($"{name} is knocked out!");

    }
}

/// <summary> Null </summary>
public class CurrentHPArgs: EventArgs
{
    /// <summary> Null </summary>
    public float CurrentHP;

    /// <summary> Update hps </summary>
    public CurrentHPArgs(float newHp)
    {
        this.CurrentHP = newHp;
    }
}
