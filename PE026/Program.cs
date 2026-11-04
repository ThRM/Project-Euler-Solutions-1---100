/*
 * Purpose:
 * Find the value of d < 1000 for which 1/d contains the
 * longest recurring cycle in its decimal expansion.
 *
 * Approach:
 * Long division is simulated by tracking the sequence of
 * remainders. If a remainder repeats, the decimal expansion
 * has entered a cycle. The cycle length is determined from
 * the distance between the first and second occurrence of
 * the repeated remainder.
 */
using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem26 {
    class Program {
        static void Main(string[] args) {
            // Records the position at which each remainder appeared.
            Hashtable seen = new Hashtable();

            // Longest recurring cycle found so far.
            int max = 0;

            // Denominator producing the longest cycle.
            int maxD = 0;

            // Test every denominator below 1000.
            for (int i = 1; i < 1000; i++) {
                seen.Clear();

                // Current remainder during long division.
                int r = 1;
                int count = 0;
                int result = 0;
                bool found = false;
                while(!found) {
                    // A repeated remainder indicates a cycle.
                    if (seen.ContainsKey(r)) {
                        found = true;
                        result = count - (int)seen[r];
                    } else {
                        // Record where this remainder first appeared.
                        seen.Add(r, count);
                        r = r % i;

                        // Terminating decimal expansion.
                        if (r == 0) {
                            found = true;
                        } else {
                            // Next step of long division.
                            r = r * 10;
                        }
                    }
                    count++;
                }

                // Update the longest cycle found.
                if (max < result) {
                    max = result;
                    maxD = i;
                }
            }

            Console.WriteLine(maxD + " " + max);
            Console.ReadLine();
        }
    }
}