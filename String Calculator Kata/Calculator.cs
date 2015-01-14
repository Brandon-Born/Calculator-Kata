// Kata Taken From http://osherove.com/tdd-kata-1/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace String_Calculator_Kata
{
    /// <summary>
    /// The SUT used for this kata
    /// </summary>
    public class Calculator
    {

        /// <summary>
        /// The method can take 0, 1 or 2 numbers, and will return their sum
        /// </summary>
        /// <param name="numbers">String of numbers</param>
        /// <returns>sum</returns>
        public static int Add(string numbers)
        {
            // Stores all negative numbers found for error check
            List<int> negativeNumbers = new List<int>();
            // Used to store summation result
            int result = 0;

            // We know it's an empty string so we're done.
            if (!string.IsNullOrEmpty(numbers))
            {
                // If the string contains a comma we know we need to add them together
                // also detects if //;\n pattern may exist
                if (numbers.Contains(",") || numbers.Contains("\n"))
                {
                    // base delimiters
                    List<char> delimters = new List<char>() { ',', '\n' };

                    //add new delimiter if exists
                    if(numbers.StartsWith("//") && numbers.Length > 3 && numbers[3].Equals('\n'))
                    {
                        delimters.Add(numbers[2]);
                    }

                    foreach (string number in numbers.Split(delimters.ToArray()))
                    {
                        result += ParseInt(number, negativeNumbers);
                    }
                }
                else
                {
                    // Only one number so parse it and return if possible
                    result = ParseInt(numbers, negativeNumbers);
                }
            }

            //check for negative numbers
            if (negativeNumbers.Count() > 0)
            {
                string exceptionMessage = "negatives not allowed: ";

                foreach(int negative in negativeNumbers)
                {
                    exceptionMessage += negative + ",";
                }

                throw new ArgumentException(exceptionMessage.TrimEnd(','));
            }

            return result;
        }

        /// <summary>
        /// Does the parsing heavy lifting and error checking
        /// </summary>
        /// <param name="numberToParse">the string that will be parsed</param>
        /// <param name="negativeNumbers">List to add to if a negative is found</param>
        /// <returns></returns>
        private static int ParseInt(string numberToParse, List<int> negativeNumbers)
        {
            int output = 0;

            int.TryParse(numberToParse, out output);

            if (output < 0)
            {
                negativeNumbers.Add(output);
            }
            
            return output;
        }
    }
}
