using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode
{
    public class ProblemsSolution : IProblemsSolution
    {
      
        public int[][] LargestLocal(int[][] grid)
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
     
        public string[] FindRelativeRanks(int[] score)
        {
            string[] output = new string[score.Length];
            int[] sorted = new int[score.Length];
            Array.Copy(score, sorted, score.Length);
            Array.Sort(sorted);
            int flag = 1;
            for (int i = sorted.Length - 1; i >= 0; i--)
            {
                int index = Array.IndexOf(score, sorted[i]);
                if (flag == 1)
                {
                    output[index] = "Gold Medal";
                    flag++;
                }
                else if (flag == 2)
                {
                    output[index] = "Silver Medal";
                    flag++;
                }
                else if (flag == 3)
                {
                    output[index] = "Bronze Medal";
                    flag++;
                }
                else
                {
                    output[index] = flag.ToString();
                    flag++;
                }
            }
            return output;
        }

        public int RangeSum(int[] nums, int n, int left, int right)
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
   
        public bool CanBeEqual(int[] target, int[] arr)
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
       
        public bool LemonadeChange(int[] bills)
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

        public int CountCollisions(string directions)
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
    
        public int[] TwoSum(int[] nums, int target)
        {
            int[] outt = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        outt[0] = i;
                        outt[1] = j;
                        return outt;
                    }
                }
            }
            return null;
        }

        public TreeNode BstToGst(TreeNode root)
        {
            int sum = 0;
            TransformTree(root, ref sum);
            return root;
        }
        private void TransformTree(TreeNode node, ref int sum)
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

        public long MaxPoints(int[][] points)
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
  
        public ListNode RemoveElements(ListNode head, int val)
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
  
        public ListNode RemoveNthFromEnd(ListNode head, int n)
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
    
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
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
                else if (list2 == null)
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
    
        public ListNode MergeKLists(ListNode[] lists)
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
   
        public ListNode SwapPairs(ListNode head)
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
   
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
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
     
        public ListNode DoubleIt(ListNode head)
        {
            BigInteger num;
            string final;
            StringBuilder sb = new StringBuilder();
            while (head != null)
            {
                sb.Append(head.val);
                head = head.next;
            }
            Console.WriteLine(sb.ToString());
            num = BigInteger.Parse(sb.ToString());
            num *= 2;
            final = num.ToString();
            Console.WriteLine(final);

            ListNode newHead = new ListNode(); // Create a new ListNode to hold the modified values
            ListNode tail = newHead; // Initialize tail to point to the head of the new linked list
            foreach (var i in final)
            {
                int value = (int)(char.GetNumericValue(i)); // Convert character to integer value
                ListNode newNode = new ListNode(value); // Create a new ListNode with the value
                tail.next = newNode; // Link the new node to the end of the list
                tail = newNode; // Update tail to point to the new node
            }

            return newHead.next; // Return the entire modified linked list (head of the new linked list)
        }

        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0)
                return head;
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            //getlength of the linked list
            int lengthL = 0;
            while (dummy.next != null)
            {
                lengthL++;
                dummy = dummy.next;
            }
            Console.WriteLine(lengthL);
            dummy = new ListNode(0);
            dummy.next = head;
            ListNode cur = dummy.next;
            ListNode prev = dummy;
            //rotata untill k%lenght because any rotation after because rotating a list n=length times results in the original list
            for (int i = 0; i < k % lengthL; i++)
            {
                while (cur.next != null)
                {
                    cur = cur.next;
                    prev = prev.next;
                }
                prev.next = null;
                cur.next = dummy.next;
                dummy.next = cur;
                prev = dummy;
            }
            return dummy.next;
        }

        public int ChalkReplacer(int[] chalk, int k)
        {
            //get sum of array numbers
            long arrsum = chalk.Sum(c => (long)c);
            k = (int)(k % arrsum);
            for (int i = 0; i < chalk.Length; i++)
            {
                if (k >= chalk[i])
                {
                    k -= chalk[i];
                }
                else
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
