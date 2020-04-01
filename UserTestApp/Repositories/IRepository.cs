using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserTestApp.Models;

namespace UserTestApp.Repositories
{
    interface IRepository<T> : IDisposable
        where T : class
    {
        Task<IEnumerable<User>> GetList();
        Task<User> GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Delete(T item);
        void Save();
    }
}
