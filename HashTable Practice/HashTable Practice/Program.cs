using System;
using System.Collections;
using System.Collections.Generic;
namespace HashTable_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, "blue");
            hashtable.Add(2, "red");
            hashtable.Add(3, "green");
            hashtable.Add("blue", "orange");

            Console.WriteLine(hashtable[1]);
            Console.WriteLine(hashtable["blue"]);

            hashtable.Remove("blue");

            DisplayHashtable(hashtable);

            Console.WriteLine(FindKeyForValue(hashtable, "blue"));

            string testString = "blue blue blue red red green orange orange blue red yellow";

            DisplayHashtable(HashTableOfWordOccurrences(testString));

            
        }
        //returns a hashtable based on a string that has each word in that string as a key 
        //and the number of occurences of that word as the value associated with that key
        public static Hashtable HashTableOfWordOccurrences(string value)
        {
            var words = value.Split(" ");

            Hashtable hashtableOfWords = new Hashtable();
            foreach(string word in words)
            {
                if(!hashtableOfWords.ContainsKey(word))
                {
                    hashtableOfWords.Add(word, 1);
                }
                else
                {
                   hashtableOfWords[word] = (int)hashtableOfWords[word] + 1; 
                }
            }

            return hashtableOfWords;
        }

        public static object FindKeyForValue(Hashtable hashtable, object value)
        {
            foreach(DictionaryEntry entry in hashtable)
            {
                if(entry.Value == value)
                {
                    return entry.Key;
                }
            }

            return null;
        }

        public static void DisplayHashtable(Hashtable hashtable)
        {
            foreach(DictionaryEntry entry in hashtable)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }
        }


    }
}
