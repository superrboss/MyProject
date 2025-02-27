using First.Core.DTO;
using First.Core.Interfaces;
using First.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first.EF.Services
{
    public interface IUserServices
    {
        User AddUser (UserDto user);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int Id);
        User EditUser(EditUserDto user);
        User DeleteUser(int Id);
        string login(string Email, string Password);
    }
}
