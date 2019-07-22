namespace TechnicalInterview.DataStructures
{
    public class PointerTreeNode
    {
        public int val;
        public PointerTreeNode left;
        public PointerTreeNode right;
        public PointerTreeNode next;

        public PointerTreeNode() { }
        public PointerTreeNode(int _val, PointerTreeNode _left, PointerTreeNode _right, PointerTreeNode _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}
