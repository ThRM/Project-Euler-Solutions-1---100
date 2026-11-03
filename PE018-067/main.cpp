/*
 * Purpose:
 * Find the maximum total obtainable by moving from the top of a
 * number triangle to the bottom, moving only to adjacent numbers
 * in the row below.
 *
 * Approach:
 * The triangle is stored in a one-dimensional vector and the
 * starting index of each row is recorded separately.
 *
 * The solution works from the bottom of the triangle upwards.
 * For each value, the larger of its two children is added to it.
 * Once a row has been processed, each element represents the
 * maximum total obtainable from that position to the bottom.
 *
 * When the process reaches the top row, the first element contains
 * the maximum path sum through the entire triangle.
 */

#include <cstdlib>
#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

int main(int argc, char** argv) {
    // Stores all triangle values in a single vector.
    vector<int> triangle;

    // Stores the starting index of each row.
    vector<int> rowsStart;

    int count = 0;
    int index = 0;
    int rows = 0;
    
    // Read the triangle from the input file
    // ifstream in("triangle.txt");
    ifstream in("triangle2.txt");
    
    while(in.eof() == false) {
        // Record the starting position of a new row.
        if(count == 0) {
            rowsStart.push_back(index);
        }
        
        int number;
        in >> number;
        triangle.push_back(number);
        count++;

        // Move to the next row when the current row
        // contains the required number of elements.
        if(rows < count) {
            rows++;
            count = 0;
        }
        index++;
    }
    in.close();
    
    // Process the triangle from the bottom row upwards.
    for(int i = rowsStart.size() - 1; 0 < i; i--) {
        int top = rowsStart[i - 1];
        int bottom = rowsStart[i];
        
        // Update each element in the current row by adding
        // the larger of its two children.
        for(int j = top, f = 0; j < bottom; j++, f++) {
            if(triangle[bottom + f] < triangle[bottom + f + 1]) {
                triangle[j] +=triangle[bottom + f + 1];
            } else {
                triangle[j] +=triangle[bottom + f];
            }
        }
    }
    
    // The top element now contains the maximum path sum.
    cout << triangle[0];
    return 0;
}

