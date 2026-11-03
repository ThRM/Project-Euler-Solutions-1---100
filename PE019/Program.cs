/*
 * Purpose:
 * Count the number of Sundays that fell on the first day of the
 * month during the twentieth century (1 Jan 1901 to 31 Dec 2000).
 *
 * Approach:
 * Starting from 1 January 1900, the program advances month by month,
 * tracking the current day count. Whenever the first day of a month
 * falls on a Sunday during the target period, the count is increased.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerProblem19 {
    class Program {
        static void Main(string[] args) {
            // Number of Sundays that occur on the first day of a month.
            int count = 0;

            // Days elapsed since 1 January 1900.
            int day = 1;

            Console.SetBufferSize(200, 200);

            // Process each year from 1900 to 2000.
            for (int i = 1900; i <= 2000; i++) {

                // Begin counting once 1901 is reached.
                if (i == 1901) {
                    count = 0;
                }

                // Process each month of the current year.
                for (int j = 1; j <= 12; j++) {
                    // Check whether the first day of the month is a Sunday.
                    if (day%7 == 0) {
                        count++;
                    }

                    // Advance to the first day of the next month.
                    if (j == 2) {
                        // February: determine whether the year is a leap year.
                        if (i % 4 == 0) {
                            if (i % 100 == 0) {
                                if (i % 400 == 0) {
                                    day += 29;
                                } else {
                                    day += 28;
                                }
                            } else {
                                day += 29;
                            }
                        } else {
                            day += 28;
                        }
                    } else {
                        // Handle months with 30 or 31 days.
                        if (j <= 7) {
                            if (j % 2 == 0) {
                                day += 30;
                            } else {
                                day += 31;
                            }
                        } else {
                            if (j % 2 == 0) {
                                day += 31;
                            } else {
                                day += 30;
                            }
                        }
                    }
                }
            }

            // Display the final count.
            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
