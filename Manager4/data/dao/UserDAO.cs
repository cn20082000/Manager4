using Manager4.data.entity;
using Manager4.data.model;
using Manager4.util;
using Manager4.util.enu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager4.data.dao
{
    public class UserDAO : DAO, IDisposable
    {
        public UserEntity Get(User us)
        {
            var users = from user
                        in db.Users
                        where user.Active == true && user.Id == us.Id
                        select user;
            return users.Single();
        }

        public UserEntity Login(string username, string password)
        {
            password = Security.Hash(password);
            var users = from user
                        in db.Users
                        where user.Active == true && user.Username == username && user.Password == password
                        select user;
            return users.Single();
        }

        public void ChangePassword(User u, string oldPassword, string newPassword)
        {
            oldPassword = Security.Hash(oldPassword);
            newPassword = Security.Hash(newPassword);
            UserEntity us = (from user
                             in db.Users
                             where user.Active == true && user.Id == u.Id && user.Password == oldPassword
                             select user).Single();

            us.Password = newPassword;

            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                db.Entry(us).Reload();
                throw;
            }
        }

        public UserEntity Create(string name, DateTime birthday, string address, string phoneNumber,
            string signature, string username, string password, RoleEnum role)
        {
            password = Security.Hash(password);
            UserEntity user = new UserEntity();
            user.Name = name;
            user.Birthday = birthday;
            user.Address = address;
            user.PhoneNumber = phoneNumber;
            user.Signature = signature;
            user.Username = username;
            user.Password = password;
            user.Role = role;
            user.Active = true;
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return user;
            }
            catch (Exception)
            {
                db.Users.Remove(user);
                throw;
            }
        }

        public List<UserEntity> GetAll()
        {
            var users = from user
                        in db.Users
                        where user.Active == true && user.Role != RoleEnum.ADMIN
                        select user;
            return users.ToList();
        }

        public UserEntity UpdateBasicInfo(User u, string name, DateTime birthday, string address, string phoneNumber,
            string signature, RoleEnum role)
        {
            UserEntity us = (from user
                             in db.Users
                             where user.Active == true && user.Id == u.Id
                             select user).Single();
            us.Name = name;
            us.Birthday = birthday;
            us.Address = address;
            us.PhoneNumber = phoneNumber;
            us.Signature = signature;
            us.Role = role;

            try
            {
                db.SaveChanges();
                return us;
            }
            catch (Exception)
            {
                db.Entry(us).Reload();
                throw;
            }
        }

        public UserEntity UpdateAccountInfo(User u, string username, string password)
        {
            password = Security.Hash(password);
            UserEntity us = (from user
                             in db.Users
                             where user.Active == true && user.Id == u.Id
                             select user).Single();
            us.Username = username;
            us.Password = password;

            try
            {
                db.SaveChanges();
                return us;
            }
            catch (Exception)
            {
                db.Entry(us).Reload();
                throw;
            }
        }

        public void Delete(User u)
        {
            UserEntity us = (from user
                             in db.Users
                             where user.Active == true && user.Id == u.Id
                             select user).Single();
            us.Active = false;

            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                db.Entry(us).Reload();
                throw;
            }
        }

        public void Dispose() { }
    }
}
