using System;
using System.Windows.Input;
using Entities = CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_Models;
using CanteenAIS_Models.Management.Services;

namespace CanteenAIS_ViewModel.ManagementViewModels.User
{
    public class ChangePasswordVM : PropChanged
    {
        private string oldPassword = string.Empty;
        private string newPassword = string.Empty;
        private string repeatedPassword = string.Empty;

        public Action OnChange;
        public Action OnSuccessChangePassword;
        public Action OnCancel;
        public string OldPassword
        {
            get { return oldPassword; }
            set { Set<string>(ref oldPassword, value); }
        }

        public string NewPassword
        {
            get { return newPassword; }
            set { Set<string>(ref newPassword, value); }
        }

        public string RepeatedPassword
        {
            get { return repeatedPassword; }
            set { Set<string>(ref repeatedPassword, value); }
        }

        public void ClearFormInfo()
        {
            OldPassword = string.Empty;
            NewPassword = string.Empty;
            RepeatedPassword = string.Empty;
        }

        public ICommand ClickCancellation
        {
            get => new Command((obj) =>
                {
                    OnCancel?.Invoke();
                });
        }

        public ICommand ClickChange
        {
            get
            {
                return new Command((obj) =>
                {
                    OnChange?.Invoke();
                });
            }
        }

        public void ChangePassword()
        {
            if (OldPassword == null || OldPassword == string.Empty)
                throw new ArgumentException("Поле \"Прежний пароль\" не заполнено");
            else if (NewPassword == null || NewPassword == string.Empty)
                throw new ArgumentException("Поле \"Новый пароль\" не заполнено");
            else if (NewPassword != RepeatedPassword)
                throw new ArgumentException("Поля \"Прежний пароль\" и \"Новый пароль\"" +
                    " не совпадают");

            UserService changePassword = new UserService(new Encryptor());

            changePassword.ChangePassword(OldPassword, NewPassword);
            OnSuccessChangePassword?.Invoke();
            ClearFormInfo();
        }
    }
}
