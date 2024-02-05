using System;
using System.Collections.Generic;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Service
{
    public class ArrayHandlerService : IArrayHandler
    {
        // UNIQUE ID FOR EVERY REQUEST
        static int idCounter = 0;
        public async Task<Output> Deduplicate(Int64[] data)
        {
            HashSet<Int64> uniqueSet1 = new HashSet<Int64>();
            HashSet<Int64> uniqueSet2 = new HashSet<Int64>();
            int indeks = 0, counter = 0;
            // GET THE LENGHT OF THE NEW ARRAY, BY COUNTING THE UNIQUE VALUES
            foreach (Int64 element in data)
            {
                if (uniqueSet1.Add(element))
                {
                    ++counter;
                }
            }
            // CREATE NEW ARRAY WITH THE UNIQUE VALUES
            Int64[] result = new Int64[counter];
            foreach (Int64 element in data)
            {
                if (uniqueSet2.Add(element))
                {
                    result[indeks++] = element;
                }
            }

            return new Output { Id = idCounter++, Operation = "deduplication", Data = result };
        }

        public async Task<OutputMap> GetPairs(long[] data)
        {
            Dictionary<Int64, Int64> map = new Dictionary<Int64, Int64>();
            int counter;
            // O(n^2)
            for (int i = 0; i < data.Length; i++) {
                counter = 0;
                for (int j = 0; j < data.Length; j++) {
                    // CHECK IF PAIR
                    if (data[i] == data[j])
                        counter++;
                }
                // GROUP THE PAIRS
                if (counter != 0)
                    map[data[i]] = counter;
            }

            return new OutputMap { Id = idCounter++, Operation = "getPairs", Map = map };
        }
    }
}
