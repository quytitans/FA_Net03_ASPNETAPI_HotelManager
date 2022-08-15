using System.Linq.Expressions;
using MagicVilla2_VillaAPI.Models;

namespace MagicVilla2_VillaAPI.Repository.IRepository
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa entity);
    }
}
