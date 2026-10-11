/*
 * Project Euler 6
 *
 * Find the difference between:
 *     - the square of the sum of the first 100 natural numbers
 *     - the sum of the squares of the first 100 natural numbers
 *
 * Idea:
 *     Compute both quantities directly and take their difference.
 *
 * Complexity:
 *     O(n)
 */

#include <cstdlib>
#include <iostream>
using namespace std;
int main(int argc, char** argv) {
    // Sum of 1² + 2² + ... + 100².
    long sumSquares = 0;

    // Sum of 1 + 2 + ... + 100.
    long squareSums = 0;
    
    for(int i = 1; i <= 100; i++) {
        squareSums += i;
        sumSquares += i*i;
    }
    squareSums = squareSums * squareSums;
    
    // Calculate the required difference.
    int result;
    if(sumSquares < squareSums) {
        result = squareSums - sumSquares;
    } else {
        result = sumSquares - squareSums;
    }
    
    cout << result;
    return 0;
}

