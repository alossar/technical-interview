using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalInterview
{
    public partial class Question
    {
        /// <summary>
        /// Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum.
        /// Note: A leaf is a node with no children.
        /// Example:
        ///     Given the below binary tree and sum = 22,
        ///     
        ///           5
        ///          / \
        ///         4   8
        ///        /   / \
        ///       11  13  4
        ///      /  \    / \
        ///     7    2  5   1
        ///     Return: true
        ///     
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public bool PathSum(TreeNode root, int sum)
        {
            if (root == null)
                return false;
            if (root.val == sum && root.left == null && root.right == null)
                return true;
            return PathSum(root.left, sum - root.val) || PathSum(root.right, sum - root.val);
        }
    }
}
