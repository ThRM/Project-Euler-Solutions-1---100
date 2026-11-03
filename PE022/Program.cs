/* 
 * Purpose:
 * Calculate the total of all name scores in a file.
 *
 * Approach:
 * The names are read from a file, sorted alphabetically using
 * merge sort, and assigned positions in the sorted list.
 * Each name's alphabetical value is multiplied by its position,
 * and these scores are summed.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectEulerProblem22 {
    class Program {
        static void Main(string[] args) {
            // Read the contents of the input file.
            String s = "";

            try {
                FileStream file = new FileStream("names.txt", FileMode.Open);
                StreamReader stream = new StreamReader(file);
                s = stream.ReadToEnd();
                stream.Close();
                file.Close();
            }
            catch(Exception e) {
                Console.WriteLine(e);
            }

            // Sort the names alphabetically.
            String[] names = sort(s.Split(','));

            long score = 0;

            // Calculate the score for each name.
            for (int i = 0; i < names.Length; i++) {
                int nameScore = 0;

                // Sum the alphabetical values of the letters.
                for (int j = 1; j < names[i].Length - 1; j++) {
                    nameScore += names[i][j] - 'A' + 1;
                }

                // Multiply by the position in the sorted list.
                score += (nameScore * (i + 1));
            }

            // Display the total score.
            Console.WriteLine(score);
            Console.ReadLine();
        }

        /*
         * Sorts an array of strings using the merge sort algorithm.
         *
         * The array is recursively divided into two halves,
         * each half is sorted, and the sorted halves are then merged.
         */
        public static String[] sort(String[] a) {
            // Arrays of length 1 are already sorted.
            if (a.Length == 1) {
                return a;   
            }

            // Split the array into two halves.
            String[] b = new String[a.Length/2];
            String[] c = new String[a.Length - a.Length/2];

            for (int i = 0; i < a.Length / 2; i++) {
                b[i] = a[i];
            }

            for (int i = a.Length / 2; i < a.Length; i++) {
                c[i - a.Length/2] = a[i];
            }

            // Recursively sort both halves.
            sort(b);
            sort(c);

            // Merge the two sorted halves.
            int bIndex = 0;
            int cIndex = 0;
            for (int i = 0; i < a.Length; i++) {
                if(b.Length == bIndex) {
                    a[i] = c[cIndex];
                    cIndex++;
                } else if (c.Length == cIndex) {
                    a[i] = b[bIndex];
                    bIndex++;
                } else {
                    // Take the next smallest element from either half.
                    if (b[bIndex].CompareTo(c[cIndex]) < 0) {
                        a[i] = b[bIndex];
                        bIndex++;
                    } else {
                        a[i] = c[cIndex];
                        cIndex++;
                    }
                }
            }

            return a;
        }
    } 
}
