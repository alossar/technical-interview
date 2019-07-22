using System;
using TechnicalInterview.DataStructures;

namespace TechnicalInterview.Questions
{
    /// <summary>
    /// Given a singly linked list, group all odd nodes together followed by the even nodes. Please note here we are talking about the node number and not the value in the nodes.
    /// You should try to do it in place.The program should run in O(1) space complexity and O(nodes) time complexity.
    /// Example 1:
    ///      Input: 1->2->3->4->5->NULL
    ///      Output: 1->3->5->2->4->NULL
    /// Example 2:
    ///      Input: 2->1->3->5->6->4->7->NULL
    ///      Output: 2->3->6->7->1->5->4->NULL
    /// Note:
    ///      The relative order inside both the even and odd groups should remain as it was in the input.
    ///      The first node is considered odd, the second node even and so on ...
    /// </summary>
    public class OddEvenList : Question
    {
        public ListNode Solution(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode odd = head;
            ListNode even = head.next;
            ListNode firstOdd = odd;
            ListNode firstEven = even;

            ListNode current = head.next.next;
            int step = 1;

            while (current != null)
            {
                if (step % 2 == 0)
                {
                    even.next = current;
                    even = even.next;
                }
                else
                {
                    odd.next = current;
                    odd = odd.next;
                }
                current = current.next;
                step++;
            }
            odd.next = firstEven;
            even.next = null;
            return firstOdd;
        }

        public override void Test()
        {
            ListNode a = new ListNode(1);
            a.next = new ListNode(2);
            a.next.next = new ListNode(3);
            a.next.next.next = new ListNode(4);
            a.next.next.next.next = new ListNode(5);

            ListNode r = Solution(a);
            while (r != null)
            {
                Console.Write($"{r.val} ");
                r = r.next;
            }
        }
    }
}
