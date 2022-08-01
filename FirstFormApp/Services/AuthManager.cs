using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FirstFormApp.Data;
using FirstFormApp.Models;

namespace FirstFormApp.Services
{
    public class AuthManager
    {
        AppDbContext context = new();

        public void Register(User user,string pass)
        {
            user.Password = HashPassword(pass);
            context.Users.Add(user);
            context.SaveChanges();
        }

        public string HashPassword(string password)
        {
            using HashAlgorithm hashAlgorithm = SHA256.Create();
            byte[] hashingData = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder sp = new StringBuilder();
            for (int i = 0; i < hashingData.Length; i++)
            {
                sp.Append(hashingData[i].ToString("x2"));
            }

            return sp.ToString();
        }
        
        public User Login(string email,string password)
        {
            var user = context.Users.FirstOrDefault(x=>x.Email == email);

            if (user == null)
                return null;

            if (user.Password != HashPassword(password))
                return null;

            return user;
        }
    }
}
