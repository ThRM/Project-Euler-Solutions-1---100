/*
 * Project Euler 9
 *
 * Find the unique Pythagorean triplet (a, b, c) such that:
 *
 *     a² + b² = c²
 *     a + b + c = 1000
 *
 * Return the product abc.
 *
 * Idea:
 *     Enumerate possible values of a and b.
 *     Compute c using Pythagoras' theorem and test whether
 *     the sum of the triplet is 1000.
 */

#include <cstdlib>
#include <iostream>
#include <cmath>

using namespace std;

int main(int argc, char** argv) {
    int limit;

    // Search all possible values of a.
    for(int a = 1; a <= 1000; a++) {
        // Since c > 0, b cannot exceed 1000 - a.
        limit = 1000 - a;
        // Enforce a <= b to avoid checking equivalent pairs.
        for(int b = a; b <= limit; b++) {
            // Compute c from a² + b² = c².
            double c = sqrt(pow(a, 2.0) + pow(b, 2.0));

            // Check whether the triplet sums to 1000.
            if(a + b + c == 1000) {
                cout.precision(9);
                cout << a * b * c << " a:" << a << " b:"<< b << " c:" << c;
                return 0;
            // If the sum has already exceeded 1000,
            // larger values of b will only make it larger.
            } else if(1000 < a + b + c) {
                limit = b;
            }
        }
    }
    return 0;
}