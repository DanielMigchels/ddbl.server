using ddbl.identityservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ddbl.identityservice.IdentityRepository
{
    public class MockIdentity : iIdentity<User>
    {
        private List<User> _users;

        public MockIdentity()
        {
            _users = new List<User>()
            {
                new User()
                {
                    Id = Guid.Parse("eee390db-57af-41a1-958f-eee1761e105a"),
                    UserName = "dhalls0",
                    DisplayName = "aboschmann0",
                    Password = "VpHZVG5L",
                    Email = "sjorn0@craigslist.org"
                },
                new User()
                {
                    Id = Guid.Parse("e44d894d-b2a2-4046-9870-dbd4cce0f07c"),
                    UserName = "goheaney1",
                    DisplayName = "fgully1",
                    Password = "CmHwn6y",
                    Email = "mreason1@123-reg.co.uk"
                },
                new User()
                {
                    Id = Guid.Parse("840d1158-c8ae-44b0-a75b-c1e4e0fe7bf7"),
                    UserName = "sduesbury2",
                    DisplayName = "kgummery2",
                    Password = "BiLD4gOlnrUI",
                    Email = "tsurman2@51.la"
                },
                new User()
                {
                    Id = Guid.Parse("5ab2260f-7a06-4b7e-84a8-2b8a251c2a2f"),
                    UserName = "skiebes3",
                    DisplayName = "dpapa3",
                    Password = "11kWgt8G6",
                    Email = "cbursell3@nps.gov"
                },
                new User()
                {
                    Id = Guid.Parse("0b1ff4ce-88bf-4de8-9727-08f6054aa2fb"),
                    UserName = "jfounds4",
                    DisplayName = "ddeverick4",
                    Password = "8qQGnSDG",
                    Email = "fhallowes4@time.com"
                },
                new User()
                {
                    Id = Guid.Parse("0b1ff4ce-88bf-4de8-9727-08f6dd4aa2fb"),
                    UserName = "realdonaldtrump",
                    DisplayName = "Donald Trump",
                    Password = "usa",
                    Email = "donaldtrump@usa.gov"
                },
                new User()
                {
                    Id = Guid.Parse("0b1ff4ce-88bf-4de8-9727-08f6dd4aa2fb"),
                    UserName = "fdebijl",
                    DisplayName = "Floris de Bijl",
                    Password = "fdebijl",
                    Email = "f.bijl@student.fontys.nl"
                }
            };
        }


        public bool Authorizate(string userName, string password)
        {
            return _users.Any(x => x.UserName == userName && x.Password == password);
        }

        public User Create(User user)
        {
            user.Id = Guid.NewGuid();
            _users.Add(user);
            return user;
        }

        public User GetUser(Guid id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUser(string userName)
        {
            return _users.FirstOrDefault(x => x.UserName == userName);
        }

        public bool Update(User user)
        {
            var listUser = _users.FirstOrDefault(x => x.Id == user.Id);

            if (listUser == null) { return false; }

            listUser.UserName = user.UserName;
            listUser.DisplayName = user.DisplayName;
            listUser.Password = user.Password;
            listUser.Email = user.Email;
            return true;
        }
    }
}
