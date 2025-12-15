using System;
using System.Text;

namespace OldPhonePad
{
    public class OldPhonePad
    {
        private static readonly string[] KeypadMap = new string[]
        {
            "",      // 0
            "&'(",   // 1
            "ABC",   // 2
            "DEF",   // 3
            "GHI",   // 4
            "JKL",   // 5
            "MNO",   // 6
            "PQRS",  // 7
            "TUV",   // 8
            "WXYZ"   // 9
        };

        public static string OldPhone(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            var result = new StringBuilder();
            var currentButton = '\0';
            var pressCount = 0;

            foreach (char c in input)
            {
                if (c == '#')
                    break;

                if (c == '*')
                {
                    ProcessCurrentButton(result, currentButton, pressCount);
                    currentButton = '\0';
                    pressCount = 0;

                    if (result.Length > 0)
                        result.Length--;
                    
                    continue;
                }

                if (c == ' ')
                {
                    ProcessCurrentButton(result, currentButton, pressCount);
                    currentButton = '\0';
                    pressCount = 0;
                    continue;
                }

                if (char.IsDigit(c))
                {
                    if (c == currentButton)
                    {
                        pressCount++;
                    }
                    else
                    {
                        ProcessCurrentButton(result, currentButton, pressCount);
                        currentButton = c;
                        pressCount = 1;
                    }
                }
            }

            ProcessCurrentButton(result, currentButton, pressCount);

            return result.ToString();
        }

        private static void ProcessCurrentButton(StringBuilder result, char button, int count)
        {
            if (button == '\0' || count == 0)
                return;

            int buttonIndex = button - '0';
            
            if (buttonIndex < 0 || buttonIndex >= KeypadMap.Length)
                return;

            string letters = KeypadMap[buttonIndex];
            
            if (string.IsNullOrEmpty(letters))
                return;

            int letterIndex = (count - 1) % letters.Length;
            result.Append(letters[letterIndex]);
        }
    }
}