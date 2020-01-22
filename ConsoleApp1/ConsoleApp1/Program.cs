using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            for(int i = 1; i <= 10; i++)
            {
                linkedList.AddLast(i);
            }

            DisplayLinkedListValues(linkedList);
            
            ReverseLinkedList(ref linkedList);

            DisplayLinkedListValues(linkedList);

            RotateList(ref linkedList);

            DisplayLinkedListValues(linkedList);

            linkedList.Last.Value = 15;

            DisplayLinkedListValues(linkedList);

            linkedList.AddLast(15);

            var nodeArray = NodesWithValue(linkedList, 15);

            Console.WriteLine(nodeArray.Length);

            ReplaceValue(ref linkedList, 15, 10);

            DisplayLinkedListValues(linkedList);

            Console.WriteLine(IsPalindrome(linkedList));

            LinkedList<int> palindromeList = new LinkedList<int>();

            palindromeList.AddLast(1);
            palindromeList.AddLast(2);
            palindromeList.AddLast(3);
            palindromeList.AddLast(2);
            palindromeList.AddLast(1);

            Console.WriteLine(IsPalindrome(palindromeList));
        }

        public static void ReverseLinkedList(ref LinkedList<int> linkedList)
        {
            int[] llArray = new int[linkedList.Count];
            linkedList.CopyTo(llArray, 0);

            Array.Reverse(llArray);

            linkedList = new LinkedList<int>(llArray);

            //return new LinkedList<int>(llArray);

        }

        public static void DisplayLinkedListValues(LinkedList<int> linkedList)
        {
            string result = "";
            foreach (int i in linkedList)
            {
                result += i + " ";
            }

            Console.WriteLine(result.Trim());
        }

        public static void RotateList(ref LinkedList<int> linkedList)
        {
            LinkedListNode<int> first = new LinkedListNode<int>(linkedList.First.Value);
            linkedList.AddLast(first);
            linkedList.RemoveFirst();
        }

        public static LinkedListNode<int>[] NodesWithValue(LinkedList<int> linkedList, int value)
        {
            LinkedListNode<int> currentNode = linkedList.First;
            List<LinkedListNode<int>> validNodes = new List<LinkedListNode<int>>();

            for (int i = 0; i < linkedList.Count; i++)
            {
                if (currentNode.Value == value)
                {
                    validNodes.Add(currentNode);
                }
                currentNode = currentNode.Next;
            }

            return validNodes.ToArray();

        }

        public static void ReplaceValue(ref LinkedList<int> linkedList, int replace, int value)
        {
            LinkedListNode<int> currentNode = linkedList.First;
            for (int i = 0; i < linkedList.Count; i++)
            {
                if (currentNode.Value == replace)
                {
                    currentNode.Value = value;
                }
                currentNode = currentNode.Next;
            }

        }

        public static int SumNodes(LinkedList<int> linkedList)
        {
            int sum = 0;
            LinkedListNode<int> currentNode = linkedList.First;
            for (int i = 0; i < linkedList.Count; i++)
            {
                sum += currentNode.Value;
                currentNode = currentNode.Next;
            }

            return sum;
        }
        
        public static bool IsPalindrome(LinkedList<int> linkedList)
        {
            int counter = linkedList.Count / 2;
            bool palindrome = true;
            LinkedListNode<int> firstNode = linkedList.First;
            LinkedListNode<int> lastNode = linkedList.Last;
            for(int i = 0; i < counter; i++)
            {
                if(firstNode.Value != lastNode.Value)
                {
                    palindrome = false;
                    break;
                }

                firstNode = firstNode.Next;
                lastNode = lastNode.Previous;
            }

            return palindrome;


        }
    }
}
