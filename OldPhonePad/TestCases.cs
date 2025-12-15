using System;

namespace OldPhonePad
{
    class TestCases
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Old Phone Keypad Tests\n");

            // Examples from the challenge description
            Test("33#", "E");
            Test("227*#", "B");
            Test("4433555 555666#", "HELLO");
            Test("8 88777444666*664#", "TURING");

            Console.WriteLine("\nBasic button tests\n");

            Test("2#", "A");
            Test("22#", "B");
            Test("222#", "C");

            // wrap around behaviour
            Test("2222#", "A");

            Console.WriteLine("\nSpacing and grouping\n");

            Test("222 2 22#", "CAB");
            Test("44 444#", "HI");

            Console.WriteLine("\nDifferent buttons\n");

            Test("999#", "Y");
            Test("7777#", "S");

            Console.WriteLine("\nBackspace behaviour\n");

            Test("2*#", "");
            Test("222*2#", "A");
            Test("4433*5#", "HJ");

            Console.WriteLine("\nEdge cases\n");

            Test("0#", "");
            Test("#", "");
            Test("1#", "&");
            Test("11#", "'");

            Console.WriteLine("\nTests finished");
        }

        static void Test(string input, string expected)
        {
            string result = OldPhonePad.OldPhone(input);

            if (result == expected)
            {
                Console.WriteLine($"PASS  | \"{input}\" -> \"{result}\"");
            }
            else
            {
                Console.WriteLine($"FAIL  | \"{input}\" -> \"{result}\" (expected \"{expected}\")");
            }
        }
    }
}