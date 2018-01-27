using System;
using System.Collections.Generic;
using System.Text;
using WalletDomain.Domain;

namespace WalletDomain.Services
{
    public interface IUserService
    {
        bool Add(User user);
        User GetById(int id);
        bool Update(User user);
        bool DeleteById(int id);
    }
}
