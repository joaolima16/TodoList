using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todolist.Models;

namespace todolist.Repository
{
    public interface IUser
    {
        public UserModel addUser(UserModel user);
        public Boolean LoginUser(UserModel user);
        public UserModel updateUser(int id, UserModel user);
        public Boolean deleteUser(int id);

    }
}