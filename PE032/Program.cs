/*
 * Purpose:
 * Find the sum of all products whose multiplicand, multiplier,
 * and product can be concatenated to form a 1 through 9
 * pandigital number.
 *
 * Approach:
 * All permutations of the digits 1 to 9 are generated and
 * used as possible multiplicands and multipliers. Products
 * satisfying the pandigital identity are identified and
 * accumulated, ensuring that each product is counted only once.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem32 {
    class Program {
        static void Main(string[] args) {
            // Digits used to form pandigital numbers.
            int[] digits = new int[9];
            

            for (int i = 0; i < digits.Length; i++) {
                digits[i] = i + 1;
            }

            // Generate permutations of the digits 1 to 9.
            List<int> permutations = new List<int>();
            List<int> next = new List<int>();
            for (int i = 1; i <= 9; i++) {
                for (int j = 0; j < permutations.Count; j++) {
                    int temp = permutations[j];
                    int length = 0;
                    int rotate = 1;

                    while(temp != 0) {
                        length++;
                        rotate *= 10;
                        temp /= 10;
                    }

                    // Insert the current digit into every position.
                    temp = permutations[j] * 10 + i;
                    next.Add(temp);
                    for (int k = 0; k < length; k++) {
                        temp = temp % rotate * 10 + temp / rotate;
                        next.Add(temp);
                    }
                }
                for (int j = 0; j < next.Count; j++) {
                    permutations.Add(next[j]);
                }
                next.Clear();
                permutations.Add(i);
            }

            // Prevent duplicate products from being counted.
            HashSet<int> products = new HashSet<int>();
            int sum = 0;
            bool fin = false;

            permutations.Sort();

            // Test every multiplicand/multiplier combination.
            for (int i = 0; i < permutations.Count && !fin; i++) {
                bool finInner = false;
                for (int j = i; j < permutations.Count && !finInner; j++) {
                    int result = permutations[i] * permutations[j];

                    // Total digits in multiplicand, multiplier and product.
                    int length = getLength(permutations[i], permutations[j], result);

                    // Products beyond 9 digits cannot be valid.
                    if (10 <= length) {
                        if (j == i) {
                            fin = true;
                        } else {
                            finInner = true;
                        }
                    } else if(length == 9) {
                        // Check the pandigital property.
                        if (isPanDigital(permutations[i], permutations[j], result)) {
                            if(!products.Contains(result)) {
                                sum += result;
                                products.Add(result);
                            }
                        }
                    }
                }
            }

            // Display the sum of all distinct products.
            Console.WriteLine(sum);
            Console.ReadLine();
        }

        /*
         * Returns the total number of digits contained in the
         * multiplicand, multiplier and product.
         */
        public static int getLength(int a, int b, int c) {
            int length = 0;

            // Count digits in the multiplicand.
            while (a != 0) {
                length++;
                a /= 10;
            }

            // Count digits in the multiplier.
            while (b != 0) {
                length++;
                b /= 10;
            }

            // Count digits in the product.
            while (c != 0) {
                length++;
                c /= 10;
            }

            return length;
        }

        /*
         * Determines whether the concatenation of the multiplicand,
         * multiplier and product contains each digit from 1 to 9
         * exactly once.
         */
        public static bool isPanDigital(int a, int b, int c) {
            // Concatenate the three values into a single string.
            String s = String.Concat(a, b, c);
            if(s.Length != 9) {
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