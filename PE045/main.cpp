/*
 * Purpose:
 * Find the next number after 40755 that is simultaneously
 * triangular, pentagonal, and hexagonal.
 *
 * Approach:
 * Triangular, pentagonal, and hexagonal numbers are generated
 * independently. At each step, the smallest current value is
 * advanced until all three sequences reach the same number.
 *
 * The known solution 40755 is skipped, and the search
 * continues until the next common value is found.
 */

#include <cstdlib>
#include <iostream>

using namespace std;

int main(int argc, char** argv) {   
    // Current values from each sequence.
    long long tri = 0;
    long long pent = 0;
    long long hex = 0;
    
    // Sequence indices.
    long long triNum = 1;
    long long pentNum = 1;
    long long hexNum = 1;
    
    bool found = false;
    while(!found) {
        // Advance the triangular sequence if it is behind.
        if(tri < pent || tri < hex) {
            tri = triNum * (triNum + 1)/2;
            triNum++;
        }
        
        // Advance the pentagonal sequence if it is behind.
        if(pent < hex || pent < tri) {
            pent = pentNum * (3 * pentNum - 1)/2;
            pentNum++;
        }
        
        // Advance the hexagonal sequence if it is behind.
        if(hex < tri || hex < pent) {
            hex = hexNum * (2 * hexNum - 1);
            hexNum++;
        }
        
        // Check whether all three sequences coincide.
        if(hex == tri && tri == pent) {  
            // Skip the known solution 40755.
            if(tri <= 40755) {
                tri = triNum * (triNum + 1)/2;
                triNum++;
            
                pent = pentNum * (3 * pentNum - 1)/2;
                pentNum++;
            
                hex = hexNum * (2 * hexNum - 1);
                hexNum++;
            } else {
                found = true;
            }
        }
    }
    
    // Display the next common value.
    cout << tri;
    
    return 0;
}