namespace LeetCode
{
    public interface IProblemsSolution
    {
        ListNode AddTwoNumbers(ListNode l1, ListNode l2);
        TreeNode BstToGst(TreeNode root);
        bool CanBeEqual(int[] target, int[] arr);
        int CountCollisions(string directions);
        ListNode DoubleIt(ListNode head);
        string[] FindRelativeRanks(int[] score);
        int[][] LargestLocal(int[][] grid);
        bool LemonadeChange(int[] bills);
        long MaxPoints(int[][] points);
        ListNode MergeKLists(ListNode[] lists);
        ListNode MergeTwoLists(ListNode list1, ListNode list2);
        int RangeSum(int[] nums, int n, int left, int right);
        ListNode RemoveElements(ListNode head, int val);
        ListNode RemoveNthFromEnd(ListNode head, int n);
        ListNode RotateRight(ListNode head, int k);
        ListNode SwapPairs(ListNode head);
        int[] TwoSum(int[] nums, int target);
    }
}