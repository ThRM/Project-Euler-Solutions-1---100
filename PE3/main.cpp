/*
 * Project Euler 3
 *
 * Find the largest prime factor of 600851475143.
 *
 * Idea:
 *     Repeatedly divide out prime factors from the number.
 *     Whenever a factor divides evenly, remove it and record
 *     the factor. The last factor removed is the largest
 *     prime factor.
 *
 * Complexity:
 *     O(sqrt(n))
 */
#include <iostream>
#include <cstdlib>

using namespace std;

int main(int argc, char** argv) {
    long long number = 600851475143LL;
    long long largestPrimeFactor = 1;
    
    // Remove all factors of 2.
    while (number % 2 == 0) {
        number = number / 2;
        largestPrimeFactor = 2;
    }

    // Search odd factors only.
    long long factor = 3;
    while (number != 1) {
        if (number % factor == 0) {
            number /= factor;
            largestPrimeFactor = factor;
        } else {
            factor += 2;
        }
    }

    cout << largestPrimeFactor << endl;
}

