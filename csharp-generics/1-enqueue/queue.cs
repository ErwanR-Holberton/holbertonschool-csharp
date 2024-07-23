using System;

/// <summary>
/// a generic queue
/// </summary>
/// <typeparam name="T">The type of elements in the queue.</typeparam>
public class Queue<T>
{
	Node head, tail;
	int count = 0;

	/// <summary>
	/// Returns the type of the elements.
	/// </summary>
	/// <returns>The type of elements</returns>
	public Type CheckType()
	{
		return typeof(T);
	}

	/// <summary>
	/// Node class
	/// </summary>
	public class Node
	{
		T value;

		/// <summary>
		/// next node
		/// </summary>
		public Node next = null;

		/// <summary>
		/// create a node
		/// </summary>
		public Node(T value_input)
		{
			value = value_input;
		}
	}

	/// <summary>
	/// add node to queue
	/// </summary>
	public void Enqueue(T value)
	{
		Node newNode = new Node(value);
		if (head == null)
			head = tail = newNode;
		else
		{
			newNode.next = head;
			head = newNode;
		}
		count += 1;
	}

	/// <summary>
	/// return lenght of queue
	/// </summary>
	public int Count()
	{
		return count;
	}

}
