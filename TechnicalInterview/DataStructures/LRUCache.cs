using System.Collections.Generic;

namespace TechnicalInterview.DataStructures
{
    public class LRUCache
    {
        public class DoubleLinkedListNode
        {
            public DoubleLinkedListNode Next { get; set; }
            public DoubleLinkedListNode Prev { get; set; }
            public int Value { get; set; }
            public int Key { get; set; }
        }

        Dictionary<int, DoubleLinkedListNode> memory;
        DoubleLinkedListNode head;
        DoubleLinkedListNode tail;
        int maxCapacity;
        int currentCapacity;

        public LRUCache(int capacity)
        {
            memory = new Dictionary<int, DoubleLinkedListNode>();
            maxCapacity = capacity;
            currentCapacity = 0;
        }

        public int Get(int key)
        {
            if (!memory.ContainsKey(key)) return -1;
            DoubleLinkedListNode current = memory[key];
            current.Prev = current.Next;
            head.Prev = current;
            current.Next = head;
            current.Prev = null;
            head = current;
            return head.Value;
        }

        public void Put(int key, int value)
        {
            if (!memory.ContainsKey(key))
            {
                DoubleLinkedListNode current = new DoubleLinkedListNode()
                {
                    Value = value,
                    Key = key
                };
                if (maxCapacity == currentCapacity)
                {
                    memory.Remove(tail.Key);
                    tail = tail.Prev;
                }
                else
                    currentCapacity++;

                if(head == null)
                {
                    head = current;
                    tail = current;
                }
                else
                {
                    current.Prev = tail;
                    tail.Next = current;
                    tail = current;
                }
                memory[key] = tail;
            }
        }
    }
}
