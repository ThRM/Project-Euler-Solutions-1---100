/*
 * Project Euler 10
 *
 * Find the sum of all prime numbers less than 2,000,000.
 *
 * Idea:
 *     Use a sieve that stores only odd numbers.
 *     Index i represents the odd number:
 *
 *         2 * i + 1
 *
 *     This halves the memory requirements compared to storing
 *     every integer.
 */

#include <cstdlib>
#include <iostream>
using namespace std;


int main(int argc, char** argv) {
    // Upper bound.
    const long sumPrimes = 2000000;

    // Number of odd values below the limit.
    const long number = sumPrimes/2;
    long prime = -1;

    // Running total of primes found.
    long long sum = 2; // 2 is a prime, and our array is just odd numbers

    // notPrimes[i] indicates whether the odd number
    // (2 * i + 1) has been marked composite.
    bool notPrimes[number];
    
    // Initially assume all odd numbers are prime.
    for(long i = 0; i < number; i++) {
        notPrimes[i] = false;
    }
    
    // Index 0 corresponds to 1, which is not prime.
    notPrimes[0] = true;
    
    for(long i = 1; i < number; i++) {
        long num = i * 2 + 1;
        if(!notPrimes[i]) {
            sum+= num;
        }
        
        // Mark all odd multiples of num as composite.
        // Since index k represents 2*k+1:
        //     i
        //     i + num
        //     i + 2*num
        // correspond to successive odd multiples.
        for(long j = i; j < number; j+= num) {
            notPrimes[j] = true;
        }
    }
    cout << sum;
    return 0;
}

