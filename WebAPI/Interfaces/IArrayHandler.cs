using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IArrayHandler
    {
        Task<Output> Deduplicate(Int64[] data);
    }
}
