using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbal.Models;
using mbal.Repository;

namespace mbal.Service
{
    public class UserService
    {
        private UserContext context;
        private readonly UserRepository _userRepository;

        public UserService(UserContext context)
        {
            this.context = context;
            this._userRepository = new UserRepository(context);
        }
    }
}
