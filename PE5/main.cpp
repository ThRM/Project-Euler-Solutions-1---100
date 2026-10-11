/*
 * Project Euler 5
 *
 * Find the smallest positive number that is evenly divisible
 * by every integer from 1 to 20.
 *
 * Idea:
 *     Build the least common multiple incrementally.
 *
 *     Start with 20 × 19. For each divisor from 18 down to 11,
 *     search through multiples of the current candidate until
 *     a value divisible by the next divisor is found. That value
 *     becomes the new candidate.
 *
 *     It is sufficient to check only down to 11 because every
 *     number from 1 to 10 divides at least one number in the
 *     range 11 to 20.
 */

#include <cstdlib>
#include <iostream>
using namespace std;

int main(int argc, char** argv) {
    // Largest divisor that must divide the final answer.
    int number = 20;

    // It is sufficient to check divisors down to 11.
    int lower = number/2 + 1;
    
    // Initial candidate is divisible by both 20 and 19.
    long long increment = number * (number - 1);

    // Current multiple being tested.
    long long result = 0;

    // Next divisor to enforce.
    number = number - 2;
    bool found = false;
    while(!found) {
        // Test the next multiple of the current common multiple.
        result+= increment;

        // Check whether this multiple is divisible
        // by the current divisor.
        if(result%number == 0) {
            // A number divisible by all previously considered
            // divisors and the current divisor has been found.
            if(number != lower) {
                // Start searching for divisibility by the
                // next smaller divisor.
                number--;
                // Make this value the new common multiple.
                increment = result;
                // Begin testing multiples of the new common multiple.
                result = 0;
            } else {
                // Divisibility has now been enforced for
                // every required divisor.
                found = true;
            }
        }
    }

    cout << result;
    return 0;
}

