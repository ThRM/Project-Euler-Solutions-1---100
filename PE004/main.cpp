/*
 * Project Euler 4
 *
 * Find the largest palindrome made from the product of two
 * three-digit numbers.
 *
 * Idea:
 *     Check every product of two three-digit numbers.
 *     Reverse the digits of the product and compare it with
 *     the original number. If they are equal, the number is
 *     a palindrome. Track the largest palindrome found.
 *
 * Complexity:
 *     O(n²), where n = 900.
 */

#include <cstdlib>
#include <iostream>

using namespace std;

// Test all products of two three-digit numbers.
int main(int argc, char** argv) {
    int palindrome = 0;
    
    for(int i = 100; i < 1000; i++) {
        for(int j = i; j < 1000; j++) {
            int result = i * j;
            
            // Reverse the digits of the product.
            int reversed = 0;
            int temp = result;
            while(temp != 0) {
                reversed *= 10;
                reversed += temp % 10;
                temp /= 10;
            }
                    
            // A number is a palindrome if it equals its reverse.
            if(result == reversed) {
                if(palindrome < result) {
                    palindrome = result;
                }
            }
        }
    }
    cout << palindrome;
    return 0;
}

