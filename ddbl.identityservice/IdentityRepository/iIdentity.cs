using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ddbl.identityservice.IdentityRepository
{
    public interface iIdentity<T>
    {
        public bool Authorizate(string userName, string password);

        public T Create(T user);

        public bool Update(T user);

        public T GetUser(Guid id);

        public T GetUser(string userName);
    }
}
