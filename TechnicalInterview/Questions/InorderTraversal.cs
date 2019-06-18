using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalInterview
{
    public partial class Question
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> result = new List<int>();
            InorderTraversalIterative(root, result);
            return result;
        }

        private void InorderTraversal(TreeNode root, IList<int> result)
        {
            if (root == null)
            {
                return;
            }
            InorderTraversal(root.left, result);
            result.Add(root.val);
            InorderTraversal(root.right, result);
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
    }
}
