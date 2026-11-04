/*
 * Purpose:
 * Find the pair of pentagonal numbers Pj and Pk for which
 * both their sum and difference are pentagonal, and whose
 * difference is minimised.
 *
 * Approach:
 * Pentagonal numbers are generated sequentially and stored in
 * a hash set for fast lookup.
 *
 * Whenever the difference between two pentagonal numbers is
 * pentagonal, the corresponding sum and difference are recorded.
 * If a future pentagonal number matches a previously recorded
 * sum, a valid solution has been found and the associated
 * difference is the required result.
 */
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem44 {
    class Program {
        static void Main(string[] args) {
            // Previously generated pentagonal numbers.
            HashSet<ulong> PentSet = new HashSet<ulong>();

            // Maps a pentagonal sum to the smallest associated difference.
            Hashtable Possible = new Hashtable();

            // Pentagonal numbers in generation order.
            List<ulong> PentList = new List<ulong>();

            ulong n = 1;
            bool fin = false;

            ulong result = 0;

            // Generate pentagonal numbers until a solution is found.
            while (!fin) {
                ulong pentNumber = n * (3 * n - 1) / 2;

                // If the current pentagonal number was previously
                // identified as a valid pentagonal sum, we have found
                // a pair whose sum and difference are pentagonal.
                if (Possible.ContainsKey(pentNumber)) {
                    result = (ulong)Possible[pentNumber];
                    fin = true;
                } else {
                    for (int i = PentList.Count - 1; 0 <= i; i--) {
                        // Compare against all earlier pentagonal numbers.
                        ulong d = pentNumber - PentList[i];

                        // Check whether the difference is pentagonal.
                        if (PentSet.Contains(d)) {
                            ulong s = pentNumber + PentList[i];

                            // Record the sum and its associated difference.
                            if (Possible.ContainsKey(s)) {
                                if(d < (ulong)Possible[s]) {
                                    Possible[s] = d;
                                }
                            } else {
                                Possible.Add(s, d);
                            }
                        }
                    }

                    // Store the newly generated pentagonal number.
                    PentSet.Add(pentNumber);
                    PentList.Add(pentNumber);
                    n++;
                }
            }

            // Display the minimum difference.
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}