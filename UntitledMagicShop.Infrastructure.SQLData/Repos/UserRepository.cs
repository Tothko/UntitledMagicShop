using Microsoft.EntityFrameworkCore;
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

        public User createUser(User newUser)
        {
            context.Attach(newUser).State = EntityState.Added;
            context.SaveChanges();
            return newUser;
        }

        public User deleteUser(User UserToDelete)
        {

            context.Remove(context.Find<User>(UserToDelete));
            context.SaveChanges();
            return UserToDelete;


        }

        public User getSingleUser(int Id)
        {
            return context.Users.Find(Id);
        }

        public IEnumerable<User> ReadAll()
        {
            return context.Users;
        }

        public User updateUser(User UserToUpdate)
        {

            return UserToUpdate;
        }

        public User loginUser(string newName, string newPass)
        {
            throw new NotImplementedException();
        }
    }
}
