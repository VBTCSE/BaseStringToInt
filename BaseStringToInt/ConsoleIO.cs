using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseStringToInt
{
    class ConsoleIO
    {
        public static int getNumber(int minVal = 0, int maxVal = 0)
        {
            // Input a 32-bit integer >= minVal from the user.  The default value of minVal is 0.
            // Return this value.


            int n = -1;  // Initial, default return value.  Returning -1 signals an error in this method.

            if (minVal == 0)
            {
                // Ask the user to enter a non-negative integer.
                // Reference: https://msdn.microsoft.com/en-us/library/system.console.write(v=vs.110).aspx
                Console.Write("Enter a non-negative integer: ");
            }
            else
            {
                // Ask the user to enter an integer >= minVal.
                Console.Write("Enter an integer >= {0}: ", minVal);
            }




            if (maxVal != 0)
            {
                // A value of maxVal = 0, is a flag, indicating that there is no upper limit on the user's input.
                // If maxVal is anything else, then the user's input must be <= maxVal (assuming that maxVal >= minVal).

                // First, verify that maxVal >= minVal.  Calling program could make an incorrect call...
                if (maxVal < minVal)
                {
                    try
                    {
                        throw new ArgumentException(String.Format("Invalid argument pair in getNumber(): maxVal = {0} < minVal = {1}.", maxVal, minVal));
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);   // Output an error message if arguments are invalid.
                        return n;   // Return the value n = -1, to signal an error.
                    }
                }
            }




            // Start a do-while loop to ensure that the input integer is >= minVal.
            do
            {

                // Read in a line from the console.
                // Reference: https://msdn.microsoft.com/en-us/library/system.console.readline(v=vs.110).aspx
                string input = Console.ReadLine();


                // Parse the input string to an integer inside a try-catch block.
                // In the catch block, output the exception message and immediately return the initial, default value of n.
                // Reference: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number
                try
                {
                    // Try to convert the input string to an integer.
                    n = Int32.Parse(input);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);   // Output an error message if parsing cannot be done.
                    return n;   // Return the value n = -1, to signal an error.
                }

                // If n is negative, tell the user to enter a non-negative value.
                if (n < minVal)
                {
                    // Reference: https://msdn.microsoft.com/en-us/library/system.console.write(v=vs.110).aspx
                    Console.WriteLine("The entered value is less than {0}.  Enter a larger value.", minVal);
                }
                else if (maxVal != 0 && n > maxVal)
                {
                    // An upper limit is imposed and the user's input is greater than the upper limit.
                    Console.WriteLine("The entered value is greater than {0}.  Enter a smaller value.", maxVal);
                }

            } while (n < minVal || (maxVal !=0 && n > maxVal));


            return n;   // Return the non-negative input integer n.
        }

        public static string getNumberAsString()
        {
            // Input a string that represents a valid non-negative number in base b.
            string retval = Console.ReadLine();

            return retval;
        }


        public static void showResult(int n, int b, string s)
        {
            // Displays on the console the value of the inputs n, b, s.

            Console.WriteLine("The value of {0} (base-{1}) is {2} (base-10).", s, b, n);
        }


        public static void showError()
        {
            Console.WriteLine("Error: could not resolve user's input.");
        }


        public static void waitForKeypress()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        public static void askForBaseValue()
        {
            Console.WriteLine("Enter the base value.");
        }

        public static void askForNumberInBase(int b)
        {
            Console.Write("Enter a number in base {0}: ", b);
        }

        public static void tellInvalidInput()
        {
            Console.WriteLine("Input was invalid.  Re-enter.");
        }
    }
}
