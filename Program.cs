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
        public static ListNode RemoveElements(ListNode head, int val)
        {
            ListNode dummy=new ListNode(0);
            if (head == null)
                return null;
            else
            {
                //dummy = null;
                dummy.next = head;
                ListNode prev = dummy.next;
                ListNode cur = dummy.next;
               
                while (cur != null||(prev.val==val&&prev!=null)&&dummy.next!=null)
                {
                    //cur = cur.next;
                    if (dummy.next.val == val)
                    {
                        dummy.next = cur==null? null:cur.next;
                        prev = dummy==null? null:prev.next;
                        cur = prev==null? null:prev.next;
                    }
                    else if (cur.val == val)
                    {
                        prev.next = cur.next;
                        cur = cur.next;
                    }
                    else
                    {
                        prev = prev.next;
                        cur = prev.next;
                    }
                }
                return dummy.next;
            }
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
