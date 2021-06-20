using System;
using System.Collections.Generic;
using System.Linq;
using StackOverflow.DomainModels;
namespace StackOverflow.Repositories
{
    public interface IUserRepository
    {
        void InsertUser(User u);
        void UpdateUserDetails(User u);
        void UpdateUserPassword(User u);
        void DeleteUser(int uid);
        List<User> GetUsers();
        User GetUsersByEmailAndPassword(string Email, string Password);
        User GetUsersByEmail(string Email);
        User GetUserByUserID(int UserID);
        int GetLatestUserID();
    }
    public class UserRepository : IUserRepository
    {
        readonly StackOverflowDatabaseDbContext db;

        public UserRepository()
        {
            db = new StackOverflowDatabaseDbContext();
        }

        public void InsertUser(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();
        }
        public void DeleteUser(int uid)
        {
            User us = db.Users.Where(temp => temp.UserID == uid)
                .FirstOrDefault();
            if(us != null)
            {
                db.Users.Remove(us);
                db.SaveChanges();
            }
                }
        public void UpdateUserDetails(User u)
        {
            User us = db.Users.Where(temp => temp.UserID == u.UserID).FirstOrDefault();
            if(us != null)
            {
                us.Name = u.Name;
                us.Mobile = u.Mobile;
                db.SaveChanges();
            }
        }

        public void UpdateUserPassword(User u)
        {
            User us = db.Users.Where(temp => temp.UserID == u.UserID).FirstOrDefault();
            if(us != null)
            {
                us.PasswordHash = u.PasswordHash;
                db.SaveChanges();
            }
        }

        public List<User> GetUsers()
        {
            List<User> us = db.Users.Where(temp => temp.isAdmin == false)
                .OrderBy(temp => temp.Name)
                .ToList();
            return us;
        }

        public User GetUsersByEmailAndPassword(string Email, string PasswordHash)
        {
            User us = db.Users.Where(temp => temp.Email == Email && temp.PasswordHash == PasswordHash)
                .FirstOrDefault();
            return us;
        }

       public User GetUsersByEmail(string Email)
        {
            User us = db.Users.Where(temp => temp.Email == Email ).FirstOrDefault();
            return us;
        }
        public User GetUserByUserID(int UserID)
        {
            User us = db.Users.Where(temp => temp.UserID == UserID)
                .FirstOrDefault();
            return us;
        }

        public int GetLatestUserID()
        {
            int uid  = db.Users.Select(temp => temp.UserID).Max();
            return uid;
        }
    }
}
