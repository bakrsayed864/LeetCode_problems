using System.Collections.Generic;

namespace LeetCode
{
    public interface IProblemsSolution
    {
        /// <summary>
        /// You are given two non-empty linked lists representing two non-negative integers. 
        /// The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
        /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        /// </summary>
        /// 2. Add Two Numbers
        /// <returns></returns>
        ListNode AddTwoNumbers(ListNode l1, ListNode l2);

        /// <summary>
        /// Given the root of a Binary Search Tree (BST), convert it to a Greater Tree such that every key of the original BST is changed to the original key plus the sum of all keys greater than the original key in BST.
        /// As a reminder, a binary search tree is a tree that satisfies these constraints: The left subtree of a node contains only nodes with keys less than the node's key.
        /// The right subtree of a node contains only nodes with keys greater than the node's key. Both the left and right subtrees must also be binary search trees.
        /// </summary>
        /// 1038. Binary Search Tree to Greater Sum Tree
        /// <returns></returns>
        TreeNode BstToGst(TreeNode root);

        /// <summary>
        /// You are given two integer arrays of equal length target and arr. In one step, you can select any non-empty subarray of arr and reverse it. 
        /// You are allowed to make any number of steps.
        /// Return true if you can make arr equal to target or false otherwise.
        /// </summary>
        /// 1460. Make Two Arrays Equal by Reversing Subarrays
        /// <returns></returns>
        bool CanBeEqual(int[] target, int[] arr);

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
        int CountCollisions(string directions);

        /// <summary>
        /// You are given the head of a non-empty linked list representing a non-negative integer without leading zeroes.
        /// Return the head of the linked list after doubling it.
        /// </summary>
        /// 2816. Double a Number Represented as a Linked List
        /// <returns></returns>
        ListNode DoubleIt(ListNode head);

        /// <summary>
        /// You are given an integer array score of size n, where score[i] is the score of the ith athlete in a competition. All the scores are guaranteed to be unique.
        /// The athletes are placed based on their scores, where the 1st place athlete has the highest score, the 2nd place athlete has the 2nd highest score, and so on.The placement of each athlete determines their rank:
        /// The 1st place athlete's rank is "Gold Medal".
        /// The 2nd place athlete's rank is "Silver Medal".
        /// The 3rd place athlete's rank is "Bronze Medal".
        /// For the 4th place to the nth place athlete, their rank is their placement number(i.e., the xth place athlete's rank is "x").
        /// Return an array answer of size n where answer[i] is the rank of the ith athlete.
        /// </summary>
        /// 506. Relative Ranks
        /// <returns></returns>
        string[] FindRelativeRanks(int[] score);

        /// <summary>
        /// You are given an n x n integer matrix grid. Generate an integer matrix maxLocal of size(n - 2) x(n - 2) such that:
        /// maxLocal[i][j] is equal to the largest value of the 3 x 3 matrix in grid centered around row i + 1 and column j + 1.
        /// In other words, we want to find the largest value in every contiguous 3 x 3 matrix in grid.
        /// Return the generated matrix.
        /// </summary>
        /// 2373. Largest Local Values in a Matrix
        /// <returns></returns>
        int[][] LargestLocal(int[][] grid);

        /// <summary>
        /// At a lemonade stand, each lemonade costs $5. Customers are standing in a queue to buy from you and order one at a time (in the order specified by bills).
        /// Each customer will only buy one lemonade and pay with either a $5, $10, or $20 bill. 
        /// You must provide the correct change to each customer so that the net transaction is that the customer pays $5.
        /// Note that you do not have any change in hand at first.
        /// Given an integer array bills where bills[i] is the bill the ith customer pays, return true if you can provide every customer with the correct change, or false otherwise.
        /// </summary>
        /// 860. Lemonade Change
        /// <returns></returns>
        bool LemonadeChange(int[] bills);

        /// <summary>
        /// You are given an m x n integer matrix points (0-indexed). Starting with 0 points, you want to maximize the number of points you can get from the matrix
        /// To gain points, you must pick one cell in each row.Picking the cell at coordinates (r, c) will add points[r][c] to your score.
        /// However, you will lose points if you pick a cell too far from the cell that you picked in the previous row.For every two adjacent rows r and r + 1 (where 0 <= r<m - 1), picking cells at coordinates(r, c1) and(r + 1, c2) will subtract abs(c1 - c2) from your score.
        /// Return the maximum number of points you can achieve.
        /// abs(x) is defined as:
        /// </summary>
        /// 1937. Maximum Number of Points with Cost
        /// <returns></returns>
        long MaxPoints(int[][] points);

        /// <summary>
        /// You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
        /// Merge all the linked-lists into one sorted linked-list and return it.
        /// </summary>
        /// 23. Merge k Sorted Lists
        /// <param></param>
        ListNode MergeKLists(ListNode[] lists);

