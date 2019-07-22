using System;
using System.Collections.Generic;
using TechnicalInterview.DataStructures;

namespace TechnicalInterview.Questions
{
    public class ZigzagLevelOrderTraversal : Question
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Stack<TreeNode> evenLevelQueue = new Stack<TreeNode>();
            Stack<TreeNode> unevenLevelQueue = new Stack<TreeNode>();
            unevenLevelQueue.Push(root);

            bool isEven = false;
            while (evenLevelQueue.Count > 0 || unevenLevelQueue.Count > 0)
            {
                if (isEven) result.Add(GetLevel(evenLevelQueue, unevenLevelQueue, isEven));
                else result.Add(GetLevel(unevenLevelQueue, evenLevelQueue, isEven));

                isEven = !isEven;
            }
            return result;
        }

        private IList<int> GetLevel(Stack<TreeNode> level, Stack<TreeNode> opposite, bool isEven)
        {
            TreeNode current = null;
            IList<int> result = new List<int>();
            while (level.Count > 0)
            {
                current = level.Pop();
                if (!isEven)
                {
                    if (current.left != null) opposite.Push(current.left);
                    if (current.right != null) opposite.Push(current.right);
                }
                else
                {
                    if (current.right != null) opposite.Push(current.right);
                    if (current.left != null) opposite.Push(current.left);
                }
                result.Add(current.val);
            }
            return result;
        }

        public override void Test()
        {
            TreeNode tree = new TreeNode(1);
            tree.right = new TreeNode(2);
            tree.right.left = new TreeNode(3);
            IList<IList<int>> result = ZigzagLevelOrder(tree);
            Console.WriteLine(result);
        }
    }
}
