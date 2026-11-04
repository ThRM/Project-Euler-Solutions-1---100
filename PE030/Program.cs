/*
 * Purpose:
 * Find the sum of all numbers that can be written as the sum
 * of the fifth powers of their digits.
 *
 * Approach:
 * An upper bound is first determined by comparing the maximum
 * possible sum of digit powers with the number of digits being
 * considered.
 *
 * Each number up to this limit is then tested by summing the
 * fifth powers of its digits. Any number equal to this sum is
 * included in the final total.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem30 {
    class Program {
        static void Main(string[] args) {
            // Power used when evaluating each digit.
            const int power = 5;

            // Determine an upper bound for the search.
            int limit = 0;
            int length = 0;
            bool found = false;

            while(!found) {
                length++;

                // Largest possible sum for a number with
                // the current number of digits.
                limit = (int)Math.Pow(9, power) * length;

                // Compare against the smallest number with
                // the same digit length.
                for (int i = length; 0 < i; i--) {
                    limit /= 10;
                }

                if(limit == 0) {
                    found = true;
                    limit = (int)Math.Pow(9, power) * length;
                }
            }

            // Sum of all matching numbers.
            int sum = 0;

            // Test every candidate number.
            for (int i = 10; i <= limit; i++) {
                int sumOfDigits = 0;
                int temp = i;

                // Calculate the sum of the fifth powers
                // of the number's digits.
                while (temp != 0) {
                    sumOfDigits += (int)Math.Pow(temp % 10, power);
                    temp /= 10;
                }

                // Check whether the number satisfies the condition.
                if (i == sumOfDigits) {
                    sum += i;
                }
            }

            // Display the final result.
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}