using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UntitledMagicShop.Core.Application_Services;
using UntitledMagicShop.Core.Domain_Services;
using UntitledMagicShop.Core.Entities;

namespace UntitledMagicShop.Core.Application_Services_Impl
{
    public class UserService : IUserService
    {
        private IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }
        public User authenticateUser(string name, string password)
        {
            //var newName = parseOutSpecialCharacters(name);
            //var newPass = parseOutSpecialCharacters(password);
            return _repo.loginUser(name, password);
        }

        public User CreateUser(User User)
        {
            return _repo.createUser(User);
        }

        public User DeleteUser(User User)
        {
            return _repo.deleteUser(User);
        }

        public List<User> ReadAllUsers()
        {
            return _repo.ReadAll().ToList();
        }

        public User ReadUserById(int ID)
        {
            return _repo.getSingleUser(ID);
        }

        public User UpdateUser(User User)
        {
            return _repo.updateUser(User);
        }

        private string parseOutSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }
    }
}
