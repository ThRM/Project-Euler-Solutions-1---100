/*
 * Purpose:
 * Find the sum of all amicable numbers below 10,000.
 *
 * Approach:
 * For each number, calculate the sum of its proper divisors.
 * The divisor sum is then calculated again for that result.
 * If the process returns to the original number, an amicable
 * pair has been found.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem21 {
    class Program {
        static void Main(string[] args) {
            // Running total of amicable numbers.
            int sum = 0;

            // Check each number below 10,000.
            for (int i = 2; i < 10000; i++) {
                // Calculate the sum of proper divisors of i.
                int limit = (int)Math.Sqrt(i);
                int potential = 1;

                for (int j = 2; j <= limit; j++) {
                    if(i%j == 0) {
                        // Avoid double-counting perfect squares.
                        if (j == limit) {
                            potential += j;
                        } else {
                            potential += j + i / j;
                        }
                    }
                }

                // Calculate the sum of proper divisors of potential.
                int temp = 1;
                limit = (int)Math.Sqrt(potential);
                for (int j = 2; j <= limit; j++) {
                    // Avoid double-counting perfect squares.
                    if (potential % j == 0) {
                        if (j == limit) {
                            temp += j;
                        } else {
                            temp += j + potential / j;
                        }
                    }
                }

                // Check whether an amicable pair has been found.
                if (i == temp) {
                    // Count each pair only once.
                    if (i < potential) {
                        sum += i + potential;
                    }
                }
            }

            // Display the sum of all amicable numbers.
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}