using System;
using System.Collections.Generic;

namespace test
{
    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int val = 0, ListNode next = null)
       {
           this.val = val;
           this.next = next;
       }
    }
    internal class Program
    {
        /// <summary>
        /// Given the head of a linked list and an integer val, remove all the nodes of the linked list that has Node.val == val, and return the new head.
        /// </summary>
        /// 203. Remove Linked List Elements
        /// <returns></returns>
        public static ListNode RemoveElements(ListNode head, int val)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode prev = dummy;
            ListNode cur = head;
            while (cur != null)
            {
                if (cur.val == val)
                {
                    prev.next = cur.next;
                }
                else
                {
                    prev = prev.next;
                }
                cur = cur.next;
            }
            return dummy.next;
        }
        static void Main(string[] args)
        {
            ListNode head =new ListNode(2);
            ListNode next0 = new ListNode(2);
            ListNode next1 = new ListNode(2);
            ListNode next2 = new ListNode(2);
            ListNode next3 = new ListNode(2);
            //ListNode next4 = new ListNode(2);
            //ListNode next5 = new ListNode(2);

            head.next = next0;
            next0.next = next1;
            next1.next = next2;
            next2.next = next3;
            //next3.next = next4;
            //next4.next = next5;
            RemoveElements(head, 2);
        }
    }
}
