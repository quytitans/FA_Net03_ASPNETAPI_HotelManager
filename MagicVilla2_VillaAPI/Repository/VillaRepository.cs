using System.Linq.Expressions;
using MagicVilla2_VillaAPI.Data;
using MagicVilla2_VillaAPI.Models;
using MagicVilla2_VillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla2_VillaAPI.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<Villa> UpdateAsync(Villa entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Villas.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}
