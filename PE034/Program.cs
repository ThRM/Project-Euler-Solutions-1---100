/*
 * Purpose:
 * Find the sum of all numbers that are equal to the sum of
 * the factorials of their digits.
 *
 * Approach:
 * Factorials for the digits 0-9 are precomputed. An upper
 * bound for the search is determined by comparing the maximum
 * possible sum of digit factorials with the number of digits
 * being considered.
 *
 * Each number up to this limit is tested by summing the
 * factorials of its digits. Numbers equal to this sum are
 * added to the final total.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem34 {
    class Program {
        static void Main(string[] args) {
            // Precompute the factorials of the digits 0-9.
            int[] factorials = new int[10];
            factorials[0] = 1;
            
            for(int i = 1; i < factorials.Length; i++) {
                factorials[i] = i * factorials[i - 1];
            }

            // Determine an upper bound for the search.
            int currentLength = 1;
            int limit = factorials[9];
            int length;

            do {
                length = 0;

                // Count the digits in the maximum possible sum.
                while (limit != 0) {
                    length++;
                    limit /= 10;
                }

                currentLength++;

                // Largest possible factorial digit sum for
                // numbers of this length.
                limit = factorials[9] * currentLength;
            } while(currentLength < length);

            // Sum of all matching numbers.
            int sum = 0;

            // Test every candidate number.
            for (int i = 3; i <= limit; i++) {
                int score = 0;
                int temp = i;

                // Calculate the sum of the factorials
                // of the number's digits.
                while (temp != 0) {
                    score += factorials[temp%10];
                    temp /= 10;
                }

                // Check whether the number satisfies
                // the required property.
                if (score == i) {
                    sum += i;
                }
            }

            // Display the final result.
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}