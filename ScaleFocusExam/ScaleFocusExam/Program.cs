using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ScaleFocusExam
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> num = new List<int> { 4, 1, 2, 3, 4 };
            Console.WriteLine(Result.reductionCost(num));

            //            var list = new List<List<string>>
            //            {
            //                new List<string>(){ "owjevtkuyv", "58584272", "62930912" },
            //                new List<string>(){ "rpaqgbjxik", "9425650",  "96088250" },
            //                new List<string>(){ "dfbkasyqcn", "37469674", "46363902" },
            //                new List<string>(){ "vjrrisdfxe", "18666489", "88046739" },
            //            };

            ////            0       →   sortParameter = 2(name)
            ////            0       →   sortOrder = 1(descending)
            ////            1       →   itemsPerPage = 2
            ////            0       →   pageNumber = 0
            //            Console.WriteLine(string.Join(", ", fetchItemsToDisplay(list, 2, 1, 2, 0))); ;
        }

        /*
         * task 1 - implement algorithm that reduces an array of ints to a single int through Moves. 
         * On each Move you have to remove two elements from the array,sum them and add the sum to the end. 
         * Each Move has a cost = the sum of the 2 removed ints. 
         * The goal for the algorithm is to reduce the array to one item with the loswest possible cost.
         * 
         * Received 11/14 points due to performance issues. 
         * This can be fixed by obtaining the two lowest elements at each step with int[].Min instead of sorting.
         * It's also possible to fix with a custom sorting that takes advantage of the fact the array is almost perfectly sorted after the initial num.Sort() - only the last element may need to be moved.
         */
        public static class Result
        {

            /*
             * Complete the 'reductionCost' function below.
             *
             * The function is expected to return an INTEGER.
             * The function accepts INTEGER_ARRAY num as parameter.
             */

            public static int reductionCost(List<int> num)
            {
                var totalCost = 0;

                while (num.Count>=2)
                {
                    num.Sort();
                    var sum = num[0] + num[1];
                    totalCost += sum;

                    num.RemoveAt(0);
                    num.RemoveAt(0);
                    num.Add(sum);                   
                }

                return totalCost;
            }

        }

        /* task 2 - implement pagination algorithm. 
         * You have List<List<string>>. Each of the inner lists holds exactly 3 strings - Name of a product, relevance and popularity which are integers. 
         * The function recieves:
         * List<List<string>> (all items)
         * sortParameter which is 0-2 and tells us if we are sorting by Name, relevance or popularity.
         * sortOrder is 0(ascending) or 1(descending).   
         * itemsPerPage - how many items are there on each page
         * pageNumber - the page we want to display the information for. 
         * 
         * The function has to return the list of items displayed on the requested page. Received 14/14 on this one. 
         */
        public static List<string> fetchItemsToDisplay(List<List<string>> items, int sortParameter, int sortOrder, int itemsPerPage, int pageNumber)
        {
           var sortedList = new List<List<string>>();
            
            if (sortParameter==1 || sortParameter==2)
            {
                if (sortOrder == 0)
                {
                    sortedList = items.OrderBy(x => int.Parse(x[sortParameter])).ToList();
                }
                else
                {
                    sortedList = items.OrderByDescending(x => int.Parse(x[sortParameter])).ToList();
                }
            }
            else // if we sort by name we don't need to cast the string
            {
                if (sortOrder == 0)
                {
                    sortedList = items.OrderBy(x => x[sortParameter]).ToList();
                }
                else
                {
                    sortedList = items.OrderByDescending(x => x[sortParameter]).ToList();
                }
            }
            
            var startIndex = itemsPerPage*pageNumber;
            
            var result = new List<string>();
            var counter = 0;

            while (counter<itemsPerPage && startIndex<items.Count)
            {
                result.Add(sortedList[startIndex][0]);
                counter++;
                startIndex++;
            }
            result.Reverse();

            return result;
        }
    }
}
