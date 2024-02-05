using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IArrayHandler
    {
        // REMOVES DUPLICATES FROM THE ARRAY
        Task<Output> Deduplicate(Int64[] data);

        // FINDS PAIRS IN THE ARRAY AND GROUPS THEM
        Task<OutputMap> GetPairs(Int64[] data);
    }
}
