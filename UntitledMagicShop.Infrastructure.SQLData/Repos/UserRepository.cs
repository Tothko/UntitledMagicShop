using System;
using System.Collections.Generic;
using System.Text;
using UntitledMagicShop.Core.Domain_Services;
using UntitledMagicShop.Core.Entities;

namespace UntitledMagicShop.Infrastructure.SQLData.Repos
{
    public class UserRepository : IUserRepository
    {
        readonly UntitledMagicShopAppContext context;

        public UserRepository(UntitledMagicShopAppContext ctx)
        {
            context = ctx;
        }
        public User loginUser(string newName, string newPass)
        {
            throw new NotImplementedException();
        }
    }
}
