/*
 * Purpose:
 * Calculate the value of
 *
 *     d1 × d10 × d100 × d1000 × d10000 × d100000 × d1000000
 *
 * where dn is the nth digit of Champernowne's constant:
 *
 *     0.1234567891011121314...
 *
 * Approach:
 * The sequence is generated implicitly by tracking the position
 * of each integer within the decimal expansion. Whenever one of
 * the required digit positions is reached, the corresponding
 * digit is extracted and multiplied into the running product.
 */
using System;

namespace ProjectEulerProblem40 {
    class Program {
        static void Main(string[] args) {
            // Current position within Champernowne's constant.
            int length = 1;

            // Current integer being appended.
            int i = 1;

            // Number of digits in the current integer.
            int nLength = 1;

            // Next power of ten.
            int current = 10;

            // Next digit position of interest.
            int looking = 1;

            // Product of the required digits.
            int product = 1;

            while (looking <= 1000000) {
                // Detect when the number of digits increases.
                if (i == current) {
                    nLength++;
                    length++;
                    current *= 10;
                }

                // Check whether a target position has been reached.
                if (looking <= length) {
                    int temp = i;

                    // Isolate the required digit.
                    for (int j = length; looking < j; j--) {
                        temp /= 10;
                    }
                    product *= temp % 10;

                    // Move to the next required position.
                    looking *= 10;
                }

                // Advance to the next integer.
                i++;

                // Update the current length of the decimal expansion.
                length += nLength;
            }

            // Display the final product.
            Console.WriteLine(product);
            Console.ReadLine();
        }
    }
}