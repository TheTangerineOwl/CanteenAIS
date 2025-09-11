using System;
using CanteenAIS_Models;
using CanteenAIS_Models.Management.Services;
using System.Windows.Input;
using Entities = CanteenAIS_DB.AppAuth.Entities;

namespace CanteenAIS_ViewModel.ManagementViewModels.User
{
    public class LoginVM : PropChanged
    {
        private string name = string.Empty;
        private string password = string.Empty;

        private string _inputInfo = string.Empty;
        public string InputInfo
        {
            get => _inputInfo;
            set
            {
                Set(ref _inputInfo, value);
            }
        }

        public Action OnCancel;
        public Action OnLogin;
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
            get => new Command((obj) =>
                {
                    OnCancel?.Invoke();
                });
        }

        public ICommand ClickLogin
        {
            get => new Command((obj) =>
                {
                    OnLogin?.Invoke();
                });
        }

        public void Login()
        {
            UserService login = new UserService(new Encryptor());

            if (login.Login<Entities.User>(Name, Password))
            {
                OnLoginSuccess?.Invoke();
                ClearLoginInfo();
            }
            else
                throw new ArgumentException("Ошибка входа: неверный логин или пароль");
        }

        public void ClearLoginInfo()
        {
            Name = string.Empty;
            Password = string.Empty;
        }
    }
}
