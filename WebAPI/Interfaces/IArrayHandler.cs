using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IArrayHandler
    {
        Task<Output> Deduplicate(Int64[] data);

        Task<Dictionary<Int64, Int64>> GetPairs(Int64[] data);
    }
}
