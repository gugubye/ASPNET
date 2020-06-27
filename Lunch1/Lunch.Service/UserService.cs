using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Lunch.Data;
using Lunch.DataAccess;

namespace Lunch.Service
{
    public class UserService
    {
        private readonly LunchContext _dbContext;

        public UserService(LunchContext dbContex)
        {
            _dbContext = dbContex;
        }

        public User Login(string name, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Name == name && x.Password == password);
            return user;
        }

        public bool ChangePassword(int userId, string oldPassword, string password)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);
                if (user == null || user.Password != oldPassword)
                    return false;
                user.Password = password;

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Register(string username, string password, string address, string phone, int roleId)
        {
            var user = new User()
            {
                Name = username,
                RoleId = roleId,
                Password = password,
                Address = address,
                Phone = phone,
                CreateTime = DateTime.Now
            };
            _dbContext.Users.Add(user);
            return _dbContext.SaveChanges() > 0;
        }

        public string Encrypt(string input)
        {
            var md5Hasher = MD5.Create();
            var data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
