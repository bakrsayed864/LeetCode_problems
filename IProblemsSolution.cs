﻿namespace LeetCode
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
    }
}