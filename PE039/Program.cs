/*
 * File:   Program.cs
 * Author: Tom
 *
 * Purpose:
 * Find the perimeter value p ≤ 1000 that produces the greatest
 * number of integer right-angled triangles.
 *
 * Approach:
 * Every possible pair of side lengths a and b is examined.
 * If the resulting hypotenuse c is an integer, a valid
 * Pythagorean triple has been found.
 *
 * The perimeter of each valid triangle is counted, and the
 * perimeter with the highest number of solutions is returned.
 */
using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem39 {
    class Program {
        static void Main(string[] args) {
            // Count the number of solutions for each perimeter.
            int[] counts = new int[1001];
            Array.Clear(counts, 0, counts.Length);

            // Generate all possible integer right triangles.
            for (int a = 0; a <= 1000; a++) {
                // Start b at a to avoid duplicate triangles.
                for (int b = a; b <= 1000; b++) {
                    double c = Math.Sqrt(a * a + b * b);
                    // Check whether the hypotenuse is an integer.
                    if (c % 1 == 0) {
                        int p = a + b + (int)c;

                        // Record valid perimeters up to 1000.
                        if (p <= 1000) {
                            counts[p]++;
                        }
                    }
                }
            }

            // Find the perimeter with the most solutions.
            int max = 0;
            int maxP = 0;

            for (int i = 0; i < counts.Length; i++) {
                if(max < counts[i]) {
                    max = counts[i];
                    maxP = i;
                }
            }

            // Display the perimeter with the maximum count.
            Console.WriteLine(maxP);
            Console.ReadLine();
        }
    }
}