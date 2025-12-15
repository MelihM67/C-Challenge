using System;

namespace OldPhonePad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Old Phone Keypad Tests ===\n");

            // Test the examples from the challenge
            Test("33#", "E");
            Test("227*#", "b");
            Test("4433555 555666#", "HELLO");
        }

        static void Test(string input, string expected)
        {
            string result = OldPhonePad.OldPhone(input);
            string status = result == expected ? "PASS" : "FAIL";
            Console.WriteLine($"{status}: Input: {input} => Output: {result} (Expected: {expected})");
        }
    }
}