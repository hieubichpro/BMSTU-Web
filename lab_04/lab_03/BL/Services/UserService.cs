﻿using lab_03.BL.Exceptions;
using lab_03.BL.IRepositories;
using lab_03.BL.Models;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Xml.Linq;

namespace lab_03.BL.Services
{
    public class UserService
    {
        private IUserRepository _userRepository;
        private ILogger<UserService> logger;
        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            this.logger = logger;
        }
        public User SignIn(User u)
        {
            logger.LogInformation("login started");
            User user = _userRepository.readByLogin(u.Login);
            if (!user.checkPassword(u.Password))
            {
                logger.LogError("password not correct");            
                throw new UserNotMatchPasswordException();
            }
            logger.LogInformation("login success");
            return user;
        }
        public void SignUp(User user)
        {
            logger.LogInformation("register started");
            _userRepository.create(user);
            logger.LogInformation("register success");
        }
        public void DeleteUser(int id)
        {
            logger.LogInformation("delete started");
            _userRepository.delete(id);
            logger.LogInformation("delete ended");
        }
        public List<User> GetAll()
        {
            logger.LogInformation("read all users started");
            return _userRepository.readAll();
        }
        public User GetById(int id)
        {
            logger.LogInformation("started read user by id");
            return _userRepository.readById(id);
        }
        public void UpdateUser(User user)
        {
            logger.LogInformation("update user started");
            _userRepository.update(user);
            logger.LogInformation("update user ended");
        }
        public void ChangePassword(User u)
        {
            logger.LogInformation("change password started");
            var user = _userRepository.readByLogin(u.Login);
            if (user == null)
            {
                logger.LogInformation("user not found");
                throw new UserNotFoundException();
            }
            user.Password = u.Password;
            _userRepository.update(user);
            logger.LogInformation("change password ended");
        }
    }
}
