using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neoris.Ionleap.CrossCutting.Utils.Common
{
    public static class Strings
    {
        public static string ToCapitalLetter(string stringInput)
        {
            if (string.IsNullOrEmpty(stringInput))
            {
                return default(string);
            }

            string returnString = stringInput.First().ToString().ToUpper() + stringInput.Substring(1);

            if (stringInput.Contains(' '))
            {
                var spitted = stringInput.Split(' ');
                returnString = "";

                if (spitted.Any())
                {
                    bool removeLastCharacter = true;
                    foreach (var s in spitted)
                    {
                        if (s == "")
                        {
                            removeLastCharacter = false;
                            break;
                        }
                        returnString += s.First().ToString().ToUpper() + s.Substring(1).ToLower() + " ";
                    }

                    if (removeLastCharacter)
                    {
                        returnString = returnString.Remove(returnString.Length - 1);
                    }
                }
            }

            return returnString;
        }

        public static bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }

        public static int CountCharacter(string str, char character)
        {
            return str.Count(c => c == character);
        }
    }
}
