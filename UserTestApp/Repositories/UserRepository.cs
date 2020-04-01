using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserTestApp.Models;

namespace UserTestApp.Repositories
{
    public class UserRepository : IRepository<User>
    {

        private UserContext _db;

        public UserRepository(UserContext context)
        {
            this._db = context;
        }

        public async Task<IEnumerable<User>> GetList()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<List<User>> GetListWithRoles()
        {
            return await _db.Users.Include(u => u.Role).ToListAsync();

        }
        public async Task<User> GetById(int id)
        {
            return await _db.Users.FindAsync(id);

        }

        public void Create(User user)
        {
            _db.Users.Add(user);
            Save();
        }

        public void Update(User user)
        {
            _db.Users.Update(user);
            Save();
        }

        public void Delete(int id)
        {
            User user = _db.Users.ElementAtOrDefault(id);
            if (user != null)
                Delete(user);
        }
        public void Delete(User user)
        {
            if (user != null)
                _db.Users.Remove(user);
            Save();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }


}
