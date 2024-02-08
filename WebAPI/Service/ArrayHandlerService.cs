using System;
using System.Collections.Generic;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Service
{
    public class ArrayHandlerService : IArrayHandler
    {
        public async Task<Output> Deduplicate(Int64[] data)
        {
            // O(n^2)
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
            /*
            int counter, uniqueCounter = 0;
            for (int i = 0; i < data.Length; i++) {
                counter = 0;
                for(int j = 0; j < data.Length; j++)
                {

                }
            }*/
            string id = DateTime.Now.Ticks.ToString() + Guid.NewGuid().ToString();
            return new Output { Id = id, Operation = "deduplication", Data = result };
        }

        public async Task<OutputMap> GetPairs(Int64[] data)
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
                if (counter >= 2)
                    map[data[i]] = counter;
            }

            // O(n) BUT RETURNS EVERY NUMBERS APPEARANCE, EVEN IF IT APPEARS 1 TIME
            /*
            for (int i = 0; i < data.Length; i++) {
                if (map.ContainsKey(data[i]))
                    map[data[i]]++;
                else
                    map[data[i]] = 1;
            }*/

            string id = DateTime.Now.Ticks.ToString() + Guid.NewGuid().ToString();
            return new OutputMap { Id =  id, Operation = "getPairs", Map = map };
        }
    }
}
