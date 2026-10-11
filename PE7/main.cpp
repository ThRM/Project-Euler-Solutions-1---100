/*
 * Project Euler 7
 *
 * Find the 10,001st prime number.
 *
 * Idea:
 *     Use the Sieve of Eratosthenes to generate prime numbers.
 *     Count primes as they are discovered and stop when the
 *     target index is reached.
 *
 * Notes:
 *     - 2 is handled separately.
 *     - Only odd numbers are considered by the sieve.
 */

#include <cstdlib>
#include <iostream>
using namespace std;

/*
 * Returns the nth prime number.
 *
 * Assumes the sieve is large enough to contain the answer.
 */
int getPrime(int primeTarget) {
    // Handle the first prime separately.
    if (primeTarget == 1) {
        return 2;
    }

    const long long sieveLength = 200000;
    bool sieve[sieveLength];

    // Initially assume all odd numbers are prime.
    for (long long i = 3; i < sieveLength; i += 2) {
        sieve[i] = true;
    }    

    // 2 is already counted as the first prime.
    int currentPrimeIndex = 1;

    // Process odd numbers in ascending order.
    for (long long i = 3; i < sieveLength; i += 2) {  
        // If the number is still marked, it is prime.
        if (sieve[i]) {
            // Return the target prime once found.
            currentPrimeIndex += 1;            
            if (currentPrimeIndex == primeTarget) {
                return i;
            }            

            // Mark multiples of the prime as composite.            
            // Multiples below i² have already been removed by
            // smaller prime factors.
            for (long long j = i * i; j < sieveLength; j += i) {
                sieve[j] = false;
            }
        }
    }

    // The sieve was not large enough.
    cout << currentPrimeIndex << endl;
    return -1;
}

int main(int argc, char** argv) {
    int primeTarget = 10001;

    cout << getPrime(primeTarget) << endl;

    return 0;
}