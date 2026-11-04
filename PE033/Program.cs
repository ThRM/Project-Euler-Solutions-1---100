/*
 * Purpose:
 * Identify the four non-trivial "digit cancelling" fractions
 * less than one and determine the denominator of their product
 * in lowest terms.
 *
 * Approach:
 * All two-digit numerator/denominator pairs are examined.
 * Fractions where cancelling a common digit incorrectly
 * produces an equivalent value are recorded.
 *
 * The four fractions are multiplied together and the resulting
 * fraction is reduced to lowest terms.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem33 {
    class Program {
        static void Main(string[] args) {
            // Number of digit-cancelling fractions found.
            int found = 0;

            // Store the valid fractions.
            int[,] fractions = new int[4, 2];

            // Test all two-digit fractions less than one.
            for (int i = 11; i < 100; i++) {
                // Ignore trivial examples containing zero.
                if (i%10 != 0) {
                    for (int j = i + 1; j < 100; j++) {
                        if(j%10 != 0) {
                            double result = i / (double)j;
                            // Cancel matching units digits.
                            if (i%10 == j %10) {
                                if((i/10) / (double)(j/10) == result) {
                                    fractions[found, 0] = i;
                                    fractions[found, 1] = j;

                                    found++;
                                }
                            }

                            // Cancel matching tens digits.
                            if (i/10 == j/10) {
                                if ((i % 10) / (double)(j % 10) == result) {
                                    fractions[found, 0] = i;
                                    fractions[found, 1] = j;

                                    found++;
                                }
                            }

                            // Cancel numerator tens digit with
                            // denominator units digit.
                            if (i/10 == j%10) {
                                if ((i % 10) / (double)(j / 10) == result) {
                                    fractions[found, 0] = i;
                                    fractions[found, 1] = j;

                                    found++;
                                }
                            }

                            // Cancel numerator units digit with
                            // denominator tens digit.
                            if (i%10 == j/10) {
                                if ((i / 10) / (double)(j % 10) == result) {
                                    fractions[found, 0] = i;
                                    fractions[found, 1] = j;

                                    found++;
                                }
                            }
                        }
                    }
                }
            }

            // Multiply all discovered fractions together.
            int num = 1;
            int dom = 1;

            for (int i = 0; i < found; i++) {
                num *= fractions[i, 0];
                dom *= fractions[i, 1];
            }

            // Reduce the fraction to lowest terms.
            bool fin;
            do {
                fin = true;
                int limit = (int)Math.Sqrt(num);
                for (int i = limit; 1 < i; i--) {
                    if(num%i == 0 && dom%i == 0) {
                        num = num / i;
                        dom = dom / i;
                        fin = false;
                    }
                }
            }while(!fin);

            // Display the simplified fraction.
            Console.WriteLine(num + " " + dom);
            Console.ReadLine();
        }
    }
}