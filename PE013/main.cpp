/*
 * Purpose:
 * Calculate the sum of a collection of large integers and output
 * the first ten digits of the result.
 *
 * Approach:
 * The numbers are stored as strings because they are larger than
 * the range supported by built-in integer types.
 *
 * Each number is added to a running total using the same process
 * taught for manual addition:
 *
 *   1. Start at the least significant digit.
 *   2. Add corresponding digits from both numbers.
 *   3. Propagate any carry to the next column.
 *   4. Continue until all digits have been processed.
 *
 * The running total is maintained as a string and updated after
 * each addition. Once all numbers have been summed, the complete
 * result is displayed along with its first ten digits.
 */

#include <string>
#include <vector>
#include <iostream>
#include <fstream>

using namespace std;

int main(int argc, char** argv) {
    // Open the file containing the large numbers.
    ifstream in("numbers.txt");
    string number;
    vector<string> numbers;
    
    // Read each number from the file.
    while(getline(in, number)) {
        // Keep only the first 50 digits from each line.
        number = number.substr(0, 50);
        numbers.push_back(number);
    }
    in.close();
    
    // Initialise the running total using the first number.
    number = numbers[0];
    
    // Add each remaining number to the running total.
    for(int i = 1; i < numbers.size(); i++) {
        int carry = 0;
        // Process digits from right to left.
        for(int j = number.length() - 1, k = numbers[i].length() - 1; 0 <= j || 0 <= k;j--, k--) {
            // Remaining digits belong only to the current total.
            if(k < 0) {
                int a = number[j] - 48;
                int result = a + carry;
                if(9 < result) {
                    carry = result/10;
                    result = result%10;
                    number[j] = result + 48;
                } else {
                    number[j] = result + 48;
                    carry = 0;
                }
            // Remaining digits belong only to the new number.
            } else if(j < 0) {
                int b = numbers[i][k] - 48;
                int result =  b + carry;
                if(9 < result) {
                    carry = result/10;
                    result = result%10;
                    number = char(result + 48) + number;
                } else {
                    number = char(result + 48) + number;
                    carry = 0;
                }
            // Add corresponding digits from both numbers.
            } else {
                int a = number[j] - 48;
                int b = numbers[i][k] - 48;
                int result = a + b + carry;

                if(9 < result) {
                    carry = result/10;
                    result = result%10;
                    number[j] = result + 48;
                } else {
                    number[j] = result + 48;
                    carry = 0;
                }
            }
        }

        // Prepend any remaining carry to the result.
        while(0 < carry) {
            int digit = carry%10;
            carry = carry/10;
            number = char(digit + 48) + number;
        }
    }

    // Display the complete sum.
    cout << number << endl;

    // Display the first ten digits of the sum.
    for(int i = 0; i < 10; i++) {
        cout << number[i];
    }
    
    return 0;
}