        /// <summary>
        /// You are given the heads of two sorted linked lists list1 and list2.
        ///Merge the two lists into one sorted list.The list should be made by splicing together the nodes of the first two lists.
        ///Return the head of the merged linked list.
        /// </summary>
        /// 21. Merge Two Sorted Lists
        /// <returns></returns>
        ListNode MergeTwoLists(ListNode list1, ListNode list2);

        /// <summary>
        /// You are given the array nums consisting of n positive integers. You computed the sum of all non-empty continuous subarrays from the array
        /// and then sorted them in non-decreasing order, creating a new array of n * (n + 1) / 2 numbers.
        /// Return the sum of the numbers from index left to index right(indexed from 1), inclusive, in the new array.Since the answer can be a huge number return it modulo 109 + 7.
        /// </summary>
        /// 1508. Range Sum of Sorted Subarray Sums
        /// <returns></returns>
        int RangeSum(int[] nums, int n, int left, int right);

        /// <summary>
        /// Given the head of a linked list and an integer val, remove all the nodes of the linked list that has Node.val == val, and return the new head.
        /// </summary>
        /// 203. Remove Linked List Elements
        /// <returns></returns>
        ListNode RemoveElements(ListNode head, int val);

        /// <summary>
        /// Given the head of a linked list, remove the nth node from the end of the list and return its head.
        /// </summary>
        /// 19. Remove Nth Node From End of List
        /// <param></param>
        ListNode RemoveNthFromEnd(ListNode head, int n);

        /// <summary>
        /// Given the head of a linked list, rotate the list to the right by k places.
        /// </summary>
        /// 61. Rotate List
        /// <returns></returns>
        ListNode RotateRight(ListNode head, int k);

        /// <summary>
        /// Given a linked list, swap every two adjacent nodes and return its head.
        /// You must solve the problem without modifying the values in the list's nodes (i.e., only nodes themselves may be changed.)
        /// </summary>
        /// 24. Swap Nodes in Pairs
        /// <returns></returns>
        ListNode SwapPairs(ListNode head);

        /// <summary>
        /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target
        /// You may assume that each input would have exactly one solution, and you may not use the same element twice.You can return the answer in any order.
        /// </summary>
        /// 1. Two Sum
        /// <returns></returns>
        int[] TwoSum(int[] nums, int target);

        /// <summary>
        /// You are given a 0-indexed integer array chalk and an integer k. There are initially k pieces of chalk. When the student number i is given a problem to solve, 
        /// they will use chalk[i] pieces of chalk to solve that problem. However, if the current number of chalk pieces is strictly less than chalk[i], 
        /// then the student number i will be asked to replace the chalk.
        /// </summary>
        /// 1894. Find the Student that Will Replace the Chalk
        /// <returns>Return the index of the student that will replace the chalk pieces.</returns>
        int ChalkReplacer(int[] chalk, int k);

        /// <summary>
        /// You are given a string s consisting of lowercase English letters, and an integer k.
        /// First, convert s into an integer by replacing each letter with its position in the alphabet(i.e., replace 'a' with 1, 'b' with 2, ..., 'z' with 26). Then, transform the integer by replacing it with the sum of its digits.Repeat the transform operation k times in total.
        /// For example, if s = "zbax" and k = 2, then the resulting integer would be 8 by the following operations:
        /// Convert: "zbax" ➝ "(26)(2)(1)(24)" ➝ "262124" ➝ 262124
        /// Transform #1: 262124 ➝ 2 + 6 + 2 + 1 + 2 + 4 ➝ 17
        /// Transform #2: 17 ➝ 1 + 7 ➝ 8
        /// </summary>
        /// 1945. Sum of Digits of String After Convert
        /// <returns>Return the resulting integer after performing the operations described above.</returns>
        public int GetLucky(string s, int k);

        /// <summary>
        /// Given an input string s, reverse the order of the words.
        /// A word is defined as a sequence of non-space characters.The words in s will be separated by at least one space.
        /// </summary>
        /// 151. Reverse Words in a String
        /// <returns>Return a string of the words in reverse order concatenated by a single space.</returns>
        public string ReverseWords(string s);

        /// <summary>
        /// Given an integer array nums, handle multiple queries of the following type:
        /// Calculate the sum of the elements of nums between indices left and right inclusive where left <= right.
        /// </summary>
        /// 303. Range Sum Query - Immutable
        /// <returns>Returns the sum of the elements of nums between indices left and right inclusive (i.e. nums[left] + nums[left + 1] + ... + nums[right]).</returns>
        public int SumRange(int[] arr, int left, int right);

        /// <summary>
        /// Given a binary array nums, return the maximum length of a contiguous subarray with an equal number of 0 and 1.
        /// </summary>
        /// 525. Contiguous Array
        /// <returns>return the maximum length of a contiguous subarray with an equal number of 0 and 1</returns>
        public int FindMaxLength(int[] nums);
       
