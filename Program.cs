using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(alternate("cwomzxmuelmangtosqkgfdqvkzdnxerhravxndvomhbokqmvsfcaddgxgwtpgpqrmeoxvkkjunkbjeyteccpugbkvhljxsshpoymkryydtmfhaogepvbwmypeiqumcibjskmsrpllgbvc"));
            Console.ReadLine();
        }

        public static int alternate(string s)
        {
            //base cases
            if (s.Length < 2)
            {
                return 0;
            }

            if (AllAlternatingCharacters(s))
            {
                return s.Length;
            }

            SortedSet<char> characters = new SortedSet<char>(s);           
            List<char> uniqueCharacters = new List<char>(characters);            
            List<string> resultsWithAlternatingCharacters = new List<string>();
            
            string[,] results = new string[uniqueCharacters.Count, uniqueCharacters.Count];

            for (int i = 0; i < s.Length; i++)
            {
                for (int c = 0; c < uniqueCharacters.Count; c++)
                {
                    // fill column (if last character in cell is the same as current character)
                    
                    if (results[c, uniqueCharacters.IndexOf(s[i])] == s[i].ToString())
                    {
                        results[c, uniqueCharacters.IndexOf(s[i])] = "1"; // put a number to invalidate the cell and it can't be accidentally marked as alternating
                    }
                                
                    else
                    {
                        results[c, uniqueCharacters.IndexOf(s[i])] += s[i].ToString();  ///correct
                    }

                }// fill row
                for (int r = 0; r < uniqueCharacters.Count; r++)
                {
                    if(results[uniqueCharacters.IndexOf(s[i]), r] == s[i].ToString())   
                    {
                        results[uniqueCharacters.IndexOf(s[i]), r] = "1"; // remove cell as it has non alternating characters
                    }
                    else
                    {
                        results[uniqueCharacters.IndexOf(s[i]), r] += s[i].ToString(); ///correct
                    }
                }                
            }

            List<string> alternatingStrings = new List<string>();
            foreach (string result in results)
            {
                if (AllAlternatingCharacters(result))
                {
                    alternatingStrings.Add(result);
                }
            }            
            return LongestStringInList(alternatingStrings);
        }

        public static bool AllAlternatingCharacters(string str)
        {
            //base cases
            if (str.Length < 2 || str[0] == str[1])
            {
                return false;
            }
            int count = 0;
            // if even indices match, and odd indices match, they are alternating characters
            for (int i = 0; i < str.Length; i++)
            {
                if((i % 2 == 0 && str[i] == str[0]) || i % 2 != 0 && str[i] == str[1])
                {
                    count++;
                }                 
            }           
            if (count == str.Length)
            {
                return true;
            }
            return false;
        }

        public static int LongestStringInList(List<string> items)
        {          
            if (items.Count > 0)
            {
                items.Sort((b, a) => a.Length.CompareTo(b.Length));
            }
            else
            {
                return 0;
            }
            return items[0].Length;
        }
    }
}      
            

        
