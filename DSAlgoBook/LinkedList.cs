using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgoBook
{

    public class Node<T>
    {
        public T data { get; }
        public Node<T> next { get; set; }

        public Node(T data)
        {
            this.data = data;
            this.next = null;
        }
    }

    public class LinkedList<T>
    {
        public Node<T> head { get; set; }

        public LinkedList()
        {
            head = null;
        }

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            if (head == null)
                head = node;
            else
            {
                Node<T> current = head;
                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = node;
            }
                
        }

        public void ReversePrintIterative()
        {
            Node<T> prev, current, next;
            current = head;
            prev = null;
            while (current!=null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            Display(prev);
            
        }

        public void ReversePrintRecursive(Node<T> node)
        {
            if (node == null)
                return;

            ReversePrintRecursive(node.next);

            Console.WriteLine($"{node.data.ToString()} ->");
        }

        public void ReverseList(Node<T> node)
        {
            if(node.next == null)
            {
                head = node;
                return;
            }

            ReverseList(node.next);

            Node<T> temp = node.next;
            temp.next = node;
            node.next = null;
        }

        public void Display(Node<T> node = null)
        {
            //
            Node<T> currNode = node!=null ? node : head;
            StringBuilder stringBuilder = new StringBuilder();
            while (currNode != null)
            {
                stringBuilder.Append($"{currNode.data.ToString()} -> ");
                currNode = currNode.next;
            }
            Console.WriteLine(stringBuilder.ToString());
        }
    }

    public class LinkedListOperations
    {
        /*public static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);
            linkedList.Display();
            //linkedList.ReversePrintIterative();
            //linkedList.ReversePrintRecursive(linkedList.head);
            linkedList.ReverseList(linkedList.head);
            linkedList.Display();
        }*/
    }
}
