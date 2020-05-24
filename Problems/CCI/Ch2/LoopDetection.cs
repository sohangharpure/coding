using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.CCI.Ch2
{
    class LoopDetectionSolution
    {
        public class ListNode
        {
            public char val;
            public ListNode next = null;
            public ListNode(char x) { val = x; }
        }

        /*public static void Main(string[] args)
        {
            ListNode dupe = new ListNode('C');

            ListNode llist = new ListNode('A');            
            llist.next = new ListNode('B');
            llist.next.next = dupe;
            llist.next.next.next = new ListNode('D');
            llist.next.next.next.next = new ListNode('E');
            llist.next.next.next.next.next = dupe;
            Console.WriteLine((DetectLoop(llist).val));
        }*/

        //Given a circular linked list, implement an algorithm that returns the node at
        //the beginning of the loop
        //For example: 
        //input = A -> B -> C -> D -> E -> C
        //output = C
        public static ListNode DetectLoop(ListNode root)
        {
            ListNode head = root;
            Dictionary<char, ListNode> seenUnseen = new Dictionary<char, ListNode>();
            while (head != null)
            {
                if (!seenUnseen.ContainsKey(head.val))
                {
                    seenUnseen.Add(head.val, head);                    
                }
                //Contains duplicates
                else
                {
                    if (head.next == seenUnseen[head.val].next)
                        return seenUnseen[head.val];
                }
                head = head.next;
            }
            return root;
        }
    }
}
