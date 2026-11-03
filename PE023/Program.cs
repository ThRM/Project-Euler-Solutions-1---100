/* 
 * Purpose:
 * Find the sum of all positive integers that cannot be written
 * as the sum of two abundant numbers.
 *
 * Approach:
 * Abundant numbers are generated and stored as they are found.
 * Whenever a new abundant number is discovered, all possible
 * sums involving that number are marked. Any value that remains
 * unmarked cannot be expressed as the sum of two abundant numbers
 * and is included in the final total.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem23 {
    class Program {
        static void Main(string[] args) {
            // Running total of numbers that cannot be written
            // as the sum of two abundant numbers.
            int sum = 0;

            // List of abundant numbers found so far.
            List<int> abundantNumbers = new List<int>();

            // numbers[i] is true if i can be written as the
            // sum of two abundant numbers.
            bool[] numbers = new bool[28124];

            Array.Clear(numbers, 0, numbers.Length);

            // Examine every value below the known upper bound.
            for (int i = 0; i < numbers.Length; i++) {
                // Add values that have not been expressed as the
                // sum of two abundant numbers.
                if (!numbers[i]) {
                    sum += i;
                }

                // Calculate the sum of proper divisors of i.
                int limit = (int)Math.Sqrt(i);
                int divisors = 1;
                for (int j = 2; j <= limit; j++) {
                    // Avoid double-counting square roots.
                    if (i%j == 0) {
                        int biggerDivisor = i / j;
                        if (j != biggerDivisor) {
                            divisors += j + biggerDivisor;
                        } else {
                            divisors += j;
                        }
                    }
                }

                // Check whether i is abundant.
                if (i < divisors) {
                    abundantNumbers.Add(i);

                    // Mark all sums involving the new abundant number.
                    for (int j = 0; j < abundantNumbers.Count; j++) {
                        int sumAbundant = i + abundantNumbers[j];
                        if (sumAbundant < numbers.Length) {
                            numbers[sumAbundant] = true;
                        }
                    }
                }
            }

            // Display the final total.
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
