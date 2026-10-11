#include <cstdlib>
#include <iostream>
using namespace std;

/*
Project Euler 1

Find the sum of all natural numbers below 1000 that are
multiples of 3 or 5.

Idea:
    Iterate through every number less than 1000 and add it
    to the running total if it is divisible by 3 or 5.

Complexity:
    O(n)
*/
int main() {
    int sum = 0;

    // Check every number from 3 to 999.
    for(int i = 3; i < 1000; i++) {

        // A number is included if it is a multiple
        // of either 3 or 5.
        if(i%3 == 0 || i%5 == 0) {
            sum+= i;
        }
    }
    
    cout << sum;
}

