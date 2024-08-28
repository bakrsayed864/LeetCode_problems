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

        /// <summary>
        /// Given the head of a linked list, remove the nth node from the end of the list and return its head.
        /// </summary>
        /// 19. Remove Nth Node From End of List
        /// <param></param>
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            int listCount = 0;
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode cur = dummy.next;
            ListNode prev = dummy;
            while (head != null)
            {
                listCount++;
                head = head.next;
            }
            for (int i = 1; i < listCount - n + 1; i++)
            {
                cur = cur.next;
                prev = prev.next;
            }
            prev.next = cur.next;
            return dummy.next;
        }

        /// <summary>
        /// You are given the heads of two sorted linked lists list1 and list2.
        ///Merge the two lists into one sorted list.The list should be made by splicing together the nodes of the first two lists.
        ///Return the head of the merged linked list.
        /// </summary>
        /// 21. Merge Two Sorted Lists
        /// <returns></returns>
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode dummy = new ListNode(0);
            ListNode dummyNode = dummy;
            while (list1 != null || list2 != null)
            {
                if (list1 == null)
                {
                    dummyNode.next = list2;
                    dummyNode = dummyNode.next;
                    list2 = list2.next;
                }
                else if(list2 == null)
                {
                    dummyNode.next = list1;
                    dummyNode = dummyNode.next;
                    list1 = list1.next;
                }
                else if (list1.val < list2.val)
                {
                    dummyNode.next = list1;
                    dummyNode = dummyNode.next;
                    list1 = list1.next;
                }
                else if (list2.val < list1.val)
                {
                    dummyNode.next = list2;
                    dummyNode = dummyNode.next;
                    list2 = list2.next;
                }
                else
                {
                    dummyNode.next = list1;
                    dummyNode = dummyNode.next;
                    list1 = list1.next;
                    dummyNode.next = list2;
                    dummyNode = dummyNode.next;
                    list2 = list2.next;
                }
            }
            return dummy.next;
        }
        static void Main(string[] args)
        {
            ListNode list1  = new ListNode(1);
            ListNode next1 = new ListNode(2);
            ListNode next2 = new ListNode(4);
            ListNode list2 = new ListNode(1);

            ListNode next4 = new ListNode(3);
            ListNode next5 = new ListNode(4);

            list1.next = next1;
            next1.next = next2;
            list2.next = next4;
            next4.next = next5;
            MergeTwoLists(list1,list2);
        }
    }
}
