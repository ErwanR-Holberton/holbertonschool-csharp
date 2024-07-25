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
        this.HPCheck += CheckStatus;
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
        else if (newHp > this.maxHp)
            this.hp = this.maxHp;
        else
            this.hp = newHp;
        HPCheck?.Invoke(this, new CurrentHPArgs(this.hp));
    }

    /// <summary> Apply </summary>
    public float ApplyModifier(float baseValue, Modifier modifier)
    {
        if (modifier == Modifier.Weak)
            return baseValue / 2;
        else if (modifier == Modifier.Base)
            return baseValue;
        else if (modifier == Modifier.Strong)
            return baseValue * 1.5f;
        return 0f;
    }

    /// <summary> Checks the status </summary>
    private void CheckStatus(object sender, CurrentHPArgs e)
    {
        float value = e.currentHp;

        if (value == this.maxHp)
            this.status = $"{this.name} is in perfect health!";
        else if (this.maxHp / 2 <= value && value < this.maxHp)
            this.status = $"{this.name} is doing well!";
        else if (this.maxHp / 4 <= value && value < this.maxHp / 2)
            this.status = $"{this.name} isn't doing too great...";
        else if (0 < value && value < this.maxHp / 4)
            this.status = $"{this.name} needs help!";
        else if (value == 0)
            this.status = $"{this.name} is knocked out!";

        Console.WriteLine(this.status);

    }
}

/// <summary> Null </summary>
public class CurrentHPArgs: EventArgs
{
    /// <summary> Null </summary>
    public float currentHp { get; }

    /// <summary> Update hps </summary>
    public CurrentHPArgs(float newHp)
    {
        this.currentHp = newHp;
    }
}
