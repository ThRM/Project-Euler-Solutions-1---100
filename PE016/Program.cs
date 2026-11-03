/*
 * Purpose:
 * Calculate the sum of the digits of 2^1000.
 */
using System;
using System.Numerics;

namespace ProjectEulerProblem16 {
    class Program {
        static void Main(string[] args) {
            // Calculate 2^1000.
            BigInteger number = 2;
            number = BigInteger.Pow(number, 1000);

            // Running total of digit values.
            BigInteger sum = 0;

            // Extract and sum each digit.
            while (number != 0) {
                sum += number % 10;
                number = number / 10;
            }

            // Display the result.
            Console.WriteLine(sum); 
            Console.ReadLine();
        }
    }
}