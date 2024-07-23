using System;

/// <summary> Base class </summary>
public abstract class Base
{
    /// <summary> variable </summary>
    public string name { get; set; }
    /// <summary> Print name and type </summary>
    public override string ToString()
    {
        return $"{name} is a {GetType().Name}";
    }
}
/// <summary> interface </summary>
public interface IInteractive
{
    /// <summary> interect </summary>
    void Interact();
}
/// <summary> interface </summary>
public interface IBreakable
{
    /// <summary> durability </summary>
    int durability { get; set; }
    /// <summary> break </summary>
    void Break();
}
/// <summary> interface </summary>
public interface ICollectable
{
    /// <summary> isCollected </summary>
    bool isCollected { get; set; }
    /// <summary> collect </summary>
    void Collect();
}

/// <summary> Test class </summary>
public class Door : Base, IInteractive
{

    /// <summary> durability </summary>
    public int durability { get; set; }
    /// <summary> isCollected </summary>
    public bool isCollected { get; set; }

    /// <summary> Constructor </summary>
    public Door(string input_name = "Door")
    {
        name = input_name;
    }

    /// <summary> interect </summary>
    public void Interact()
    {
        Console.WriteLine($"You try to open the {name}. It's locked.");
    }
    /// <summary> break </summary>
    public void Break()
    {

    }
    /// <summary> collect </summary>
    public void Collect()
    {

    }
}
/// <summary> Decoration class </summary>
public class Decoration : Base, IInteractive, IBreakable
{

    /// <summary> durability </summary>
    public int durability { get; set; }
    /// <summary> isQuestItem </summary>
    public bool isQuestItem;

    /// <summary> Constructor </summary>
    public Decoration(string input_name = "Decoration", int in_dura = 1, bool in_questit = false)
    {
        if (in_dura <= 0)
            throw new Exception("Durability must be greater than 0");
        name = input_name;
        durability = in_dura;
        isQuestItem = in_questit;
    }

    /// <summary> interect </summary>
    public void Interact()
    {
        if (durability <= 0)
            Console.WriteLine($"The {name} has been broken.");
        else if (isQuestItem == true)
            Console.WriteLine($"You look at the {name}. There's a key inside.");
        else
            Console.WriteLine($"You look at the {name}. Not much to see here.");
    }
    /// <summary> break </summary>
    public void Break()
    {
        durability -= 1;
        if(durability > 0 )
            Console.WriteLine($"You hit the {name}. It cracks.");
        else if (durability == 0)
            Console.WriteLine($"You smash the {name}. What a mess.");
        else
            Console.WriteLine($"The {name} is already broken.");
    }
}
