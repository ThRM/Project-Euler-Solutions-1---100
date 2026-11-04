/* 
 * Purpose:
 * Count the circular primes below one million.
 *
 * A circular prime remains prime under all cyclic rotations
 * of its digits. For example:
 *
 *     197 -> 971 -> 719
 *
 * are all prime, so 197 is a circular prime.
 *
 * Approach:
 * A sieve is used to generate primes below one million.
 * For each prime, all digit rotations are generated and
 * checked for primality. If every rotation is prime, the
 * number contributes to the circular prime count.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem35 {
    class Program {
        static void Main(string[] args) {
            // Store all discovered primes for fast lookup.
            HashSet<int> primes = new HashSet<int>();
            primes.Add(2);

            // Sieve representation of odd numbers.
            bool[] sieve = new bool[500000];
            Array.Clear(sieve, 0, sieve.Length);

            // Count of circular primes found.
            int count = 1;

            // Generate primes using a sieve.
            for (int i = 1; i < sieve.Length; i++) {
                if(!sieve[i]) {
                    int number = i * 2 + 1;

                    // Mark multiples as composite.
                    for (int j = i + number; j < sieve.Length; j+= number) {
                        sieve[j] = true;
                    }

                    primes.Add(number);

                    // Determine the number of digits and
                    // the value needed to perform rotations.
                    int length = 0;
                    int temp = number;
                    int rotator = 1;
                    while(temp != 0) {
                        length++;
                        temp /= 10;
                        rotator *= 10;
                    }

                    temp = number;
                    bool circular = true;
                    int repeat = 0;

                    // Track repeated rotations.
                    HashSet<int> seen = new HashSet<int>();

                    // Test every cyclic rotation.
                    for (int j = 0; j < length; j++) {
                        if(!primes.Contains(temp)) {
                            circular = false;
                        } else if(seen.Contains(temp)) {
                            repeat++;
                        }
                        seen.Add(temp);

                        // Rotate the leading digit to the end.
                        temp *= 10;
                        temp = temp % rotator + temp/rotator;
                    }

                    // Count all distinct circular primes
                    // within the rotation cycle.
                    if (circular) {
                        count += length - repeat;
                    }
                }
            }

            // Display the total number of circular primes.
            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}