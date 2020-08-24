using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Binary_Search_Implementation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input the int Array - each int separated by a space or input \"Seed\" for a Random Array of 100 unique numbers");

            var input = Console.ReadLine();
            var inputList = new List<int>();

            if (input.ToLower() == "seed")
            {
                inputList = GenerateArray();
            }

            else
            {
                inputList = input
                    .Split(" ")
                    .Select(int.Parse)
                    .OrderBy(x => x)
                    .ToList();
            }

            Console.WriteLine("the sorted array looks like this:");
            Console.WriteLine(string.Join(" ", inputList));

            Console.WriteLine("Please input the number you are looking for");
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(inputList.ToArray(), number));
        }

        private static List<int> GenerateArray()
        {
            List<int> inputList;

            var min = 0;
            var max = 0;
            bool validInput = true;

            while (validInput)
            {
                Console.WriteLine("Please input the min and max values for the numbers in the array each on a new line");

                min = int.Parse(Console.ReadLine());
                max = int.Parse(Console.ReadLine());

                if (max - min < 100)
                {
                    Console.WriteLine("Please provide a valid interval of atleast 100 numbers");
                    continue;
                }
                validInput = false;
            }

            var generator = new ArrayGenerator(min, max);
            inputList = generator.GenerateArray()
                .OrderBy(x => x)
                .ToList();
            return inputList;
        }

        public static string BinarySearch(int[] inputArray, int number)
        {
            int lowBoundryIndex = 0;
            int highBoundryIndex = inputArray.Length - 1;
            int middleIndex = 0;

            int counter = 0;

            while (lowBoundryIndex<=highBoundryIndex)
            {
                middleIndex = (lowBoundryIndex + highBoundryIndex) / 2;

                if (inputArray[middleIndex] == number)
                {
                    return $"The number you are looking for is at index {middleIndex}. It was found in {counter} iterations";
                    //note that the search returns the first encounter if there are duplicates of the number we are looking for
                }

                if (inputArray[middleIndex] > number)
                {
                    highBoundryIndex = middleIndex - 1;
                }

                if (inputArray[middleIndex] < number)
                {
                    lowBoundryIndex = middleIndex + 1;
                }

                counter++;
            }
            return $"The number you are looking for does not exist in the given array. This was established in {counter} operations";
        }
    }
}
