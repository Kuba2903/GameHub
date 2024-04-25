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
        IEnumerable<T> GetAll<T>() where T: class;

        T FindById<T>(int id) where T : class;

        void Add<T>(T entity) where T : class;

        void Remove<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

    }
}
