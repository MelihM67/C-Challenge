using System;
using System.Text;

namespace OldPhonePad
{
    /// <summary>
    /// Simulates an old phone keypad input.
    /// </summary>
    public class OldPhonePad
    {
        // Maps keypad numbers to their corresponding characters
        private static readonly string[] KeypadMap =
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

        /// <summary>
        /// Converts old phone keypad button presses into text.
        /// </summary>
        /// <param name="input">
        /// Sequence of digit presses. Spaces indicate pauses, '*' acts as backspace,
        /// and '#' ends the input.
        /// </param>
        /// <returns>The decoded text message.</returns>
        public static string OldPhone(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            var result = new StringBuilder();
            char currentButton = '\0';
            int pressCount = 0;

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

                if (!char.IsDigit(c))
                    continue;

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

            // Handle any remaining buffered input
            ProcessCurrentButton(result, currentButton, pressCount);

            return result.ToString();
        }

        /// <summary>
        /// Processes the current button press sequence and appends the result.
        /// </summary>
        private static void ProcessCurrentButton(StringBuilder result, char button, int count)
        {
            if (button == '\0' || count <= 0)
                return;

            int buttonIndex = button - '0';

            if (buttonIndex < 0 || buttonIndex >= KeypadMap.Length)
                return;

            string letters = KeypadMap[buttonIndex];

            if (letters.Length == 0)
                return;

            int letterIndex = (count - 1) % letters.Length;
            result.Append(letters[letterIndex]);
        }
    }
}
