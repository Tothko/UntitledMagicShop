using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return context.Users.Include(u => u.Purchases).Where(u => u.ID == Id).ToList().ElementAt(0);
        }


        public IEnumerable<User> ReadAll()
        {
            return context.Users.Include(u => u.Purchases);
        }

        public User updateUser(User UserToUpdate)
        {
            if (context.Items.Find(UserToUpdate) == null)
            {
                return null;
            }
            context.Entry(UserToUpdate).CurrentValues.SetValues(UserToUpdate);

            return UserToUpdate;
        }

        public User loginUser(string newName, string newPass)
        {
            User myUser = context.Users.FirstOrDefault(user => user.Email == newName && user.Password == newPass);
            return myUser;
        }

        public List<Purchase> GetPurchasesOfUser(User User)
        {
            List<Purchase> UserPurchases = context.Users.Find(User).Purchases;
            return UserPurchases;
        }
    }
}
