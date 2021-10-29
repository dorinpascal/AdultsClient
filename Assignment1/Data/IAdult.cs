using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assignment1.Data
{
    public interface IAdult
    {
        Task<IList<Adult>> GetAdultAsync();
        Task AddAdultAsync(Adult adult);

        Task<int> getLastAdultId();
    }
}