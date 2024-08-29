using System;
using System.Collections.Generic;
using System.Linq;

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
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
       {
           this.val = val;
           this.left = left;
           this.right = right;
       }
  }
    internal class Program
    {
        /// <summary>
        /// You are given an n x n integer matrix grid. Generate an integer matrix maxLocal of size(n - 2) x(n - 2) such that:
        /// maxLocal[i][j] is equal to the largest value of the 3 x 3 matrix in grid centered around row i + 1 and column j + 1.
        /// In other words, we want to find the largest value in every contiguous 3 x 3 matrix in grid.
        /// Return the generated matrix.
        /// </summary>
        /// 2373. Largest Local Values in a Matrix
        /// <returns></returns>
        public static int[][] LargestLocal(int[][] grid)
        {
            int[][] generated = new int[grid.Length - 2][];
            for (int i = 0; i < generated.Length; i++)
            {
                generated[i] = new int[grid[i].Length - 2];
                for (int j = 0; j < generated[i].Length; j++)
                {
                    int x = i + 1;
                    int y = j + 1;
                    generated[i][j] = Enumerable.Max(new[] {
                    grid[x][y],grid[x - 1][y - 1], grid[x - 1][y], grid[x - 1][y + 1],
                    grid[x][y - 1], grid[x][y + 1],
                    grid[x + 1][y - 1], grid[x + 1][y], grid[x + 1][y + 1]
                    });
                }
            }
            return generated;
        }

        /// <summary>
        /// You are given the array nums consisting of n positive integers. You computed the sum of all non-empty continuous subarrays from the array
        /// and then sorted them in non-decreasing order, creating a new array of n * (n + 1) / 2 numbers.
        /// Return the sum of the numbers from index left to index right(indexed from 1), inclusive, in the new array.Since the answer can be a huge number return it modulo 109 + 7.
        /// </summary>
        /// 1508. Range Sum of Sorted Subarray Sums
        /// <returns></returns>
        public static int RangeSum(int[] nums, int n, int left, int right)
        {
            const int MOD = 1000000007;
            List<int> list = new List<int>();

            // Compute all subarray sums
            for (int i = 0; i < nums.Length; i++)
            {
                int sum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    sum = (sum + nums[j]) % MOD;
                    list.Add(sum);
                }
            }

            // Convert list to array and sort
            int[] numbersArray = list.ToArray();
            Array.Sort(numbersArray);

            // Calculate the sum from left to right (1-based index)
            int result = 0;
            for (int i = left - 1; i < right; i++)
            {
                result = (result + numbersArray[i]) % MOD;
            }
            return result;
        }

        /// <summary>
        /// You are given two integer arrays of equal length target and arr. In one step, you can select any non-empty subarray of arr and reverse it. 
        /// You are allowed to make any number of steps.
        /// Return true if you can make arr equal to target or false otherwise.
        /// </summary>
        /// 1460. Make Two Arrays Equal by Reversing Subarrays
        /// <returns></returns>
        public static bool CanBeEqual(int[] target, int[] arr)
        {
            Array.Sort(target);
            Array.Sort(arr);
            for (int i = 0; i < target.Length; i++)
            {
                if (target[i] != arr[i])
                    return false;
            }
            return true;
        }
        /// <summary>
        /// At a lemonade stand, each lemonade costs $5. Customers are standing in a queue to buy from you and order one at a time (in the order specified by bills).
        /// Each customer will only buy one lemonade and pay with either a $5, $10, or $20 bill. 
        /// You must provide the correct change to each customer so that the net transaction is that the customer pays $5.
        /// Note that you do not have any change in hand at first.
        /// Given an integer array bills where bills[i] is the bill the ith customer pays, return true if you can provide every customer with the correct change, or false otherwise.
        /// </summary>
        /// 860. Lemonade Change
        /// <returns></returns>
        public static bool LemonadeChange(int[] bills)
        {
            int count_5 = 0;
            int count_10 = 0;
            for (int i = 0; i < bills.Length; i++)
            {
                if (bills[i] == 5)
                    count_5++;
                else if (bills[i] == 10)
                {
                    if (count_5 > 0)
                    {
                        count_5--;
                        count_10++;
                    }
                    else return false;
                }
                else
                {
                    if (count_5 >= 1 && count_10 >= 1)
                    {
                        count_5--;
                        count_10--;
                    }
                    else if (count_5 >= 3)
                    {
                        count_5 -= 3;
                    }
                    else return false;
                }
            }
            return true;
        }

        /// <summary>
        /// There are n cars on an infinitely long road. The cars are numbered from 0 to n - 1 from left to right and each car is present at a unique point.
        /// You are given a 0-indexed string directions of length n.directions[i] can be either 'L', 'R', or 'S' denoting whether the ith car is moving towards the left, towards the right, or staying at its current point respectively.Each moving car has the same speed.
        /// The number of collisions can be calculated as follows:
        /// When two cars moving in opposite directions collide with each other, the number of collisions increases by 2.
        /// When a moving car collides with a stationary car, the number of collisions increases by 1
        /// After a collision, the cars involved can no longer move and will stay at the point where they collided. Other than that, cars cannot change their state or direction of motion.
        /// Return the total number of collisions that will happen on the road.
        /// </summary>
        /// 2211. Count Collisions on a Road
        /// <returns></returns>
        public static int CountCollisions(string directions)
        {
            int collisions = 0;
            char[] cars = directions.ToCharArray();

            // Process collisions
            for (int i = 0; i < cars.Length; i++)
            {
                // Check for left moving car colliding with a stationary or right moving car
                if (cars[i] == 'L' && i > 0 && (cars[i - 1] == 'R' || cars[i - 1] == 'S'))
                {
                    collisions += (cars[i - 1] == 'R') ? 2 : 1;
                    cars[i] = 'S';
                    cars[i - 1] = 'S';
                }
                // Check for right moving car colliding with a stationary car
                else if (cars[i] == 'R' && i < cars.Length - 1 && cars[i + 1] == 'S')
                {
                    collisions += 1;
                    cars[i] = 'S';
                }
            }

            // Process remaining right moving cars that collide with stationary cars
            for (int i = cars.Length - 1; i >= 0; i--)
            {
                if (cars[i] == 'R' && i < cars.Length - 1 && (cars[i + 1] == 'L' || cars[i + 1] == 'S'))
                {
                    collisions += (cars[i + 1] == 'L') ? 2 : 1;
                    cars[i] = 'S';
                    cars[i + 1] = 'S';
                }
            }

            return collisions;
        }

        /// <summary>
        /// Given the root of a Binary Search Tree (BST), convert it to a Greater Tree such that every key of the original BST is changed to the original key plus the sum of all keys greater than the original key in BST.
        /// As a reminder, a binary search tree is a tree that satisfies these constraints: The left subtree of a node contains only nodes with keys less than the node's key.
        /// The right subtree of a node contains only nodes with keys greater than the node's key. Both the left and right subtrees must also be binary search trees.
        /// </summary>
        /// 1038. Binary Search Tree to Greater Sum Tree
        /// <returns></returns>
        public static TreeNode BstToGst(TreeNode root)
        {
            int sum = 0;
            TransformTree(root, ref sum);
            return root;
        }
        private static void TransformTree(TreeNode node, ref int sum)
        {
            if (node == null)
            {
                return;
            }

            // Traverse the right subtree first
            TransformTree(node.right, ref sum);

            // Update the current node's value with the cumulative sum
            sum += node.val;
            node.val = sum;

            // Traverse the left subtree
            TransformTree(node.left, ref sum);
        }

        /// <summary>
        /// You are given an m x n integer matrix points (0-indexed). Starting with 0 points, you want to maximize the number of points you can get from the matrix
        /// To gain points, you must pick one cell in each row.Picking the cell at coordinates (r, c) will add points[r][c] to your score.
        /// However, you will lose points if you pick a cell too far from the cell that you picked in the previous row.For every two adjacent rows r and r + 1 (where 0 <= r<m - 1), picking cells at coordinates(r, c1) and(r + 1, c2) will subtract abs(c1 - c2) from your score.
        /// Return the maximum number of points you can achieve.
        /// abs(x) is defined as:
        /// </summary>
        /// 1937. Maximum Number of Points with Cost
        /// <returns></returns>
        public static long MaxPoints(int[][] points)
        {
            int m = points.Length;
            int n = points[0].Length;

            // DP array to store the max points up to the current row
            long[] dp = new long[n];

            // Initialize the dp array with the first row
            for (int c = 0; c < n; c++)
            {
                dp[c] = points[0][c];
            }

            // Iterate over each row starting from the second one
            for (int r = 1; r < m; r++)
            {
                long[] newDp = new long[n];

                // Forward pass to accumulate left maximums
                long leftMax = dp[0];
                for (int c = 0; c < n; c++)
                {
                    leftMax = Math.Max(leftMax, dp[c] + c);
                    newDp[c] = leftMax + points[r][c] - c;
                }

                // Backward pass to accumulate right maximums
                long rightMax = dp[n - 1] - (n - 1);
                for (int c = n - 1; c >= 0; c--)
                {
                    rightMax = Math.Max(rightMax, dp[c] - c);
                    newDp[c] = Math.Max(newDp[c], rightMax + points[r][c] + c);
                }

                // Update dp array with the newDp values for the current row
                dp = newDp;
            }

            // The result will be the maximum value in the last dp array
            long maxPoints = 0;
            for (int c = 0; c < n; c++)
            {
                maxPoints = Math.Max(maxPoints, dp[c]);
            }

            return maxPoints;
        }

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

        /// <summary>
        /// You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
        /// Merge all the linked-lists into one sorted linked-list and return it.
        /// </summary>
        /// 23. Merge k Sorted Lists
        /// <param></param>
        public static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length > 1)
            {
                ListNode l1 = lists[0] == null ? null : lists[0];
                ListNode l2 = lists[1] == null ? null : lists[1];
                ListNode result = MergeTwoLists(l1, l2);
                for (int i = 2; i < lists.Length; i++)
                {
                    result = MergeTwoLists(lists[i], result);
                }
                return result;
            }
            else if (lists.Length == 1)
            {
                return lists[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Given a linked list, swap every two adjacent nodes and return its head.
        /// You must solve the problem without modifying the values in the list's nodes (i.e., only nodes themselves may be changed.)
        /// </summary>
        /// 24. Swap Nodes in Pairs
        /// <returns></returns>
        public static ListNode SwapPairs(ListNode head)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode first = dummy;
            ListNode cur, prev;
            if (head != null)
            {
                prev = first.next;
                cur = prev == null ? null : prev.next;
                while (cur != null)
                {
                    //swaping
                    first.next = prev.next;
                    prev.next = cur.next;
                    cur.next = prev;
                    //move to next
                    first = prev;
                    prev = first == null ? null : first.next;
                    cur = prev == null ? null : prev.next;
                }
                return dummy.next;
            }
            return head;
        }

        /// <summary>
        /// You are given two non-empty linked lists representing two non-negative integers. 
        /// The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
        /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        /// </summary>
        /// 2. Add Two Numbers
        /// <returns></returns>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode tail = new ListNode(0);
            ListNode keep = tail;
            int carry = 0;

            while (l1 != null || l2 != null || carry != 0)
            {
                int n1 = l1 != null ? l1.val : 0;
                int n2 = l2 != null ? l2.val : 0;
                int sum = n1 + n2 + carry;
                if (sum > 9)
                {
                    sum = sum - 10;
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }
                tail.next = new ListNode(sum);
                tail = tail.next;
                l1 = l1 != null ? l1.next : null;
                l2 = l2 != null ? l2.next : null;
            }

            return keep.next;
        }
        static void Main(string[] args)
        {
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
            SwapPairs(list1);
        }
    }
}
