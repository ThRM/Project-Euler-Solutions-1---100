/*
 * Purpose:
 * Find the starting number less than one million that produces
 * the longest Collatz sequence.
 *
 * The Collatz rules are:
 *
 *   n -> n / 2        if n is even
 *   n -> 3n + 1       if n is odd
 *
 * The sequence continues until it reaches 1.
 *
 * Approach:
 * Each starting value from 1 to 1,000,000 is examined and the
 * length of its Collatz sequence is calculated recursively.
 *
 * To avoid repeatedly calculating the same sequences, previously
 * computed sequence lengths are stored in a hash table. When a
 * value is encountered again, the stored result is used immediately.
 *
 * This memoization significantly reduces the amount of repeated
 * computation because many Collatz sequences share common tails.
 *
 * The program keeps track of the longest sequence length found
 * and the starting number that produced it.
 */

using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem14 {
    class Program {
        // Stores previously computed Collatz sequence lengths.
        Hashtable values;

        /*
         * Entry point of the application. Creates a Program object,
         * executes the search, and displays the result.
         */
        static void Main(string[] args) {
            System.Console.WriteLine(new Program().run());
            System.Console.ReadLine();
        }

        /*
         * Creates the program object and initialises the hash table
         * used to store previously computed Collatz sequence lengths.
         */
        public Program() {
            // Create the memoization table.
            values = new Hashtable();
        }

        /*
         * Tests every starting value from 1 to 1,000,000 and determines
         * which produces the longest Collatz sequence.
         *
         * Returns:
         *     The starting number that generates the longest chain.
         */
        public long run() {
            // Length of the longest sequence found so far.
            int max = 0;

            // Starting value that produced the longest sequence.
            long number = 0;

            // Test every starting value below one million.
            for (long i = 1; i <= 1000000; i++) {
                int result = path(i);

                // Update the record if a longer chain is found.
                if (max < result) {
                    max = result;
                    number = i;
                }
            }
            return number;
        }

        /*
         * Calculates the length of the Collatz sequence beginning at
         * the supplied value.
         *
         * Previously computed sequence lengths are retrieved from the
         * hash table when available to avoid redundant calculations.
         *
         * Parameters:
         *     number - Current value in the Collatz sequence.
         *
         * Returns:
         *     The number of terms in the sequence from this value to 1.
         */
        public int path(long number) {
            // Return a previously computed result if available.
            if (values.ContainsKey(number)) {
                return (int)values[number];
            }

            int result;

            // Base case: the sequence terminates at 1.
            if (number == 1) {
                return 1;
            }

            // Apply the appropriate Collatz rule and
            // include the current step in the count.
            if (number % 2 == 0) {
                result = 1 + path(number / 2);
            } else {
                result = 1 + path(3 * number + 1);
            }

            // Store the result for future reuse.
            values.Add(number, result);

            return result;
        }
    }
}
