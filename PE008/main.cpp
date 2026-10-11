/*
 * Project Euler 8
 *
 * Find the greatest product of thirteen adjacent digits
 * in the given 1000-digit number.
 *
 * Idea:
 *     Slide a window of thirteen digits across the number.
 *     Compute the product of the digits in each window and
 *     track the largest product found.
 */

#include <cstdlib>
#include <string>
#include <iostream>

using namespace std;

int main(int argc, char** argv) {
    // Largest product found so far.
    long long maxProduct = 0;
    
    string nums = "73167176531330624919225119674426574742355349194934"
                        "96983520312774506326239578318016984801869478851843"
                        "85861560789112949495459501737958331952853208805511"
                        "12540698747158523863050715693290963295227443043557"
                        "66896648950445244523161731856403098711121722383113"
                        "62229893423380308135336276614282806444486645238749"
                        "30358907296290491560440772390713810515859307960866"
                        "70172427121883998797908792274921901699720888093776"
                        "65727333001053367881220235421809751254540594752243"
                        "52584907711670556013604839586446706324415722155397"
                        "53697817977846174064955149290862569321978468622482"
                        "83972241375657056057490261407972968652414535100474"
                        "82166370484403199890008895243450658541227588666881"
                        "16427171479924442928230863465674813919123162824586"
                        "17866458359124566529476545682848912883142607690042"
                        "24219022671055626321111109370544217506941658960408"
                        "07198403850962455444362981230987879927244284909188"
                        "84580156166097919133875499200524063689912560717606"
                        "05886116467109405077541002256983155200055935729725"
                        "71636269561882670428252483600823257530420752963450";

    // Consider*every block of thirteen consecutive digits.
    for(int i = 0; i + 12 < nums.length(); i++) {
        long long product = 1;

        // compute the product of the current window.
        for(int j = 0; j < 13; j++) {
            char temp = nums[i + j];

            // A window containing zero has product zero.                
            // No case for '1' is required because
            // multiplying by 1 leaves the product unchanged.
            switch (temp) {
                case '0': product = 0;
                                break;
                case '2': product = product * 2;
                                break;
                case '3': product = product * 3;
                                break;
                case '4': product = product * 4;
                                break;
                case '5': product = product * 5;
                                break;
                case '6': product = product * 6;
                                break;
                case '7': product = product * 7;
                                break;
                case '8': product = product * 8;
                                break;
                case '9': product = product * 9;
                                break;
            }
        }
        
        // Update the largest product found.
        if(maxProduct < product) {
            maxProduct = product;
        }
    }
    cout << maxProduct;
    return 0;
}

