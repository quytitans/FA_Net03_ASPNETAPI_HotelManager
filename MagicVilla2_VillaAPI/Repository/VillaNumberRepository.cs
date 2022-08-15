using System.Linq.Expressions;
using MagicVilla2_VillaAPI.Data;
using MagicVilla2_VillaAPI.Models;
using MagicVilla2_VillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla2_VillaAPI.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaNumberRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<VillaNumber> UpdateAsync(VillaNumber entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.VillaNumbers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}
