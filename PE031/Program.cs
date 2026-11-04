/*
 * Purpose:
 * Determine the number of ways £2 can be formed using the
 * available British coin denominations.
 *
 * Approach:
 * A recursive search is used to try all valid coin combinations.
 * To avoid counting the same combination in different orders,
 * each recursive call may only use coins of the same value or
 * smaller than the previous choice.
 *
 * Results for previously solved subproblems are stored in a
 * hash table, significantly reducing repeated computation.
 */
using System;
using System.Collections;

namespace ProjectEulerProblem31 {
    class Program {
        Hashtable store = new Hashtable();

        static void Main(string[] args) {
            // Count the number of ways to make 200 pence.
            int result = new Program().numWays(200, -1);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        /*
         * Recursively counts the number of ways to form a target
         * amount using British coin denominations.
         *
         * Parameters:
         *     num    - Remaining amount to be formed.
         *     choice - Largest coin value permitted in this branch.
         *
         * Returns:
         *     The number of valid coin combinations.
         */
        public int numWays(int num, int choice) {
            // Unique key identifying this subproblem.
            String key = num + " " + choice;

            // Reuse a previously computed result.
            if (store.ContainsKey(key)) {
                return (int)store[key];
            }

            // Overshot the target amount.
            if (num < 0) {
                return 0;
            }

            // Found a valid combination.
            if (num == 0) {
                return 1;
            }

            int sum = 0;

            // Available coin denominations.
            int[] choices = {200, 100, 50, 20, 10, 5, 2, 1};

            // Try each allowable coin value.
            for (int i = 0; i < choices.Length; i++) {
                // Restrict future choices to prevent
                // counting the same combination multiple times.
                if (choice == -1 || choices[i] <= choice) {
                    sum += numWays(num - choices[i], choices[i]);
                }
            }

            // Cache the result for future reuse.
            store.Add(key, sum);

            return sum;
        }
    }
}