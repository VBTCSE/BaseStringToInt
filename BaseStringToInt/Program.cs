using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseStringToInt
{
    class Program
    {
        // Array of single character strings.
        // Use base 10 integer as an index, get the corresponding character representing that number
        // in the selected base, up to base 36.
        static string[] sChar = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
                                 "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                                 "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};


        static void Main(string[] args)
        {
            // Creates a base 10 integer by evaluating an input string and base value,
            // which is specified by the user.
            // For example, if the input string is "100" and the base is 2, then the 
            // integer (base-10) that is created is 4.

            // First, get the base value.
            // Output a message, specifying what is to be entered.
            ConsoleIO.askForBaseValue();
            // Get the base.  Must be no less than 2 and no greater than 36.
            int b = ConsoleIO.getNumber(2, 36);

            // Get the input string from the user.
            string s = "";

            // Set a flag which will indicate whether the input string is a 
            // valid representation of a number in base b.
            bool isValid = true;

            do
            {
                // Loop over input until a valid string is received.
                isValid = true;

                // Output a message asking for a number in the given base.
                ConsoleIO.askForNumberInBase(b);
                // Get the number in base b from the user.
                // The Trim() method removes any leading or trailing whitespace from the string.
                // Reference: https://msdn.microsoft.com/en-us/library/t97s7bs3(v=vs.110).aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-1
                s = ConsoleIO.getNumberAsString().Trim();

                // Loop over each character in the string.
                for (int charPos = 0; charPos < s.Length; charPos++)
                {
                    // Get one single digit from the input string, at position charPos.
                    string digit = s.Substring(charPos, 1);

                    // index value
                    int indexVal = 0;
                    for (indexVal = 0; indexVal < b; indexVal++)
                    {
                        // Loop over the valid symbols in the array sChar.
                        // Leave this loop if the one single digit from the input string, 
                        // matches the character in the sChar array at index indexVal.
                        // The Equals() method is documented at: https://msdn.microsoft.com/en-us/library/c64xh8f9(v=vs.110).aspx
                        // The comparison type is documented at: https://msdn.microsoft.com/en-us/library/system.stringcomparison(v=vs.110).aspx
                        if (digit.Equals(sChar[indexVal]))
                        {
                            break;  // leave this loop upon finding a match.
                        }
                    }

                    // Loop has exited.
                    // if index value equals base, the above loop covered all valid digits in base b and
                    // did not find a match.  Clear the isValid flag to indicate that this is not a valid
                    // input string for a number in base b.
                    if (indexVal == b)
                    {
                        isValid = false;
                    }

                }

                // if, after looping over all characters of the input string, the flag isValid is false,
                // this means that at least one character was not a valid digit for a number in base b.
                if (isValid == false)
                {
                    // Output a message indicating that the input was invalid and that it needs to be 
                    // re-entered.
                    ConsoleIO.tellInvalidInput();
                }

            } while (isValid == false); // keep asking for input as long as the input was not valid.



            // At this point, the input string is a valid representation of a number in base b.


            // Create a base-10 integer corresponding to the input string, base b.
            int m = convertBaseStringToInt(s, b);


            // Display the result on the console.
            ConsoleIO.showResult(m, b, s);

            ConsoleIO.waitForKeypress();
        }





        static int convertBaseStringToInt(string s, int b)
        {
            int retval = 0;

            if (s.Equals(""))
            {
                // return 0
            }
            else
            {
                // Get the value of the last digit of the string.

                string digit = s.Substring(s.Length - 1, 1);  // The last digit in the string s.
                int valueLastDigit = 0;
                for (int indexVal = 0; indexVal < b; indexVal++)
                {
                    // Loop over the valid symbols in the array sChar.
                    // Leave this loop if the one single digit from s, 
                    // matches the character in the sChar array at index indexVal.


                    bool isEqual = false;

                    //==========================================================================================================
                    // Use the String.Equals() method to determine whether the value of the string variable digit 
                    // equals the value of the string variable sChar[indexVal].
                    // Example: digit = "3" and sChar[indexVal] = "4", then isEqual = false.
                    // Example: digit = "3" and sChar[indexVal] = "3", then isEqual = true.

                    // The Equals() method is documented at: https://msdn.microsoft.com/en-us/library/c64xh8f9(v=vs.110).aspx
                    // Add code here to determine if these string are equal, assigning the true or false result to the
                    // variable isEqual.
                    //vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
                    // <-------------------------------------------------------------------------------------- Add one line of code here
                    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                    //==========================================================================================================

                    if (isEqual)
                    {
                        valueLastDigit = indexVal;
                        break;  // leave this loop upon finding a match.
                    }
                }



                // Set remainingString to all but the last digit of s.
                string remainingString = s.Substring(0, s.Length - 1);


                //==========================================================================================================
                // Call this function, recursively, to obtain the value of the rest of the string.
                // Example: remainingString = "110" and base = 2, then valueRemainingString = 6.
                // Note: valueRemainingString is obtained by calling this function, convertBaseStringToInt(), recursively,
                // operating on remaininString.
                int valueRemainingString = 0;
                // Add code here to obtain valueRemainingString by calling this function recursively.
                // Reference: Quick Calculation #3: Base Conversion (1).
                //vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
                // <-------------------------------------------------------------------------------------- Add one line of code here
                //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                //==========================================================================================================


                // Calculate the value of the string s as b * valueRemainingString + valueLastDigit.
                retval = b * valueRemainingString + valueLastDigit;
            }


            return retval;
        }


        
    }
}
