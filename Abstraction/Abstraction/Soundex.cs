using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public class Soundex
    {
        Dictionary<char, int> CharCodes = new Dictionary<char, int>();
        string ZERO_CODE_LETTERS = "AEIOUHWY";
        string ONE_CODE_LETTERS = "BFPV";
        string TWO_CODE_LETTERS = "CGJKQSXZ";

        public string GetCode(string testName)
        {
            // Construct dictionary
            foreach (var ch in ZERO_CODE_LETTERS)
            {
                CharCodes.Add(ch, 0);
            }

            foreach (var ch in ONE_CODE_LETTERS)
            {
                CharCodes.Add(ch, 1);
            }

            foreach (var ch in TWO_CODE_LETTERS)
            {
                CharCodes.Add(ch, 2);
            }

            // Setup Code String
            string firstLetter = testName[0].ToString();
            var remainingLetters = testName.Skip(1).Take(testName.Length - 2).ToArray();
            string myString = firstLetter;
            
            foreach (var c in remainingLetters)
            {
                myString += CharCodes[char.ToUpper(c)].ToString();
            }            

            return myString.Substring(0,4);
        }              
    }
}
