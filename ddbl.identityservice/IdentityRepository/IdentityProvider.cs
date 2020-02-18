using ddbl.identityservice.Models;
using ddbl.identityservice.IdentityRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ddbl.identityservice.IdentityRepository
{
    public class IdentityProvider
    {
        public static iIdentity<User> _provider = new MockIdentity();

        public static bool Authorizate(string userName, string password)
        {
            return _provider.Authorizate(userName, password);
        }

        public static User Create(User user)
        {
            return _provider.Create(user);
        }

        public static User GetUser(Guid id)
        {
            return _provider.GetUser(id);
        }

        public static User GetUser(string userName)
        {
            return _provider.GetUser(userName);
        }

        public static bool Update(User user)
        {
            return _provider.Update(user);
        }
    }
}
