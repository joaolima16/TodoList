using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using todolist.Context;
using todolist.Models;

namespace todolist.Repository
{
    public class UserActions : IUser
    {
        private DataContext _DataContext;
        public UserActions(DataContext Data) => _DataContext = Data;

        public UserModel addUser(UserModel user)
        {
            try
            {
                _DataContext.User.Add(user);
                _DataContext.SaveChanges();
                return user;
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public Boolean LoginUser(UserModel user)
        {
            try
            {
                if (_DataContext.User.Where(p => p.Username == user.Username && p.Password == user.Password).Any())
                {
                    return true;
                }
                return false;
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public UserModel updateUser(int id, UserModel user)
        {
            try
            {
                UserModel _user = _DataContext.User.Where(p => p.Id == id).FirstOrDefault();
                if (_user != null)
                {
                    _user.Username = user.Username;
                    _user.Password = user.Password;
                    _DataContext.SaveChanges();
                    return _user;
                }
                return null;

            }   
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}