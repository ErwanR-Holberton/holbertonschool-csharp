using System;

/// <summary>
/// a generic queue
/// </summary>
/// <typeparam name="T">The type of elements in the queue.</typeparam>
public class Queue<T>
{
	public Type CheckType()
	{
		return typeof(T);
	}
}
