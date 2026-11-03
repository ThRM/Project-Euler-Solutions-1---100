/*
 * Purpose:
 * Find the greatest product of four adjacent numbers in a 20x20 grid.
 *
 * Approach:
 * The program reads the grid from "numbers.txt" into a two-dimensional
 * array. Each cell is then considered as a potential starting position
 * for a sequence of four numbers.
 *
 * For every cell, the product of four adjacent values is calculated in
 * each possible direction:
 *   - Horizontal (right)
 *   - Vertical (down)
 *   - Diagonal down-right (\)
 *   - Diagonal down-left (/)
 *
 * Before calculating a product, boundary checks ensure that all four
 * positions lie within the grid. The largest product encountered during
 * the search is stored and printed once all positions have been examined.
 *
 * This is a brute-force solution that systematically evaluates every
 * valid sequence of four adjacent numbers in the grid.
 */

#include <cstdlib>
#include <iostream>
#include <fstream>

using namespace std;

int main(int argc, char** argv) {
    // Open the file containing the 20x20 grid of numbers
    fstream numbers("numbers.txt", fstream::in);

    // Store the grid values in a 20x20 array
    int grid[20][20];
    
    // Read all values from the file into the grid
    for(int x = 0; x < 20; x++) {
        for(int y = 0; y < 20; y++) {
            numbers >> grid[x][y];
        }
    }

    // Close the input file once reading is complete
    numbers.close();
    
    // Store the largest product found so far
    int max = 0;

    // Examine every position in the grid as a potential starting point
    for(int x = 0; x < 20; x++) {
        for(int y = 0; y < 20; y++) {
            int product;
            // Check horizontally to the right
            if(x + 3 < 20) {
                product = grid[x][y] * grid[x + 1][y] * grid[x + 2][y] * grid[x + 3][y];
                if(max < product) {
                    max = product;
                }
            }
            
            // Check vertically downward
            if(y + 3 < 20) {
                product = grid[x][y] * grid[x][y + 1] * grid[x][y + 2] * grid[x][y + 3];
                if(max < product) {
                    max = product;
                }
            }
            
            // Check diagonally down-right
            if(x + 3 < 20 && y + 3 < 20) {
                product = grid[x][y] * grid[x + 1][y + 1] * grid[x + 2][y + 2] * grid[x + 3][y + 3];
                if(max < product) {
                    max = product;
                }
            }
            
            // Check diagonally down-left
            if(0 <= x - 3 && y + 3 < 20) {
                product = grid[x][y] * grid[x - 1][y + 1] * grid[x - 2][y + 2] * grid[x - 3][y + 3];
                if(max < product) {
                    max = product;
                }
            }
        }
    }
    
    // Output the largest product of four adjacent numbers
    cout << max;
    return 0;
}

