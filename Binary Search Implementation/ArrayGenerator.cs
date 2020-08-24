using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Binary_Search_Implementation
{
    public class ArrayGenerator
    {
        public ArrayGenerator(int min, int max)
        {
            this.Min = min;
            this.Max = max;
        }

        private int Min { get; }
        private int Max { get; }

        public HashSet<int> GenerateArray ()
        {
            var random = new Random();

            var collection = new HashSet<int>();

            while (collection.Count<100)
            {
                collection.Add(random.Next(Min, Max));
            }

            return collection;
        }     
    }
}
