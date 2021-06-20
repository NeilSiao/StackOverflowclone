using System;
using System.Collections.Generic;
using StackOverflow.DomainModels;
using StackOverflow.ViewModels;
using StackOverflow.Repositories;
using AutoMapper;
using AutoMapper.Configuration;
namespace StackOverflow.ServiceLayers
{
    public interface IUserService
    {
        int InsertUser(RegisterViewModel uvm);
        void UpdateUserDetails(EditUserDetailsViewModel uvm);
        void UpdateUserPassword(EditUserPasswordViewModel uvm);
        void DeleteUser(int uid);
        List<UserViewModel> GetUsers();
        UserViewModel GetUsersByEmailAndPassword(string Email, string Password);
        UserViewModel GetUsersByEmail(string Email);
        UserViewModel GetUserByUserID(int UserID);
    }

    public class UserService:IUserService

    {
        readonly IUserRepository ur;

        public UserService()
        {
            ur = new UserRepository();
        }

        public UserViewModel GetUserByUserID(int i)
        {
            User u = ur.GetUserByUserID(i);
            UserViewModel nvm = null;
            if(u != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserViewModel >();
                    cfg.IgnoreUnmapped();
                });
                IMapper mapper = config.CreateMapper();
                nvm = mapper.Map<User, UserViewModel>(u);
            }
       
            return nvm;
        }
        public int InsertUser(RegisterViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RegisterViewModel, User>(); cfg.IgnoreUnmapped();
                });
            IMapper mapper = config.CreateMapper();
            User u = mapper.Map<RegisterViewModel, User>(uvm);
            u.PasswordHash = SHA256HashGenerator.GernerateHash(uvm.Password);
            ur.InsertUser(u);
            int uid = ur.GetLatestUserID();
            return uid;
        }

        public void UpdateUserDetails(EditUserDetailsViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserDetailsViewModel, User>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            User u = mapper.Map<EditUserDetailsViewModel, User>(uvm);
           
            ur.UpdateUserDetails(u);
        }
    
        public void UpdateUserPassword(EditUserPasswordViewModel nvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserPasswordViewModel, User>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            User u = mapper.Map<EditUserPasswordViewModel, User>(nvm);
            u.PasswordHash = SHA256HashGenerator.GernerateHash(nvm.Password);
            ur.UpdateUserPassword(u);
        }

        public void DeleteUser(int uid)
        {
            ur.DeleteUser(uid);
        }

        public List<UserViewModel> GetUsers()
        {
            List<User> u = ur.GetUsers();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            List<UserViewModel> uvm = mapper.Map<List<UserViewModel>>(u);
            return uvm;
        }
        public UserViewModel GetUsersByEmailAndPassword(string Email, string Password)
        {
            User u = ur.GetUsersByEmailAndPassword(Email, SHA256HashGenerator.GernerateHash(Password));
            UserViewModel uvm = null;
            if(u != null)
            {
                
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            uvm = mapper.Map<UserViewModel>(u);
            }                

            return uvm;
        }

        public UserViewModel GetUsersByEmail(string Email)
        {
            User u = ur.GetUsersByEmail(Email);
            UserViewModel uvm = null;
            if (u != null)
            {

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserViewModel>();
                    cfg.IgnoreUnmapped();
                });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<UserViewModel>(u);
            }

            return uvm;
        }
    }
}
