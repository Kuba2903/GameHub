using Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Implementations
{
    public class VideoGamesService : IVideoGames
    {
        public Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync<T>(int pageSize, int pageNumber) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> FindByIdAsync<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public Task AddAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
