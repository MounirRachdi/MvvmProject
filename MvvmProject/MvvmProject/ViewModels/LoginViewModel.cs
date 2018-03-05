using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmProject.ViewModels
{
   public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Login"));
            }
        }
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            //navigation = _navigation;
            SubmitCommand = new Command(OnSubmit);

        }

        public void OnSubmit()
        {

            if (_login != "admin" || password != "root")
            {
                DisplayInvalidLoginPrompt();
              
            }
            /*else
            {
                Navigation.PushModalAsync(new DetailPage());
            }*/

        }
    }
}
