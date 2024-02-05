using System;
using System.Collections.Generic;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Service
{
    public class ArrayHandlerService : IArrayHandler
    {
        static int counter = 0;
        public async Task<Output> Deduplicate(Int64[] data)
        {
            HashSet<Int64> uniqueSet1 = new HashSet<Int64>();
            HashSet<Int64> uniqueSet2 = new HashSet<Int64>();
            int indeks = 0, counter = 0;
            foreach (Int64 element in data)
            {
                if (uniqueSet1.Add(element))
                {
                    ++counter;
                }
            }
            Int64[] result = new Int64[counter];
            foreach (Int64 element in data)
            {
                if (uniqueSet2.Add(element))
                {
                    result[indeks++] = element;
                }
            }

            return new Output { Id = counter++, Operation = "deduplication", Data = result };
        }

        public async Task<Dictionary<Int64, Int64>> GetPairs(long[] data)
        {
            //Dictionary<Int64, Int64> map = data.GroupBy(item => item).ToDictionary(group => group.Key, group => group.Count());
            Dictionary<Int64, Int64> map = new Dictionary<Int64, Int64>();
            int counter;
            for (int i = 0; i < data.Length; i++) {
                counter = 0;
                for (int j = 0; j < data.Length; j++) {
                    if (data[i] == data[j])
                        counter++;
                }
                if (counter != 0)
                    map[data[i]] = counter;
            }

            return map;
        }
    }
}
