/*
 * Purpose:
 * Determine the number of lattice paths through a 20x20 grid.
 *
 * Starting in the upper-left corner, movement is restricted
 * to either right or down. The objective is to count all
 * possible paths to the lower-right corner.
 *
 * Approach:
 * The problem is solved recursively. For any grid position,
 * the number of paths to the destination is equal to:
 *
 *     paths below + paths to the right
 *
 * Positions on the bottom row or rightmost column have only
 * one possible route remaining and form the base case.
 *
 * Because many positions are reached repeatedly during the
 * recursive search, the results are stored in a hash table.
 * This memoization avoids redundant calculations and greatly
 * improves performance.
 */

using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem15 {
    class Program {
        Hashtable positions;
        const int SIZE = 21;

        /*
         * Entry point of the program.
         * Creates a Program object, computes the number of lattice
         * paths through the grid, and displays the result.
         */
        static void Main(string[] args) {
            Console.WriteLine(new Program().run(1, 1));
            Console.ReadLine();
        }

        /*
         * Creates the program object and initialises the hash table
         * used to cache previously computed grid positions.
         */
        public Program() {
            positions = new Hashtable();
        }

        /*
         * Calculates the number of paths from the specified grid
         * position to the bottom-right corner.
         *
         * From each position, movement is restricted to either:
         *   - one square down
         *   - one square right
         *
         * The number of paths from a position is therefore the sum
         * of the paths obtainable from the square below and the
         * square to the right.
         *
         * Previously computed positions are stored in a hash table
         * so that repeated subproblems are solved only once.
         *
         * Parameters:
         *     row    - Current row in the grid.
         *     column - Current column in the grid.
         *
         * Returns:
         *     The number of valid paths from the specified position
         *     to the destination.
         */
        public long run(int row, int column) {
            // Base case: once the bottom row or rightmost column is
            // reached, there is only one remaining path to the destination.
            if (row == SIZE || column == SIZE) {
                return 1;
            }

            // Create a unique key representing the current grid position.
            int key = row * 100 + column;

            // Return a previously computed result if this position has
            // already been visited.
            if (positions.ContainsKey(key)) {
                return (long)positions[key];
            }

            // The number of paths from the current position equals the
            // number of paths from the square below plus the number
            // of paths from the square to the right.
            long result = run(row + 1, column) + run(row, column + 1);

            // Cache the result so future visits to this position do
            // not require additional recursive calls.
            positions.Add(key, result);

            // Return the total number of paths from this position.
            return result;
        }
    }
}
