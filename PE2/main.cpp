#include <cstdlib>
#include <iostream>
using namespace std;

/*
 * Project Euler 2
 *
 * Find the sum of all even Fibonacci numbers not exceeding 4,000,000.
 *
 * Idea:
 *     Generate Fibonacci numbers iteratively and add each term to the
 *     running total whenever it is even.
 *
 * Complexity:
 *     O(number of Fibonacci terms below 4,000,000)
 */
int main() {
    // Store three consecutive Fibonacci numbers.
    int one = 1;
    int two = 1;
    int three = 2;
    
    long sum = 0;
    
    // Generate Fibonacci numbers until the limit is reached.
    while(three < 4000000) {
        // Add even-valued terms to the total.
        if(three%2 == 0) {
            sum+= three;
        }

        // Advance to the next Fibonacci number.
        one = two;
        two = three;
        three = one + two;
    }
    cout << sum;
    return 0;
}

