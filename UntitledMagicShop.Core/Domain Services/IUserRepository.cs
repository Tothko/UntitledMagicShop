using System;
using System.Collections.Generic;
using System.Text;
using UntitledMagicShop.Core.Entities;

namespace UntitledMagicShop.Core.Domain_Services
{
    public interface IUserRepository
    {
        User createUser(User newUser);
        User deleteUser(User UserToDelete);
        List<Purchase> GetPurchasesOfUser(User User);
        User getSingleUser(int Id);
        User loginUser(string newName, string newPass);
        IEnumerable<User> ReadAll();
        User updateUser(User UserToUpdate);
    }
}
