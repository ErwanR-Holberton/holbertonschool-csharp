using System;
using System.Collections.Generic;

class LList
{
    public static LinkedListNode<int> Insert(LinkedList<int> myLList, int n)
    {
        int index = 0;

        foreach (int value in myLList)
            if (value < n)
                index++;
            else
                break;

        LinkedListNode<int> newNode = null;
        if (index == 0)
        {
            myLList.AddFirst(n);
            newNode = myLList.First;
        }
        else if (index == myLList.Count)
        {
            myLList.AddLast(n);
            newNode = myLList.Last;
        }
        else
        {
            LinkedListNode<int> currentNode = myLList.First;
            for (int i = 0; i < index - 1; i++)
                currentNode = currentNode.Next;
            newNode = myLList.AddAfter(currentNode, n);
        }

        return newNode;
    }
}
