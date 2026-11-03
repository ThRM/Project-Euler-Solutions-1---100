/*
 * Purpose:
 * Determine the index of the first Fibonacci number containing
 * 1000 digits.
 *
 * Approach:
 * Fibonacci numbers are represented as strings because they
 * quickly exceed the range of built-in integer types.
 *
 * Successive terms are generated using manual digit-by-digit
 * addition until a term with 1000 digits is produced. The
 * index of this term is then displayed.
 */

#include <cstdlib>
#include <iostream>
#include <string>
#include <fstream>

using namespace std;

int main(int argc, char** argv) {
    // Store the two most recent Fibonacci terms.
    string current = "1";
    string previous = "1";
    string temp;
    
    // Current Fibonacci term index.
    int term = 2;

    // Generate terms until one contains 1000 digits.
    while(current.length() < 1000) {       
        term++;

        // Preserve the current term before updating it.
        temp = current;
        
        int carry = 0;

        // Add the previous Fibonacci number to the current one.
        for(int j = current.length() - 1, k = previous.length() - 1; 0 <= j || 0 <= k; j--, k--) {
            // Only digits from the current term remain.
            if(k < 0) {
                int a = current[j] - 48;
                int result = a + carry;
                if(9 < result) {
                    carry = result/10;
                    result = result%10;
                    current[j] = result + 48;
                } else {
                    current[j] = result + 48;
                    carry = 0;
                }
            // Only digits from the previous term remain.
            } else if(j < 0) {
                int b = previous[k] - 48;
                int result =  b + carry;
                if(9 < result) {
                    carry = result/10;
                    result = result%10;
                    current = char(result + 48) + current;
                } else {
                    current = char(result + 48) + current;
                    carry = 0;
                }
            // Add corresponding digits from both terms.
            } else {
                int a = current[j] - 48;
                int b = previous[k] - 48;
                int result = a + b + carry;

                if(9 < result) {
                    carry = result/10;
                    result = result%10;
                    current[j] = result + 48;
                } else {
                    current[j] = result + 48;
                    carry = 0;
                }
            }
        }
        
        // Prepend any remaining carry.
        while(0 < carry) {
            int digit = carry%10;
            carry = carry/10;
            current = char(digit + 48) + current;
        }

        // Advance the Fibonacci sequence.
        previous = temp;
        cout << current.length() << endl;
    }

    // Save the resulting Fibonacci number.
    ofstream out("number.txt");
    
    out << current << endl;
    out.close();
    
    // Output the term index.
    cout << term << endl;
    return 0;
}

