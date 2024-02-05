using System;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Service
{
    public class ArrayHandlerService : IArrayHandler
    {
        static int counter = 0;
        public async Task<Output> Deduplicate(Int64[] data)
        {
            HashSet<Int64> uniqueSet = new HashSet<Int64>();
            int indeks = 0, counter = 0;
            foreach (Int64 element in data)
            {
                if (uniqueSet.Add(element))
                {
                    ++counter;
                }
            }
            Int64[] result = new Int64[counter];
            foreach (Int64 element in data)
            {
                if (uniqueSet.Add(element))
                {
                    result[indeks++] = element;
                }
            }

            return new Output { Id = counter++, Operation = "deduplication", Data = result };
        }
    }
}
