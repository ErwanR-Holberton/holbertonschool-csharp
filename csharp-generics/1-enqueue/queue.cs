using System;


public class Queue<T>
{
	Node head, tail;
	int count = 0;

	public Type CheckType()
	{
		return typeof(T);
	}
	public class Node
	{
		T value;
		public Node next = null;

		public Node(T value_input)
		{
			value = value_input;
		}
	}
	public void Enqueue(T value)
	{
		Node newNode = new Node(value);
		if (head == null)
			head = tail = newNode;
		else
		{
			newNode.next = tail;
			tail = newNode;
		}
		count += 1;
	}
	public int Count()
	{
		return count;
	}

}
