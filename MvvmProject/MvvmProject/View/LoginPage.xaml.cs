using MvvmProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}
        private void Button_OnClicked(object sender, EventArgs e)
        {

            User user = new User(Login.Text, Password.Text);
            if (user.CheckValidate())
            {

                Navigation.PushModalAsync(new MainPage());
            }
            else
            {

                DisplayAlert("Error", "Invalid Login, Try again", "Ok");
            }

        }
        private void Button_OnClicked2(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RegistrationPage());

        }
    }
}