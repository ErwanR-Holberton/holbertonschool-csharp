﻿/// <summary> Base class </summary>
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
public class TestObject : Base, IInteractive, IBreakable, ICollectable
{

    /// <summary> durability </summary>
    public int durability { get; set; }
    /// <summary> isCollected </summary>
    public bool isCollected { get; set; }
    /// <summary> interect </summary>
    public void Interact()
    {

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
