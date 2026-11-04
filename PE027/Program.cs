/*
 * Purpose:
 * Find the product of the coefficients a and b in the quadratic
 * expression
 *
 *     n² + an + b
 *
 * that produces the longest sequence of consecutive primes
 * starting from n = 0.
 *
 * Approach:
 * A sieve is used to generate a large collection of prime numbers.
 * Every valid combination of a and b is tested, and the length of
 * the consecutive prime sequence produced by the quadratic is
 * determined. The coefficients producing the longest sequence are
 * recorded.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem27 {
    class Program {
        static void Main(string[] args) {
            // Generate a large set of primes for fast lookups.
            bool[] primes = new bool[1000000];
            for (int i = 0; i < primes.Length; i++ ) {
                primes[i] = true;
            }
            primes[0] = false;

            // Primes below 1000 used as possible values of b.
            List<int> primeList = new List<int>();
            primeList.Add(2);

            // Stores all generated primes for O(1) primality tests.
            HashSet<int> primeHash = new HashSet<int>();

            // Generate primes using a sieve.
            for (int i = 1; i < primes.Length; i++) {
                if(primes[i]) {
                    int number = 2 * i + 1;
                    primeHash.Add(number);

                    if(number < 1000) {
                        primeList.Add(number);
                    }

                    // Mark multiples as composite.
                    for (int j = i + number; j < primes.Length;  j+= number) {
                        primes[j] = false;
                    }
                }
            }

            // Length of the longest prime sequence found.
            int max = 0;

            // Product of the corresponding coefficients.
            int product = 0;

            // Test all valid values of a.
            for (int a = -999; a < 1000; a++) {
                // b must be prime since n = 0 gives b.
                for (int b = 0; b < primeList.Count; b++) {
                    int n = 0;
                    int potential;

                    // Count consecutive prime values produced by
                    // the quadratic expression.
                    do
                    {
                        potential = n * n + a * n + primeList[b];
                        n++;
                    } while(primeHash.Contains(potential));

                    // Update the best result found so far.
                    if (max < n) {
                        max = n;
                        product = a * primeList[b];
                    }
                }
            }

            // Display the product of the coefficients.
            Console.WriteLine(product);
            Console.ReadLine();
        }
    }
}