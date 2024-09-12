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

        public int GetLucky(string s, int k)
        {

            Dictionary<char, string> alphabetDict = new Dictionary<char, string>();
            for (int i = 0; i < 26; i++)
            {
                char letter = (char)('a' + i);  // Calculate the letter
                string position = (i + 1).ToString();  // Calculate the position (1-based)
                alphabetDict[letter] = position;
            }
            string sn = "";
            for (int i = 0; i < s.Length; i++)
            {
                sn += alphabetDict[s[i]];
            }
            //make transformation k times 
            for (int i = 0; i < k; i++)
            {
                sn = transform(sn);
            }
            // parse result and return
            return int.Parse(sn);
        }
        private string transform(string word)
        {
            string newstring = "";
            int sum = 0;
            for (int i = 0; i < word.Length; i++)
            {
                sum += word[i] - '0';
            }
            return sum.ToString();
        }

        public string ReverseWords(string s)
        {
            string result = "";
            List<string> reverse = new List<string>();
            string word = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    word += s[i];
                }
                if ((s[i] == ' ' || i == (s.Length) - 1) && word != "")
                {
                    reverse.Add(word);
                    word = "";
                }
            }
            Console.WriteLine(reverse.Last());
            for (int i = (reverse.Count) - 1; i >= 0; i--)
            {
                result += reverse[i];
                if (i != 0)
                    result += " ";
            }
            return result.Trim();
        }

        public int SumRange(int[] arr, int left, int right)
        {
            //get commulative sum array
            arr=transfereToComulativeSumm(arr);
            if (left == 0)
            {
                return arr[right];
            }
            else
            {
                return arr[right] - arr[left - 1];
            }
        }
        private int[] transfereToComulativeSumm(int[] array)
        {
            int comulativeSum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                comulativeSum += array[i];
                array[i] = comulativeSum;
            }
            return array;
        }

        public int FindMaxLength(int[] nums)
        {
            Dictionary<int, int> keepSums = new();
            keepSums[-1] = -1;
            int difference = -1;
            int count0 = 0, count1 = 0;
            int max = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                difference = nums[i] == 0 ? difference - 1 : difference + 1;
                if (keepSums.ContainsKey(difference))
                {
                    max = Math.Max(max, i - keepSums[difference]);
                }
                else
                {
                    keepSums[difference] = i;
                }
            }
            return max;
        }

        public int SubarraySum(int[] nums, int k)
        {
            int totalNum = 0, commulativeSum = 0;
            Dictionary<int, int> keepSums = new();
            keepSums[0] = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                commulativeSum += nums[i];
                if (keepSums.ContainsKey(commulativeSum - k))
                {
                    totalNum += keepSums[commulativeSum - k];
                }
                keepSums[commulativeSum] = keepSums.ContainsKey(commulativeSum) ? keepSums[commulativeSum] + 1 : 1;
            }
            return totalNum;
        }

        public int[] ProductExceptSelf(int[] nums)
        {
            int[] prefix = new int[nums.Length];
            int[] suffix = new int[nums.Length];
            int[] result = new int[nums.Length];
            int prodpre = 1, prodsuf = 1;
            for (int i = 0, j = nums.Length - 1; i < nums.Length && j >= 0; i++, j--)
            {
                prodpre = prodpre * nums[i];
                prodsuf = prodsuf * nums[j];
                prefix[i] = prodpre;
                suffix[j] = prodsuf;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    result[i] = suffix[1];
                }
                else if (i == nums.Length - 1)
                {
                    result[i] = prefix[i - 1];
                }
                else
                {
                    result[i] = prefix[i - 1] * suffix[i + 1];
                }
            }
            return result;
        }

        public ListNode[] SplitListToParts(ListNode head, int k)
        {
            int listSize = 0;
            ListNode dummy = head;
            while (dummy != null)
            {
                listSize++;
                dummy = dummy.next;
            }
            int derivedListSize = listSize / k;
            int reminder = listSize % k;
            int keepPartSize = 0, keepFirstElements = 0, arrayIndex = 0;
            ListNode[] result = new ListNode[k];
            ListNode keepHead = head;
            while (keepHead != null)
            {
                //first part
                if (arrayIndex == 0)
                {
                    result[arrayIndex] = keepHead;
                    arrayIndex++;
                    //keepHead = keepHead.next;
                    keepPartSize++;
                    keepFirstElements++;
                }
                //add
                else if (keepPartSize < derivedListSize || (keepPartSize == derivedListSize && keepFirstElements <= reminder))
                {
                    keepHead = keepHead.next;
                    keepPartSize++;
                }
                //nextPart
                else
                {
                    ListNode nextPart = keepHead.next;
                    keepHead.next = null;
                    keepHead = nextPart;
                    if (arrayIndex < k)
                    {
                        result[arrayIndex] = keepHead;
                        arrayIndex++;
                        keepPartSize = 1;
                        keepFirstElements++;
                    }

                }
            }
            return result;
        }

        public int[][] SpiralMatrix(int m, int n, ListNode head)
        {
            int directionIndex = 0;
            int[][] result = new int[m][];
            for (int i = 0; i < m; i++)
            {
                result[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    result[i][j] = -1;
                }
            }
            int row = 0, col = 0;
            while (head != null)
            {
                result[row][col] = head.val;
                if ((row == m - 1 && directionIndex == 1) || (col == n - 1 && directionIndex == 0) || (col == 0 && directionIndex == 2))
                {
                    directionIndex = (directionIndex + 1) % 4;
                }
                else
                {
                    if (row < m - 1 && row != 0)
                    {
                        if ((result[row + 1][col] != -1 && directionIndex == 1) || (result[row - 1][col] != -1 && directionIndex == 3))
                        {
                            directionIndex = (directionIndex + 1) % 4;
                        }
                    }
                    if (col < n - 1 && col != 0)
                    {
                        if ((result[row][col + 1] != -1 && directionIndex == 0) || (result[row][col - 1] != -1 && directionIndex == 2))
                        {
                            directionIndex = (directionIndex + 1) % 4;
                        }
                    }
                }
                if (directionIndex == 0)
                    col++;
                else if (directionIndex == 1)
                    row++;
                else if (directionIndex == 2)
                    col--;
                else
                    row--;
                head = head.next;
            }
            return result;
        }

        public ListNode InsertGreatestCommonDivisors(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode previous = head, current = head.next;
            while (current != null)
            {
                ListNode GCDNode = getGreatestCommonDivisor(previous.val, current.val);
                previous.next = GCDNode;
                GCDNode.next = current;
                //
                previous = current;
                current = current.next;
            }
            return head;
        }
        private ListNode getGreatestCommonDivisor(int first, int second)
        {
            int GCD = 1;
            int smallest = first < second ? first : second;
            for (int i = 1; i <= smallest; i++)
            {
                if (first % i == 0 && second % i == 0)
                {
                    GCD = i;
                }
            }
            ListNode result = new ListNode(GCD);
            return result;
        }

        public int MinBitFlips(int start, int goal)
        {
            string sbinary = Convert.ToString(start, 2);
            string gbinary = Convert.ToString(goal, 2);
            int steps = 0;
            while (sbinary.Length != gbinary.Length)
            {
                if (sbinary.Length < gbinary.Length)
                {
                    sbinary = sbinary.Insert(0, "0");
                }
                else if (sbinary.Length > gbinary.Length)
                {
                    gbinary = gbinary.Insert(0, "0");
                }
            }
            int length = gbinary.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                if (sbinary[i] != gbinary[i])
                    steps++;
            }
            return steps;
        }

        public int CountConsistentStrings(string allowed, string[] words)
        {
            var allowedChars = new HashSet<char>(allowed);
            int result = 0;
            bool check;
            for (int i = 0; i < words.Length; i++)
            {
                check = false;
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (!allowedChars.Contains(words[i][j]))
                    {
                        check = true;
                        break;
                    }
                }
                if (check == false)
                    result++;
            }
            return result;
        }

        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; (j - i <= k) && j != nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                        return true;
                }
            }
            return false;
        }
    }
}
