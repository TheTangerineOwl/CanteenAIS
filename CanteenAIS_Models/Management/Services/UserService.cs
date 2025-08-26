using CanteenAIS_DB;
using CanteenAIS_DB.AppAuth.Entities;
using System;
using System.Collections.Generic;

namespace CanteenAIS_Models.Management.Services
{
    public class UserService
    {
        private readonly IEncryptor<string, string> Encryptor;

        public UserEntity CurrentUser {
            get => DBContext.GetInstance().CurrentUser;
            set { DBContext.GetInstance().CurrentUser = value; }
        }
        public BasicSimpleCRUD<UserEntity> Context { get => DBContext.GetInstance().Users; }

        public UserService(IEncryptor<string, string> encryptor)
        {
            Encryptor = encryptor;
        }

        public bool Login<TUser>(string login, string password)
            where TUser : UserEntity, new()
        {
            IList<TUser> users = Context.Read<TUser>();
            foreach (TUser user in users)
            {
                //string encryptedpass = Encryptor.Encrypt(password);
                if (user.Login == login && user.Password == Encryptor.Encrypt(password))
                {
                    CurrentUser = user;
                    return true;
                }
            }

            return false;
        }

        public bool Registration<TUser>(string login, string password)
            where TUser : UserEntity, new()
        {
            IList<TUser> users = Context.Read<TUser>();
            foreach (TUser user in users)
            {
                if (user.Login == login)
                    return false;
            }
            TUser info = new TUser
            {
                Login = login,
                Password = Encryptor.Encrypt(password)
            };
            Context.Create(new User(info));
            return true;
        }

        public void ChangePassword(string oldPassword, string newPassword)
        {
            if (Encryptor.Encrypt(oldPassword) == CurrentUser.Password)
            {
                CurrentUser.Password = Encryptor.Encrypt(newPassword);
                Context.Update(CurrentUser);
            }
            else
            {
                throw new ArgumentException("Неверный пароль");
            }

        }
    }
}
