using MvvmProject.Models;
using MvvmProject.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEmployee : ContentPage
    {
       
        public Employee emp { get; set; }
        public AddEmployee()
        {
            InitializeComponent();
            
            emp = new Employee
            {
                Name = "Ammar",
                Department = "Busness Intillegence."
            };
        
            BindingContext = this;
        }
      async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddEmployee",emp );
           // await Navigation.PopToRootAsync();

            await Navigation.PopModalAsync();
            //await Navigation.PushModalAsync(new DetailsPage());
        }
    }
}