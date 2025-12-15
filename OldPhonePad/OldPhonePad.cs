using System;
using System.Text;

namespace OldPhonePad
{
    public class OldPhonePad
    {
        public static string OldPhone(string input)
        {
            StringBuilder result = new StringBuilder();
            char currentButton = '\0';  // Current button being processed
            int pressCount = 0;         // Number of times the current button has been pressed

            foreach (char c in input)
            {
                if (c == '#')
                    break;
                
                // TODO: Add backspace (*) functionality
                
                if (c == ' ')
                {
                    // Process the pressed button
                    if (currentButton != '\0' && pressCount > 0)
                    {
                        int buttonIndex = currentButton - '0';
                        string letters = GetLettersForButton(buttonIndex);
                        if (letters.Length > 0)
                        {
                            int index = (pressCount - 1) % letters.Length;
                            result.Append(letters[index]);
                        }
                    }
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
                        // Process previous button before starting new one
                        if (currentButton != '\0' && pressCount > 0)
                        {
                            int buttonIndex = currentButton - '0';
                            string letters = GetLettersForButton(buttonIndex);
                            if (letters.Length > 0)
                            {
                                int index = (pressCount - 1) % letters.Length;
                                result.Append(letters[index]);
                            }
                        }
                        currentButton = c;
                        pressCount = 1;
                    }
                }
            }
            
            // Process any remaining button presses
            if (currentButton != '\0' && pressCount > 0)
            {
                int buttonIndex = currentButton - '0';
                string letters = GetLettersForButton(buttonIndex);
                if (letters.Length > 0)
                {
                    int index = (pressCount - 1) % letters.Length;
                    result.Append(letters[index]);
                }
            }

            return result.ToString();
        }

        private static string GetLettersForButton(int button)
        {
            string[] keypad = 
            { 
                "", 
                "&'(", 
                "ABC", 
                "DEF", 
                "GHI", 
                "JKL", 
                "MNO", 
                "PQRS", 
                "TUV", 
                "WXYZ" 
            };
            if (button >= 0 && button < keypad.Length)
                return keypad[button];
            return "";
        }
    }
}