using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Leetcode
{
    //https://leetcode.com/problems/add-two-numbers/

    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class AddTwoNumbersSolution
    {
        /*public static void Main(string[] args)
        {
            AddTwoNumbersSolution solution = new AddTwoNumbersSolution();

            ListNode list1 = new ListNode(1);
            list1.next = new ListNode(8);
            //list1.next.next = new ListNode(3);

            ListNode list2 = new ListNode(0);
            //list2.next = new ListNode(6);
            //list2.next.next = new ListNode(4);

            solution.AddTwoNumbers(list1, list2);
        }*/
    
        //Time complexity = O(max(m ,n))
        //Space complexity = max(m ,n) + 1
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode(0);
            ListNode num1 = l1, num2 = l2, curr = head;

            int carry = 0;

            while (num1 != null || num2 != null)
            {
                int x = (num1 != null) ? num1.val : 0;
                int y = (num2 != null) ? num2.val : 0;

                int sum = x + y + carry;

                carry = sum / 10;

                curr.next = new ListNode(sum % 10);

                curr = curr.next;
                if (num1 != null) num1 = num1.next;
                if (num2 != null) num2 = num2.next;
            }

            if (carry > 0)
            {
                curr.next = new ListNode(carry);
            }

            return head.next;

        }
    }
}
