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
using SQLite;

namespace MvvmProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEmployee : ContentPage
    {
        //private SQLiteConnection conn;
       // public Employee employee;
        public Employee emp { get; set; }
        public AddEmployee()
        {
            InitializeComponent();
            
            emp = new Employee
            { Id="5",
                Name = "Ahmed",
                Department = "Busness Intillegence."
            };
            //conn = DependencyService.Get<ISQLite>().GetConnection();
            //conn.CreateTable<Employee>();
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