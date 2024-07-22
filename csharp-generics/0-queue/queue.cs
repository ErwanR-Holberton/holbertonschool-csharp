using System;

/// <summary>
/// a generic queue
/// </summary>
/// <typeparam name="T">The type of elements in the queue.</typeparam>
public class Queue<T>
{
	/// <summary>
	/// Returns the type of the elements.
	/// </summary>
	/// <returns>The type of elements</returns>
	public Type CheckType()
	{
		return typeof(T);
	}
}
