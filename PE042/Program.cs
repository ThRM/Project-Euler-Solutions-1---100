/*
 * Purpose:
 * Count the number of triangle words in the supplied word list.
 *
 * A word's value is obtained by summing the alphabetical values
 * of its letters (A = 1, B = 2, ..., Z = 26). A triangle word
 * is a word whose value is a triangular number.
 *
 * Approach:
 * The words are read from a file and their letter values are
 * calculated. Triangle numbers are generated on demand up to
 * the largest word value encountered, and each score is tested
 * for membership in the set of triangle numbers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectEulerProblem42 {
    class Program {
        static void Main(string[] args) {
            // Read the contents of the input file.
            String s = "Bill";

            try {
                FileStream file = new FileStream("words.txt", FileMode.Open);
                StreamReader stream = new StreamReader(file);

                s = stream.ReadToEnd();

                stream.Close();
                file.Close();
            }
            catch(Exception e) {
                Console.WriteLine(e);
            }

            // Extract the individual words.
            String[] words = s.Split(',');

            // Stores generated triangle numbers.
            HashSet<int> triNumbers = new HashSet<int>();
            int current = 1;
            int n = 1;

            triNumbers.Add(current);

            // Number of triangle words found.
            int count = 0;

            // Process each word in the file.
            for (int i = 0; i < words.Length; i++) {
                int score = 0;

                // Calculate the word value.
                for (int j = 1; j < words[i].Length - 1; j++) {
                    score += words[i][j] - 'A' + 1;
                }

                // Generate triangle numbers until the
                // current score is within range.
                while (current < score) {
                    n++;
                    current = (n * (n + 1))/2;
                    triNumbers.Add(current);
                }

                // Check whether the word value is triangular.
                if (triNumbers.Contains(score)) {
                    count++;
                }
            }

            // Display the number of triangle words.
            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
