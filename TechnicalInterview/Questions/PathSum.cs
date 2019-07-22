using System;
using TechnicalInterview.DataStructures;

namespace TechnicalInterview.Questions
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
    public class PathSum : Question
    {
        public bool Solution(TreeNode root, int sum)
        {
            if (root == null)
                return false;
            if (root.val == sum && root.left == null && root.right == null)
                return true;
            return Solution(root.left, sum - root.val) || Solution(root.right, sum - root.val);
        }

        public override void Test()
        {
            throw new NotImplementedException();
        }
    }
}
