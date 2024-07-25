using System;
using System.Collections.Generic;

/// <summary> Base class </summary>
public abstract class Base
{
    /// <summary> variable </summary>
    public string name { get; set; }
    /// <summary> Print name and type </summary>
    public override string ToString()
    {
        return $"{name} is a {this.GetType()}";
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
}
/// <summary> Decoration class </summary>
public class Decoration : Base, IInteractive, IBreakable
{

    /// <summary> durability </summary>
    public int durability { get; set; }
    /// <summary> isQuestItem </summary>
    public bool isQuestItem;

    /// <summary> Constructor </summary>
    public Decoration(string name = "Decoration", int durability = 1, bool isQuestItem = false)
    {
        if (durability <= 0)
            throw new Exception("Durability must be greater than 0");
        this.name = name;
        this.durability = durability;
        this.isQuestItem = isQuestItem;
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
        if (durability > 0)
            Console.WriteLine($"You hit the {name}. It cracks.");
        else if (durability == 0)
            Console.WriteLine($"You smash the {name}. What a mess.");
        else
            Console.WriteLine($"The {name} is already broken.");
    }
}
/// <summary> Key class </summary>
public class Key : Base, ICollectable
{
    /// <summary> isCollected </summary>
    public bool isCollected { get; set; }

    /// <summary> Constructor </summary>
    public Key(string name = "Key", bool isCollected = false)
    {
        this.name = name;
        this.isCollected = isCollected;
    }

    /// <summary> Collect </summary>
    public void Collect()
    {
        if (isCollected == false)
        {
            isCollected = true;
            Console.WriteLine($"You pick up the {name}.");
        }
        else
            Console.WriteLine($"You have already picked up the {name}.");
    }
}
/// <summary> RoomObjects class </summary>
public class RoomObjects
{
    /// <summary> Use every action possible </summary>
    public static void IterateAction(List<Base> roomObjects, Type type)
    {
        roomObjects.ForEach(item => {
            if (item is IInteractive interactive && type == typeof(IInteractive))
                interactive.Interact();
            else if (item is IBreakable breakable && type == typeof(IBreakable))
                breakable.Break();
            else if (item is ICollectable collectable && type == typeof(ICollectable))
                collectable.Collect();
        });
    }
}
