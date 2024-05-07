using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Implementations
{
    public class VideoGamesService : IVideoGames
    {
        private readonly AppDbContext _appDbContext;

        public VideoGamesService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class =>
            await _appDbContext.Set<T>().AsNoTracking().ToListAsync();
        

        public async Task<IEnumerable<T>> GetAllAsync<T>(int pageSize, int pageNumber) where T : class
        {
            return await _appDbContext.Set<T>()
                .Skip((pageNumber-1) * pageSize)
                .Take(pageSize).ToListAsync();
        }

        public async Task<T> FindByIdAsync<T>(int id) where T : class =>
            await _appDbContext.Set<T>().FindAsync(id);

        public async Task AddAsync<T>(T entity) where T : class
        {
            await _appDbContext.Set<T>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            _appDbContext.Set<T>().Update(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync<T>(T entity) where T : class
        {
            _appDbContext.Set<T>().Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
