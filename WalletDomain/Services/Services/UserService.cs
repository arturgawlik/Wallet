using System;
using System.Collections.Generic;
using System.Text;
using WalletDomain.DB;
using WalletDomain.Domain;
using System.Linq;

namespace WalletDomain.Services.Services
{
    public class UserService : IUserService
    {
        private readonly WalletContext _context;
        public UserService(WalletContext context)
        {
            _context = context;
        }


        public bool Add(User user)
        {
            if (string.IsNullOrWhiteSpace(user?.Username) || string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
            {
                return false;
            }

            _context.Add(user);

            return true;
        }

        public bool DeleteById(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            _context.Users.Remove(user);

            return true;
        }

        public User GetById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool Update(User user)
        {
            if (user == null)
            {
                return false;
            }

            _context.Users.Update(user);

            return true;
        }
    }
}
