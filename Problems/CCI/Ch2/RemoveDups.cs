using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.CCI.Ch2
{
    class RemoveDupsSolution
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        /*public static void Main(string[] args)
        {
            ListNode llist = new ListNode(1);
            llist.next = new ListNode(8);
            llist.next.next = new ListNode(3);
            llist.next.next.next = new ListNode(8);
            llist.next.next.next.next = new ListNode(3);
            Console.WriteLine("Before: "); PrintList(llist);
            RemoveDups(llist);
            Console.WriteLine("After: "); PrintList(llist);
            llist = null;


            llist = new ListNode(1);
            llist.next = new ListNode(8);
            llist.next.next = new ListNode(3);
            Console.WriteLine("Before: "); PrintList(llist);
            RemoveDups(llist);
            Console.WriteLine("After: "); PrintList(llist);
            llist = null;

            llist = new ListNode(1);
            llist.next = new ListNode(8);
            llist.next.next = new ListNode(8);
            llist.next.next.next = new ListNode(8);
            llist.next.next.next.next = new ListNode(8);
            Console.WriteLine("Before: "); PrintList(llist);
            RemoveDups(llist);
            Console.WriteLine("After: "); PrintList(llist);
            llist = null;
        }*/

        public static ListNode RemoveDups(ListNode head)
        {
            if (head == null)
                return head;

            Dictionary<int, ListNode> seenUnseen = new Dictionary<int, ListNode>();
            ListNode root = head;
            ListNode previous = null;
            while(root!=null)
            {
                if (!seenUnseen.ContainsKey(root.val))
                {
                    seenUnseen.Add(root.val, root);
                    previous = root;                    
                }
                //Contains duplicates
                else
                {
                    previous.next = root.next;                    
                }
                root = root.next;
            }

            return head;
        }

        public static void PrintList(ListNode head)
        {
            StringBuilder sb = new StringBuilder();
            while(head!=null)
            {
                sb.Append(String.Format(head.next == null ? "{0}" : "{0}->", head.val));
                head = head.next;
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
