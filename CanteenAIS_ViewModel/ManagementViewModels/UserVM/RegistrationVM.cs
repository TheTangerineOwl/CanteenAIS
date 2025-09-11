using Entities = CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_Models;
using CanteenAIS_Models.Management.Services;
using System;
using System.Windows.Input;

namespace CanteenAIS_ViewModel.ManagementViewModels.User
{
    public class RegistrationVM : PropChanged
    {
        private readonly UserService service;
        private string name = string.Empty;
        private string password = string.Empty;
        private string repeatedPassword = string.Empty;
        private string _inputInfo = string.Empty;
        public string InputInfo
        {
            get => _inputInfo;
            set
            {
                Set(ref _inputInfo, value);
            }
        }

        public Action OnRegistrate;
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
            ClearFields();
        }

        public void ClearFields()
        {
            Name = string.Empty;
            Password = string.Empty;
            RepeatedPassword = string.Empty;
        }

        public ICommand ClickCancel
        {
            get
            {
                return new Command((obj) =>
                {
                    OnCancel?.Invoke();
                    ClearFields();
                });
            }
        }

        public ICommand ClickRegistrate
        {
            get => new Command((obj) =>
                {
                    OnRegistrate?.Invoke();
                });
        }

        public void Registrate()
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
            ClearFields();
        }

    }
}
