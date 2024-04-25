using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfaces
{
    public interface IVideoGames
    {
        Task<IEnumerable<T>> GetAllAsync<T>() where T: class;

        /// <summary>
        /// Support for pagination
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns>Entity data</returns>
        Task<IEnumerable<T>> GetAllAsync<T>(int pageSize, int pageNumber) where T: class;

        Task<T> FindByIdAsync<T>(int id) where T : class;

        Task AddAsync<T>(T entity) where T : class;

        Task RemoveAsync<T>(T entity) where T : class;

        Task UpdateAsync<T>(T entity) where T : class;

    }
}
