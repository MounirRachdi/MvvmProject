using MvvmProject.CustomFormElements;
using MvvmProject.Models;
using MvvmProject.ViewModels;
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
    public partial class PopUpPage : ModalPage
    {
        EmployeeDetailViewModel viewModel;
        public PopUpPage()//string img, string name, string departement)
        {
            InitializeComponent();
            /*image.Source = img;
            Name.Text = "Name: " + name;
            Departement.Text = "Department: " + departement;*/
            var emp = new Employee
            {
                Name = "Ahmed",
                Department= "Sales Departement.",
                ImageUrl="img.png"
                
            };

            viewModel = new EmployeeDetailViewModel(emp);
            BindingContext = viewModel;
        }

        public PopUpPage(EmployeeDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
            image.Source = viewModel.employee.ImageUrl;
            Name.Text = viewModel.employee.Name;
            Departement.Text = viewModel.employee.Department;
        }
    }
}