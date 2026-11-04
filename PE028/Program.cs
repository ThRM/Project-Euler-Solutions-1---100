/* 
 * Purpose:
 * Calculate the sum of the numbers on both diagonals in a
 * 1001 x 1001 number spiral.
 *
 * Approach:
 * Starting from the central value 1, each new square layer
 * contributes four corner values to the diagonals. The
 * difference between consecutive corners is equal to the
 * side length of the layer minus one.
 *
 * The program generates these corner values directly rather
 * than constructing the entire spiral.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem28 {
    class Program {
        static void Main(string[] args) {
            // Size of the spiral.
            const int maxSize = 1001;

            // Start with the centre value.
            int sum = 1;
            int current = 1;
            int currentSize = 1;

            // Process each square layer of the spiral.
            while (currentSize < maxSize) {
                currentSize+=2;

                // Add the four corners of the new layer.
                for (int i = 1; i <= 4; i++) {
                    current += currentSize - 1;
                    sum += current;
                }
            }

            // Display the diagonal sum.
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
