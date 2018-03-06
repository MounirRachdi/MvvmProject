using MvvmProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditEmployee : ContentPage
	{
        DetailEmployee details = new DetailEmployee();
        Employee employee = new Employee(); 
       // DetailEmployee 
		public EditEmployee (Employee emp)
		{
			InitializeComponent ();
            Name.Text = emp.Name;
            Departement.Text = emp.Department;
            
		}
        async void Save_Clicked(object sender, EventArgs e)
        {
            employee.Name = Name.Text;
            employee.Department = Departement.Text;
            MessagingCenter.Send(this, "EditEmployee", employee);
            //await Navigation.PopToRootAsync();

   
            await Navigation.PopModalAsync();
            //await Navigation.PushModalAsync(new DetailsPage());
        }
    }
}