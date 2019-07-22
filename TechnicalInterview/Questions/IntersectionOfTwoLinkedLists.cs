using System;
using TechnicalInterview.DataStructures;

namespace TechnicalInterview.Questions
{
    class IntersectionOfTwoLinkedLists : Question
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            //boundary check
            if (headA == null || headB == null) return null;

            ListNode a = headA;
            ListNode b = headB;

            //if a & b have different len, then we will stop the loop after second iteration
            while (a != b)
            {
                //for the end of first iteration, we just reset the pointer to the head of another linkedlist
                a = a == null ? headB : a.next;
                b = b == null ? headA : b.next;
            }

            return a;
        }

        public override void Test()
        {
            ListNode a = new ListNode(4);
            a.next = new ListNode(1);
            a.next.next = new ListNode(8);
            a.next.next.next = new ListNode(4);
            a.next.next.next.next = new ListNode(5);


            ListNode b = new ListNode(5);
            b.next = new ListNode(0);
            b.next.next = new ListNode(1);
            b.next.next.next = a.next.next;

            ListNode r = GetIntersectionNode(a, b);
            Console.WriteLine(r.val);
        }
    }
}
