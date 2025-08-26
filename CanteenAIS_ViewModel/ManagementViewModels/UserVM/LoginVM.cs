using System;
using CanteenAIS_Models;
using CanteenAIS_Models.Management.Services;
using System.Windows.Input;
using Entities = CanteenAIS_DB.AppAuth.Entities;

namespace CanteenAIS_ViewModel.ManagementViewModels.User
{
    public class LoginVM : PropChanged
    {
        private string name;
        private string password;

        public Action OnLoginSuccess;
        public string Name
        {
            get { return name; }
            set { Set<string>(ref name, value); }
        }

        public string Password
        {
            get { return password; }
            set { Set<string>(ref password, value); }
        }

        public ICommand ClickCancellation
        {
            get
            {
                return new Command((obj) =>
                {
                    Name = string.Empty;
                    Password = string.Empty;
                });
            }
        }

        public ICommand ClickLogin
        {
            get
            {
                return new Command((obj) =>
                {
                    UserService login = new UserService(new Encryptor());

                    if (login.Login<Entities.User>(Name, Password))
                    {
                        OnLoginSuccess?.Invoke();
                        Name = string.Empty;
                        Password = string.Empty;
                    }
                    else
                        throw new ArgumentException("Ошибка входа: неверный логин или пароль");
                });
            }
        }
    }
}
