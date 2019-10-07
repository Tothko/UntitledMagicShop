using System;
using System.Collections.Generic;
using System.Text;
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
          var newName =  parseOutSpecialCharacters(name);
          var newPass = parseOutSpecialCharacters(password);
            return _repo.loginUser(newName, newPass);
        }

        private string parseOutSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }
    }
}
