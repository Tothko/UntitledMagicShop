using System;
using System.Collections.Generic;
using System.Text;
using UntitledMagicShop.Core.Entities;

namespace UntitledMagicShop.Core.Application_Services
{
    public interface IUserService
    {
        User authenticateUser(string name, string password);
        User CreateUser(User User);
        User ReadUserById(int ID);
        User DeleteUser(User User);
        User UpdateUser(User User);
        List<User> ReadAllUsers();

    }
}
