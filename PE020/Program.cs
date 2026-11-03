/*
 * Purpose:
 * Calculate the sum of the digits of 100!.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEulerProblem20 {
    class Program {
        static void Main(string[] args) {
            // Calculate 100!.
            BigInteger number = 1;
            for (int i = 1; i <= 100; i++) {
                number *= i;
            }

            // Sum the digits of the factorial.
            BigInteger sum = 0;
            while(number != 0) {
                sum += number % 10;
                number /= 10;
            }

            // Display the result.
            Console.WriteLine(sum);
            Console.ReadLine();
        } 
    }
}