        /// <summary>
        /// Given an array of integers nums and an integer k,A subarray is a contiguous non-empty sequence of elements within an array.
        /// </summary>
        /// 525. Contiguous Array
        /// <returns>return the total number of subarrays whose sum equals to k.</returns>
        public int SubarraySum(int[] nums, int k);
   
        /// <summary>
        /// Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
        /// </summary>
        /// 238. Product of Array Except Self
        /// <returns>return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].</returns>
        public int[] ProductExceptSelf(int[] nums);

        /// <summary>
        /// Given the head of a singly linked list and an integer k, split the linked list into k consecutive linked list parts.
        /// The length of each part should be as equal as possible: no two parts should have a size differing by more than one.This may lead to some parts being null.
        /// The parts should be in the order of occurrence in the input list, and parts occurring earlier should always have a size greater than or equal to parts occurring later.
        /// </summary>
        /// 725. Split Linked List in Parts
        /// <returns>Return an array of the k parts.</returns>
        public ListNode[] SplitListToParts(ListNode head, int k);
     
        /// <summary>
        /// You are given two integers m and n, which represent the dimensions of a matrix.
        /// You are also given the head of a linked list of integers.
        /// Generate an m x n matrix that contains the integers in the linked list presented in spiral order (clockwise), starting from the top-left of the matrix. 
        /// If there are remaining empty spaces, fill them with -1.
        /// </summary>
        /// 2326. Spiral Matrix IV
        /// <returns>Return the generated matrix.</returns>
        public int[][] SpiralMatrix(int m, int n, ListNode head);

        /// <summary>
        /// Given the head of a linked list head, in which each node contains an integer value.
        /// Between every pair of adjacent nodes, insert a new node with a value equal to the greatest common divisor of them.
        /// </summary>
        /// 2807. Insert Greatest Common Divisors in Linked List
        /// <returns>Return the linked list after insertion.</returns>
        public ListNode InsertGreatestCommonDivisors(ListNode head);

        /// <summary>
        /// A bit flip of a number x is choosing a bit in the binary representation of x and flipping it from either 0 to 1 or 1 to 0.
        /// Given two integers start and goal, return the minimum number of bit flips to convert start to goal.
        /// </summary>
        /// 2220. Minimum Bit Flips to Convert Number
        /// <returns>return the minimum number of bit flips to convert start to goal.</returns>
        public int MinBitFlips(int start, int goal);

        /// <summary>
        /// You are given a string allowed consisting of distinct characters and an array of strings words. 
        /// A string is consistent if all characters in the string appear in the string allowed.
        /// </summary>
        /// 1684. Count the Number of Consistent Strings.
        /// <returns>Return the number of consistent strings in the array words.</returns>
        public int CountConsistentStrings(string allowed, string[] words);

        /// <summary>
        /// Given an integer array nums and an integer k, 
        /// return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.
        /// </summary>
        /// 219. Contains Duplicate II
        /// <returns>return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k</returns>
        public bool ContainsNearbyDuplicate(int[] nums, int k);

        /// <summary>
        /// We define a harmonious array as an array where the difference between its maximum value and its minimum value is exactly 1.
        /// Given an integer array nums, return the length of its longest harmonious subsequence among all its possible subsequences.
        /// </summary>
        /// 594. Longest Harmonious Subsequence
        /// <returns>return the length of its longest harmonious subsequence among all its possible subsequences.</returns>
        public int FindLHS(int[] nums);

        /// <summary>
        /// You are given an array arr of positive integers. You are also given the array queries where queries[i] = [lefti, righti]
        /// For each query i compute the XOR of elements from lefti to righti(that is, arr[lefti] XOR arr[lefti + 1] XOR ... XOR arr[righti] ).
        /// </summary>
        /// 1310. XOR Queries of a Subarray.
        /// <returns>Return an array answer where answer[i] is the answer to the ith query.</returns>
        public int[] XorQueries(int[] arr, int[][] queries);

        /// <summary>
        /// You are given an integer array nums of size n.
        /// Consider a non-empty subarray from nums that has the maximum possible bitwise AND.
        /// </summary>
        /// 2419. Longest Subarray With Maximum Bitwise AND
        /// <returns>Return the length of the longest such subarray.</returns>
        public int LongestSubarray(int[] nums);

        /// <summary>
        /// Given the string s, return the size of the longest substring containing each vowel an even number of times.
        /// That is, 'a', 'e', 'i', 'o', and 'u' must appear an even number of times.
        /// </summary>
        /// 1371. Find the Longest Substring Containing Vowels in Even Counts
        /// <returns>return the size of the longest substring containing each vowel an even number of times.</returns>
        public int FindTheLongestSubstring(string s);

        /// <summary>
        /// Given a list of 24-hour clock time points in "HH:MM" format, return the minimum minutes difference between any two time-points in the list.
        /// </summary>
        /// 539. Minimum Time Difference
        /// <returns>return the minimum minutes difference between any two time-points in the list.</returns>
        public int FindMinDifference(IList<string> timePoints);
    }
}