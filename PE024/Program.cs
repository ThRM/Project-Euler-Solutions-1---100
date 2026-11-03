/*
 * Purpose:
 * Find the millionth lexicographic permutation of the digits
 * 0 through 9.
 *
 * Approach:
 * Uses factorial numbering to determine each digit position
 * without generating every permutation. At each step, the
 * appropriate digit block is selected and the chosen digit
 * is removed from further consideration.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem24 {
    class Program {
        static void Main(string[] args) {
            // Digits already used in the permutation.
            HashSet<int> used = new HashSet<int>();

            // Precompute factorial values.
            int[] factorials = new int[10];
            factorials[0] = 1;
            for (int i = 1; i < factorials.Length; i++) {
                factorials[i] = (i + 1) * factorials[i - 1];
            }

            int digit = 1;
            int count = 0;

            // Target permutation index.
            int limit = 1000000;

            // Determine the first nine digits.
            while (digit <= 9) {
                int i = 0;

                // Find the factorial block containing
                // the desired permutation.
                while (count < limit) {
                    // Skip digits already used.
                    while (used.Contains(i)) {
                        i++;
                    }
                    count += factorials[9 - digit];
                    i++;
                }

                // Step back to the correct block.
                count -= factorials[9 - digit];
                i--;

                // Record and output the next digit.
                used.Add(i);
                Console.Write(i);

                digit++;
            }

            // Output the final unused digit.
            int last = 0;
            while (used.Contains(last)) {
                last++;
            }

            Console.Write(last);

            Console.ReadLine();
        }
    }
}
