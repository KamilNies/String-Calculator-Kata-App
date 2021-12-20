using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace String_Calculator_Kata
{
    public class StringCalculator
    {
        private int delimiterEndIndex;
        private int delimiterStartIndex;
        private string? delimiter;
        private string[]? delimiterArray;

        public int Add(string numbers)
        {
            if (numbers == "")
            {
                return 0;
            }
            else if (HasDelimiter(numbers))
            {
                if (numbers.StartsWith("//"))
                {
                    if (IsDelimiterString(numbers))
                    {
                        int delimiterLength = CalculateDelimiterLength(numbers);

                        delimiter = new string(numbers.Substring(delimiterStartIndex, delimiterLength));

                        if (HasMultipleDelimiters(delimiter))
                        {
                            StoreDelimiters();
                        }

                        var stringWithoutDelimiter = RemoveDelimiterFromString(numbers);

                        if (IsArrayNullOrEmpty(delimiterArray))
                        {
                            var strArray = stringWithoutDelimiter.Split(delimiter);

                            return SumOfStringArray(strArray);
                        }
                        else
                        {
                            var numStrArray = stringWithoutDelimiter.Split(delimiterArray, StringSplitOptions.None);

                            return SumOfStringArray(numStrArray);
                        }

                    }
                    else
                    {
                        delimiter = new string(numbers.Skip(2).Take(1).ToArray());

                        string stringWithoutDelimiter = RemoveDelimiterFromString(numbers);

                        var strArray = stringWithoutDelimiter.Split(delimiter);

                        return SumOfStringArray(strArray);
                    }

                }

                var stringArray = numbers.Split(new string[]
                {
                    "\n",
                    ","
                },
                StringSplitOptions.None);

                return SumOfStringArray(stringArray);
            }
            else
            {
                return int.Parse(numbers);
            }
        }

        private void StoreDelimiters()
        {
            delimiter ??= "";

            delimiterArray = delimiter.Split(new string[] { "]", "[" }, StringSplitOptions.None);

            delimiterArray = delimiterArray.ToList()
                .Where(str => !string.IsNullOrEmpty(str))
                .ToArray();
        }

        private static bool IsArrayNullOrEmpty(string[]? delimiterArray)
        {
            delimiterArray ??= new string[0];
            var test = delimiterArray.Length == 0;
            return test;
        }

        private static bool HasMultipleDelimiters(string? delimiter)
        {
            delimiter ??= string.Empty;

            return delimiter.Contains(']') && delimiter.Contains('[');
        }

        private int CalculateDelimiterLength(string numbers)
        {
            delimiterStartIndex = 3;

            delimiterEndIndex = numbers.IndexOf("]\n");

            int delimiterLength = delimiterEndIndex - delimiterStartIndex;

            return delimiterLength;
        }

        private static string RemoveDelimiterFromString(string numbers)
        {
            return numbers.Substring(numbers.IndexOf('\n') + 1);
        }

        private static bool IsDelimiterString(string numbers)
        {
            return numbers.StartsWith("//[") && numbers.Contains("]\n");
        }

        private static int SumOfStringArray(string[] stringArray)
        {
            var numberArray = stringArray.Select(str => int.Parse(str));

            if (HasNegativNumbers(numberArray))
            {
                throw new ArgumentException($"negatives not allowed {ListNegativeNumbers(numberArray)}");
            }

            if (HasNumbersAboveOneThousand(numberArray))
            {
                numberArray = RemoveNumbersAboveOneThousand(numberArray);
            }

            return numberArray.Sum();
        }

        private static IEnumerable<int> RemoveNumbersAboveOneThousand(IEnumerable<int> numberArray)
        {
            return numberArray.Where(num => num < 1001);
        }

        private static bool HasNumbersAboveOneThousand(IEnumerable<int> numberArray)
        {
            return numberArray.Any<int>(num => num > 1000);
        }

        private static string ListNegativeNumbers(IEnumerable<int> numberArray)
        {

            return string.Join(',', numberArray.Where(num => num < 0));
        }

        private static bool HasNegativNumbers(IEnumerable<int> numberArray)
        {
            return numberArray.Any<int>(num => num < 0);
        }

        private static bool HasDelimiter(string numbers)
        {
            return numbers.StartsWith("//") || numbers.Contains(',') || numbers.Contains('\n');
        }
    }
}
