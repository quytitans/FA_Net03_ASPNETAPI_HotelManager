using System.Linq.Expressions;
using MagicVilla2_VillaAPI.Models;

namespace MagicVilla2_VillaAPI.Repository.IRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task<VillaNumber> UpdateAsync(VillaNumber entity);
    }
}
