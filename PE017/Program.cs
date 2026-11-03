/*
 * Purpose:
 * Calculate the total number of letters required to write all
 * numbers from 1 to 1000 inclusive in words using British usage
 * (including the word "and" where appropriate).
 *
 * Approach:
 * Each number is decomposed into thousands, hundreds, tens and
 * units. The Score() function returns the number of letters
 * required for values less than 100, while the main loop handles
 * hundreds, thousands and the inclusion of "and".
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem17 {
    class Program {
        // Letter counts for each word used when writing numbers in English.
        const int ONE = 3;
        const int TWO = 3;
        const int THREE = 5;
        const int FOUR = 4;
        const int FIVE = 4;
        const int SIX = 3;
        const int SEVEN = 5;
        const int EIGHT = 5;
        const int NINE = 4;
        const int TEN = 3;
        const int ELEVEN = 6;
        const int TWELVE = 6;
        const int THIRTEEN = 8;
        const int FOURTEEN = 8;
        const int FIFTEEN = 7;
        const int SIXTEEN = 7;
        const int SEVENTEEN = 9;
        const int EIGHTEEN = 8;
        const int NINETEEN = 8;
        const int TWENTY = 6;
        const int THIRTY = 6;
        const int FORTY = 5;
        const int FIFTY = 5;
        const int SIXTY = 5;
        const int SEVENTY = 7;
        const int EIGHTY = 6;
        const int NINETY = 6;
        const int HUNDRED = 7;
        const int THOUSAND = 8;
        const int AND = 3;

        static void Main(string[] args) {
            // Running total of letter counts.
            int sum = 0;
            Console.SetBufferSize(200, 1010);

            // Process every number from 1 to 1000.
            for (int i = 1; i <= 1000; i++) {
                int num = i;
                int current = 0;

                // Handle the thousands digit.
                if (1000 <= num) {
                    num = num / 1000;
                    current += Score(num);
                    current += THOUSAND;

                    num = i % 1000;
                }

                // Handle the hundreds digit.
                if (100 <= num) {
                    num = num / 100;
                    current += Score(num);
                    current += HUNDRED;

                    num = i % 100;
                }

                // British usage requires "and" between the
                // hundreds and the remaining digits.
                if (current != 0 && num != 0) {
                    current += AND;
                }

                // Count the letters in the remaining
                // two-digit portion.
                current += Score(num);

                Console.WriteLine(i + " " + current);

                sum += current;
            }

            // Display the final total.
            Console.WriteLine(sum);
            Console.ReadLine();
        }

        /*
         * Returns the number of letters required to write
         * a number from 0 to 99 in words.
         *
         * Examples:
         *   42 -> "forty two" -> 8
         *   17 -> "seventeen" -> 9
         */
        static int Score(int num) {
            int score = 0;

            // Numbers below twenty have unique names.
            if (num < 20) {
                switch (num) {
                    case 1: score += ONE; break;
                    case 2: score += TWO; break;
                    case 3: score += THREE; break;
                    case 4: score += FOUR; break;
                    case 5: score += FIVE; break;
                    case 6: score += SIX; break;
                    case 7: score += SEVEN; break;
                    case 8: score += EIGHT; break;
                    case 9: score += NINE; break;
                    case 10: score += TEN; break;
                    case 11: score += ELEVEN; break;
                    case 12: score += TWELVE; break;
                    case 13: score += THIRTEEN; break;
                    case 14: score += FOURTEEN; break;
                    case 15: score += FIFTEEN; break;
                    case 16: score += SIXTEEN; break;
                    case 17: score += SEVENTEEN; break;
                    case 18: score += EIGHTEEN; break;
                    case 19: score += NINETEEN; break;
                }
            } else {
                // Score the units digit.
                int temp = num % 10;
                switch (temp) {
                    case 1: score += ONE; break;
                    case 2: score += TWO; break;
                    case 3: score += THREE; break;
                    case 4: score += FOUR; break;
                    case 5: score += FIVE; break;
                    case 6: score += SIX; break;
                    case 7: score += SEVEN; break;
                    case 8: score += EIGHT; break;
                    case 9: score += NINE; break;
                }

                // Score the tens digit.
                temp = num / 10;
                switch (temp) {
                    case 2: score += TWENTY; break;
                    case 3: score += THIRTY; break;
                    case 4: score += FORTY; break;
                    case 5: score += FIFTY; break;
                    case 6: score += SIXTY; break;
                    case 7: score += SEVENTY; break;
                    case 8: score += EIGHTY; break;
                    case 9: score += NINETY; break;
                }
            }

            return score;
        }
    }
}
