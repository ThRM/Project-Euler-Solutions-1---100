/*
 * Purpose:
 * Find the sum of all numbers less than one million that are
 * palindromic in both base 10 and base 2.
 *
 * Approach:
 * Each odd number below one million is tested for being a
 * decimal palindrome. If it passes, its binary representation
 * is constructed and checked for the same property.
 *
 * Numbers that are palindromic in both bases are added to
 * the final sum.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem36 {
    class Program {
        static void Main(string[] args) {
            // Running total of double-base palindromes.
            int sum = 0;

            // Only odd numbers need to be tested since
            // binary palindromes cannot end in zero.
            for (int i = 1; i < 1000000; i+= 2) {
                // Reverse the decimal representation.
                int temp = i;
                int reverse = 0;
                while(temp != 0) {
                    reverse *= 10;
                    reverse += temp % 10;
                    temp /= 10;
                }

                // Check whether the decimal representation
                // is a palindrome.
                if (i == reverse) {
                    // Find the highest power of two not
                    // less than the current number.
                    int pow = 0;
                    int binaryDigit = -1;
                    do {
                        binaryDigit++;
                        pow = (int)Math.Pow(2, binaryDigit);
                    }while(pow < i);

                    // Construct the binary representation
                    // and its reverse simultaneously.
                    String s = "";
                    String r = "";

                    temp = i;
                    if(temp == pow) {
                        temp -= pow;
                        s = "1";
                        r = "1";
                    }

                    for (int j = binaryDigit - 1; 0 <= j; j--) {
                        pow = (int)Math.Pow(2, j);

                        if (pow <= temp) {
                            temp -= pow;
                            s = String.Concat(s, "1");
                            r = String.Concat("1", r);
                        } else {
                            s = String.Concat(s, "0");
                            r = String.Concat("0", r);
                        }
                    }

                    // Check whether the binary representation
                    // is also a palindrome.
                    if (s.CompareTo(r) == 0) {
                        sum += i;
                    }
                }
            }

            // Display the final sum.
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}