using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.AlgoExpert.Easy
{
    //https://www.algoexpert.io/questions/Linked%20List%20Construction
    public class Program
    {
        public class DoublyLinkedList
        {
            public Node Head;
            public Node Tail;

            //O(1) time | O(1) space
            public void SetHead(Node node)
            {
                if(Head == null)
                {
                    Head = node;
                    Tail = node;
                    return;
                }

                InsertBefore(Head, node);
            }

            //O(1) time | O(1) space
            public void SetTail(Node node)
            {
                if(Tail == null)
                {
                    SetHead(node);
                    return;
                }

                InsertAfter(Tail, node);
            }

            //O(p) time | O(1) space
            public void InsertAtPosition(int position, Node nodeToInsert)
            {
                if (position == 1)
                {
                    SetHead(nodeToInsert);
                    return;
                }
                Node current = Head;
                int currentPosition = 1;
                while(current!=null && currentPosition!=position)
                {
                    current = current.Next;
                    currentPosition += 1;
                }
                if (current != null)
                {
                    InsertBefore(current, nodeToInsert);
                }
                else
                    SetTail(nodeToInsert);
            }

            //O(1) time | O(1) space
            public void InsertBefore(Node node, Node nodeToInsert)
            {
                //Only node in the linked list
                if (nodeToInsert == Head && nodeToInsert == Tail)
                    return;
                Remove(nodeToInsert);
                nodeToInsert.Prev = node.Prev;
                nodeToInsert.Next = node;
                if(node.Prev == null)
                {
                    Head = nodeToInsert;
                }
                else
                {
                    node.Prev.Next = nodeToInsert;
                }
                node.Prev = nodeToInsert;
            }

            //O(1) time | O(1) space
            public void InsertAfter(Node node, Node nodeToInsert)
            {
                if (nodeToInsert.Next == Head && nodeToInsert == Tail)
                    return;
                //Just in case
                Remove(nodeToInsert);
                nodeToInsert.Next = node.Next;
                nodeToInsert.Prev = node;
                if(node.Next == null)
                {
                    Tail = nodeToInsert;
                }
                else
                {
                    node.Next.Prev = nodeToInsert;
                }
                node.Next = nodeToInsert;
            }

            //O(n) time | O(1) space
            public void RemoveNodesWithValue(int value)
            {
                Node current = Head;
                while(current!=null)
                {
                    Node potentialToRemove = current;
                    current = current.Next;
                    if(potentialToRemove.Value == value)
                    {
                        Remove(potentialToRemove);
                    }
                }
            }

            //O(1) time | O(1) space
            public void Remove(Node node)
            {
                if (node == Head)
                {
                    Head = Head.Next;
                }

                if (node == Tail)
                {
                    Tail = Tail.Prev;
                }
                
                RemoveNodeBindings(node);                                 
            }

            //O(n) time | O(1) space
            public bool ContainsNodeWithValue(int value)
            {
                Node current = Head;
                while(current!=null && current.Value != value)                        
                    current = current.Next;
                return current!=null;
            }

            private void RemoveNodeBindings(Node node)
            {
                if (node.Prev != null)
                    node.Prev.Next = node.Next;
                if (node.Next != null)
                    node.Next.Prev = node.Prev;
                node.Prev = null;
                node.Next = null;
            }
        }

        public class Node
        {
            public int Value;
            public Node Prev;
            public Node Next;

            public Node(int value)
            {
                this.Value = value;
            }
        }
    }
}
