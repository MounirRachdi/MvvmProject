﻿using MvvmProject.View;
using MvvmProject.Models;
using MvvmProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MvvmProject.ViewModels;

namespace MvvmProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        DetailEmployee viewModel;
        public DetailsPage()
        {
            InitializeComponent();
           
           BindingContext = viewModel = new DetailEmployee();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Employee;
            if (item == null)
                return;

           await Navigation.PushModalAsync(new PopUpPage(new EmployeeDetailViewModel(item)));
             //new NavigationPage(new PopUpPage(new EmployeeDetailViewModel(item)));
            // Manually deselect item
            listview1.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new AddEmployee());
            await Navigation.PushModalAsync(new NavigationPage(new AddEmployee()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Employees.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void listview1_ItemTapped(object sender, ItemTappedEventArgs e)
        {
             /*var vm = BindingContext as MainListView;
             var emp = e.Item as Employee;
             vm.ShoworHiddenEmployees(emp);*/
           var emp = e.Item as Employee;
            var vm = BindingContext as DetailEmployee;
            
            vm?.ShoworHiddenEmployee(emp);
        }

        private void listview1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
        }
        private void Remove_Clicked(object sender, EventArgs e)
        {

        }

        /*private void EmployeeTapped(object sender, ItemTappedEventArgs e)
{
var empp = e.Item as Employee;
//DisplayAlert("Student Info", empp.ImageUrl + "\n Name:" + empp.Name + "\n Departement:" + empp.Department, "Ok");

Navigation.PushModalAsync(new PopUpPage(empp.ImageUrl, empp.Name, empp.Department));


}
private void OpenPopUp(object sender, EventArgs e)
{

// Navigation.PushModalAsync(new PopUpPage());
}*/

    }
}