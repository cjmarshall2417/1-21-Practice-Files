using System;
using System.Collections.Generic;

namespace TimeComplexityPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11 };

            // O(1)
            numbers[1] = 3;

            //O(N)
            int sum = 0;
            foreach(int i in numbers)
            {
                sum += i;
            }

            //O(N2)
            int duplicates = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                for(int j = 0; j < numbers.Length; j++)
                {
                    if(i != j)
                    {
                        if(numbers[i] == numbers[j])
                        {
                            duplicates++;
                            break;
                        }
                    }
                }
            }
            var numbersList = new List<int>(numbers);
            numbersList.Sort();
            //O(log n)
            int currentPosition = numbersList.Count / 2;
            int maxPosition = numbersList.Count - 1;
            int minPosition = 0;
            int valueToFind = 1;
            int indexOfValue = -1;

            while (indexOfValue == -1)//would be bad if you didn't know value was in list
            {
                currentPosition = (maxPosition + minPosition) / 2;
                if (numbersList[currentPosition] == valueToFind)
                {
                    indexOfValue = currentPosition;
                }
                else if (numbersList[currentPosition] > valueToFind)
                {
                    maxPosition = currentPosition;
                }
                else
                {
                    minPosition = currentPosition + 1;
                }
            }
            Console.WriteLine(indexOfValue);
        }
    }
}
