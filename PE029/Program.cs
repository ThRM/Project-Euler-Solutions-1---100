/*
 * Purpose:
 * Count the number of distinct terms of the form
 *
 *     a^b
 *
 * for 2 ≤ a ≤ 100 and 2 ≤ b ≤ 100.
 *
 * Approach:
 * Every value of a^b is generated and stored in a hash table.
 * Since duplicate values can occur (e.g. 4² = 2⁴), only values
 * not already present are counted.
 */
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEulerProblem29 {
    class Program {
        static void Main(string[] args) {
            // Number of distinct powers found.
            int count = 0;

            // Stores previously encountered values.
            Hashtable numbers = new Hashtable();

            // Generate all values a^b.
            for (int a = 2; a <= 100; a++) {
                for (int b = 2; b <= 100; b++) {
                    BigInteger number = BigInteger.Pow(a, b);

                    // Count only distinct values.
                    if (!numbers.ContainsKey(number)) {
                        count++;
                        numbers.Add(number, 0);
                    }
                }
            }

            // Display the number of distinct terms.
            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
