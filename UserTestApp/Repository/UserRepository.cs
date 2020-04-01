using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserTestApp.Models;


namespace UserTestApp.Repository
{
    public class UserRepository:IRepository<User>
    {

        private UserContext _db;

        public UserRepository(UserContext context)
        {
            this._db = context;
        }

        public IEnumerable<User> GetList()
        {
            return _db.Users;
        }

        public Task<IEnumerable<User>> GetListWithRoles()
        {
            return null;
                _db.Users.ToList();
            //    Where(u => u.Role = _db.Roles.Find(u.RoleId)).ToListAsync();
        }
        public User GetById(int id)
        {
            return _db.Users.ElementAtOrDefault(id);
        }

        public void Create(User user)
        {
            _db.Users.ToList().Add(user);
        }

        public void Update(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
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
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
