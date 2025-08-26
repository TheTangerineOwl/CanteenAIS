using Entities = CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_Models;
using CanteenAIS_Models.Management.Services;
using System;
using System.Windows.Input;

namespace CanteenAIS_ViewModel.ManagementViewModels.User
{
    public class RegistrationVM : PropChanged
    {
        private UserService service;
        private string name;
        private string password;
        private string repeatedPassword;

        public Action OnSuccessRegistration;
        public Action OnCancel;

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

        public string RepeatedPassword
        {
            get { return repeatedPassword; }
            set { Set<string>(ref repeatedPassword, value); }
        }

        public RegistrationVM()
        {
            service = new UserService(new Encryptor());
            name = string.Empty;
            password = string.Empty;
            repeatedPassword = string.Empty;
        }

        public ICommand ClickCancel
        {
            get
            {
                return new Command((obj) =>
                {
                    OnCancel?.Invoke();
                    Name = string.Empty;
                    Password = string.Empty;
                    RepeatedPassword = string.Empty;
                });
            }
        }

        public ICommand ClickRegistrate
        {
            get
            {
                return new Command((obj) =>
                {
                    if (Password == null || Password == string.Empty)
                        throw new ArgumentException("Поле \"Пароль\" не заполнено");
                    else if (RepeatedPassword == null || RepeatedPassword == string.Empty)
                        throw new ArgumentException("Поле \"Повторите пароль\" не заполнено");
                    else if (Password != RepeatedPassword)
                        throw new ArgumentException("Поля \"Пароль\" и \"Повторите пароль\" не совпадают");
                    if (service.Registration<Entities.User>(Name, Password))
                        OnSuccessRegistration?.Invoke();
                    else
                        throw new ArgumentException("Пользователь с таким именем уже зарегистрирован");
                });
            }
        }
    }
}
