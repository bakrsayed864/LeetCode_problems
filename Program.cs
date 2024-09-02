using LeetCode;
namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProblemsSolution problemsSolution = new ProblemsSolution();
            ListNode list1  = new ListNode(1);
            ListNode next1 = new ListNode(2);
            ListNode next2 = new ListNode(3);
            ListNode list2 = new ListNode(1);

            ListNode next4 = new ListNode(4);
            ListNode next5 = new ListNode(4);

            list1.next = next1;
            next1.next = next2;
            next2.next = next4;
            next4.next = next5;
            problemsSolution.SwapPairs(list1);
        }
    }
}
