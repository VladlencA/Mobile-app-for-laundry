using Laundry.Models;
using Laundry.Services;
using Laundry.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Laundry.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private string mail_user_;

        private string password_user_;
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }
        public string Mail_user_
        {
            get => mail_user_;
            set => SetProperty(ref mail_user_, value);
        }
        public string Password_user_
        {
            get => password_user_;
            set => SetProperty(ref password_user_, value);
        }
        
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLogin);
            RegisterCommand = new Command(OnRegisterClicked);
        }

        private async void OnLogin()
        {
            IsBusy = true;
            var users = await DB.GetUser();
            IEnumerator<User> usersEnumerator = users.GetEnumerator();
            while (usersEnumerator.MoveNext())
            {
                User item = usersEnumerator.Current;
                if (item.Mail_user == mail_user_ & item.Password_user == password_user_)
                {
                    await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
                    return;
                }  
            }
            await Shell.Current.DisplayAlert("Неправильный e-mail или пароль", "Проверьте правильность введенных данных", "Ok");
            IsBusy = false;
        }

        private async void OnRegisterClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }

    }

}

