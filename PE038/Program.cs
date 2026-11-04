/*
 * Purpose:
 * Find the largest 1 to 9 pandigital number that can be formed
 * as the concatenated product of an integer with (1, 2, ..., n)
 * for some n > 1.
 *
 * Approach:
 * For each starting integer, successive multiples are
 * concatenated until the resulting string reaches or exceeds
 * nine digits. Nine-digit candidates are tested for the
 * pandigital property, and the largest valid value found
 * is recorded.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem38 {
    class Program {
        static void Main(string[] args) {
            // Largest pandigital concatenated product found.
            String max = "0";

            int i = 0;
            bool fin = false;

            // Test successive starting integers.
            while (!fin) {
                i++;
                int n = 0;
                String current = "";

                // Build the concatenated product.
                while (current.Length < 9) {
                    n++;
                    int result = i * n;
                    current = String.Concat(current, result.ToString());
                }

                // Check valid 9-digit candidates.
                if (current.Length == 9) {
                    if (isPan(current)) {
                        if (max.CompareTo(current) < 0) {
                            max = current;
                        }
                    }
                } else {
                    // Once only one or two multiples exceed
                    // nine digits, no larger solutions exist.
                    if (n == 2 || n == 1) {
                        fin = true;
                    }
                }
            }

            // Display the largest pandigital value found.
            Console.WriteLine(max);
            Console.ReadLine();
        }

        /*
         * Determines whether a string contains each digit
         * from 1 to 9 exactly once.
         */
        public static bool isPan(String s) {
            // A pandigital number must contain exactly 9 digits.
            if (9 < s.Length) {
                return false;
            }

            // Verify that every digit from 1 to 9 is present.
            for (int i = 0; i < s.Length; i++) {
                if(!s.Contains((i + 1).ToString())) {
                    return false;
                }
            }

            return true;
        }
    }   
}