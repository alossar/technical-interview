using System;
using System.Collections.Generic;
using TechnicalInterview.DataStructures;

namespace TechnicalInterview.Questions
{
    public class InorderTraversal : Question
    {
        public IList<int> Solution(TreeNode root)
        {
            IList<int> result = new List<int>();
            InorderTraversalIterative(root, result);
            return result;
        }

        private void InorderTraversalSolution(TreeNode root, IList<int> result)
        {
            if (root == null)
            {
                return;
            }
            InorderTraversalSolution(root.left, result);
            result.Add(root.val);
            InorderTraversalSolution(root.right, result);
        }

        private void InorderTraversalIterative(TreeNode root, IList<int> result)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = root;
            while (stack.Count > 0 || current != null)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                current = stack.Pop();
                result.Add(current.val);
                current = current.right;
            }
        }

        public override void Test()
        {
            TreeNode tree = new TreeNode(1);
            tree.right = new TreeNode(2);
            tree.right.left = new TreeNode(3);
            IList<int> result = Solution(tree);
            Console.WriteLine(result);
        }
    }
}
