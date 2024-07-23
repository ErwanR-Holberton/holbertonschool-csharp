/// <summary> Base class </summary>
public abstract class Base
{
    /// <summary> variable </summary>
    public string name;
    /// <summary> Print name and type </summary>
    public override string ToString()
    {
        return $"{name} is a {GetType().Name}";
    }
}
