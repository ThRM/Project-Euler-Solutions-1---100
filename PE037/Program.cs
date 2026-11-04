/*
 * Purpose:
 * Find the sum of the eleven truncatable primes.
 *
 * A truncatable prime remains prime when digits are removed
 * one at a time from either the left or the right.
 *
 * Approach:
 * Primes are generated using a sieve and stored in a hash set
 * for fast lookup. Each prime is tested by repeatedly removing
 * digits from both ends and checking whether every resulting
 * value remains prime.
 *
 * The search continues until all eleven truncatable primes
 * have been found.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem37 {
    class Program {
        static void Main(string[] args) {
            // Store generated primes for fast primality checks.
            HashSet<int> primes = new HashSet<int>();
            primes.Add(2);

            // Sieve representation of odd numbers.
            bool[] sieve = new bool[500000];
            Array.Clear(sieve, 0, sieve.Length);

            // Number and sum of truncatable primes found.
            int count = 0;
            int sum = 0;
            int number = 0;

            // Generate primes until all eleven truncatable
            // primes have been discovered.
            for (int i = 1; i < sieve.Length && count < 11; i++) {
                if(!sieve[i]) {
                    number = i * 2 + 1;
                    primes.Add(number);

                    // Mark multiples as composite.
                    for (int j = i + number; j < sieve.Length; j+= number) {
                        sieve[j] = true;
                    }

                    bool trucatable = true;
                    int temp = number;
                    int rotate = 1;

                    // Test all left and right truncations.
                    while (temp != 0) {
                        rotate *= 10;

                        // Remove digits from the left.
                        int possiblePrime = number % rotate;
                        if(possiblePrime != number) {
                            if(!primes.Contains(possiblePrime)) {
                                trucatable = false;
                            }
                        }

                        temp /= 10;

                        // Remove digits from the right.
                        if (temp != 0) {
                            if(!primes.Contains(temp)) {
                                trucatable = false;
                            }
                        }
                    }

                    // Single-digit primes are excluded.
                    if (rotate == 10) {
                        trucatable = false;
                    }

                    // Record valid truncatable primes.
                    if (trucatable) {
                        sum += number;
                        count++;
                    }
                }
            }

            // Display the sum of the eleven truncatable primes.
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}