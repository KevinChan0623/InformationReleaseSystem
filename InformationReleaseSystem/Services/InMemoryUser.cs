using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InformationReleaseSystem.Models;
using InformationReleaseSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InformationReleaseSystem.Services
{
    public class InMemoryUser : IUser<User>
    {
        private readonly DataBaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InMemoryUser(DataBaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public User CheckAccount(string name, string password)
        {
            var query = from u in _context.Users
                where u.Name == name && u.Password == password
                select u;

            if (query.ToList().Count <= 0)
            {
                return null;
            }
            else
            {
                return query.ToList()[0];
            }
        }

        public int GetIdByName(string name)
        {
            var query = from u in _context.Users
                where u.Name == name
                select u.Id;

            return query.ToList()[0];
        }

        public int GetPermissionByName(string name)
        {
            var query = from u in _context.Users
                where u.Name == name
                select u.Permission;

            return query.ToList()[0];
        }

        public bool IsNameExisted(string name)
        {
            var qury = from u in _context.Users
                where u.Name == name
                select u;

            if (qury.ToList().Count <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void SignUp(string name, string password, int permission)
        {
            User newUser = new User()
            {
                Name = name,
                Password = password,
                Permission = permission
            };

            _context.Entry<User>(newUser).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void ChangePassword(string password)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var user = _context.Users.FirstOrDefault(u => u.Id == session.GetInt32("UserId"));

            user.Password = password;

            _context.Entry<User>(user).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
