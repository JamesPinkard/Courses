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
        string THREE_CODE_LETTERS = "DT";
        string FOUR_CODE_LETTERS = "MN";
        string FIVE_CODE_LETTERS = "L";
        string SIX_CODE_LETTERS = "R";

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

            foreach (var ch in THREE_CODE_LETTERS)
            {
                CharCodes.Add(ch, 3);
            }

            foreach (var ch in FOUR_CODE_LETTERS)
            {
                CharCodes.Add(ch, 4);
            }

            foreach (var ch in FIVE_CODE_LETTERS)
            {
                CharCodes.Add(ch, 5);
            }

            foreach (var ch in SIX_CODE_LETTERS)
            {
                CharCodes.Add(ch, 6);
            }

            // Setup Code String
            string firstLetter = testName[0].ToString();
            var remainingLetters = testName.Skip(1).Take(testName.Length - 2).ToArray();
            string myString = firstLetter;
            
            foreach (var c in remainingLetters)
            {
                myString += CharCodes[char.ToUpper(c)].ToString();
            }

            string myCode = firstLetter;
            string remainingCode = myString.Substring(1, myString.Length - 1);

            char dupCheck = '0';
            foreach (var numChar in remainingCode)
            {
                if (numChar != '0')
                {
                    if (numChar != dupCheck)
                    {
                        myCode += numChar;
                        dupCheck = numChar;
                    }
                }
            }          

            if (myCode.Length < 4)
            {
                int padding = 4 - myCode.Length;
                for (int i = 0; i < padding; i++)
                {
                    myCode += '0';
                }
            }

            return myCode.Substring(0, 4);
        }              
    }
}
