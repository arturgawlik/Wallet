using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WalletDomain.Services.InMemory
{
    public class UserService : IUserService
    {
        private IList<User> _userRepo;

        public UserService()
        {
            _userRepo = new List<User>();
        }

        public bool Add(User user)
        {
            if (user == null)
            {
                return false;
            }

            if(string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
            {
                return false;
            }

            if (_userRepo.Contains(user))
            {
                return false;
            }

            _userRepo.Add(user);

            return true;
        }

        public bool DeleteById(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            var users = from u in _userRepo
                       where u.Id == id
                       select u;

            if (users.Count() == 0 || users.Count() > 1)
            {
                return false;
            }

            _userRepo.Remove(users.FirstOrDefault());

            return true;
        }

        public User GetById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            var users = from u in _userRepo
                        where u.Id == id
                        select u;

            if (users.Count() == 0 || users.Count() > 1)
            {
                return null;
            }

            return users.FirstOrDefault();
        }

        public bool Update(User user)
        {
            if (user == null)
            {
                return false;
            }

            var users = from u in _userRepo
                          where u.Id == user.Id
                          select u;

            if (users.Count() == 0 || users.Count() > 1)
            {
                return false;
            }

            var updatedUser = users.FirstOrDefault();

            if (updatedUser == user)
            {
                return false;
            }

            _userRepo.Remove(updatedUser);
            _userRepo.Add(user);

            return true;
        }
    }
}
