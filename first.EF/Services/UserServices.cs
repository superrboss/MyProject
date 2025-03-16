﻿using AutoMapper;
using first.EF.classes;
using First.Core.DTO;
using First.Core.Interfaces;
using First.Core.IUnitOfWork;
using First.Core.JwtMapper;
using First.Core.Models;
using First.ServicesUser;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace first.EF.Services
{
    public class UserServices : IUserServices
    {
        //private readonly IBaseRepo<User> _Users;
        private readonly IUnitOfWork _UniteOfwork;

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IOptions<JwtMap> _jwt;
        public UserServices(AppDbContext context, IMapper mapper, IOptions<JwtMap> jwt, IUnitOfWork UniteOfwork)
        {
            _context = context;
            //_Users = new BaseRepo<User>(_context);
            _UniteOfwork = UniteOfwork;
            _mapper = mapper;
            _jwt = jwt;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _UniteOfwork.Users.GetAll();
        }
        public User GetUserById(int Id)
        {
            if (_UniteOfwork.Users.GetById(Id) == null)
                return null;
            return _UniteOfwork.Users.GetById(Id);
        }
        public User AddUser(UserDto NewUser)
        {
            User useradd = new User();
            var AddedUser = _mapper.Map(NewUser, useradd);
            //var AddedUser = _mapper.Map<User>(NewUser);

            AddedUser.Password = Hashpassword(NewUser.Password);

            _UniteOfwork.Users.Add(AddedUser);
            return AddedUser;
        }
        public User EditUser(EditUserDto updatedUser)
        {
            var oldUser = _UniteOfwork.Users.GetById(updatedUser.Id);
            if (oldUser == null)
                return null;

            _mapper.Map(updatedUser, oldUser);
            oldUser.Password = Hashpassword(updatedUser.Password);

            _UniteOfwork.Users.Edit(oldUser);
            return oldUser;
        }
        public User DeleteUser(int Id)
        {
            var oldUser = _UniteOfwork.Users.GetById(Id);
            if (oldUser == null)
                return null;

            _UniteOfwork.Users.Delete(oldUser);
            return oldUser;
        }
        public string login(string Email, string Password)
        {
            User User = new User();
            var ServicesForToken = new TokenServices(_jwt);

            User = _UniteOfwork.Users.Find(u => u.Email == Email && u.Password == Hashpassword(Password));
            if (User != null)
                ServicesForToken.GenerateToken(User);
            else
                return null;
            var token = ServicesForToken.GenerateToken(User);
            
            return new JwtSecurityTokenHandler().WriteToken(token) ;
        }
        public string Hashpassword(string password)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password))
                );
        }
       
    }
}