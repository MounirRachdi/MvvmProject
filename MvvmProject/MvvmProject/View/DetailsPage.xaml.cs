using MvvmProject.View;
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
        int index = 0;
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
        private void Edit_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var employee = button.BindingContext as Employee;
            var vm = BindingContext as DetailEmployee;
          
            Navigation.PushModalAsync(new NavigationPage(new EditEmployee(employee)));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Employees.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void listview1_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           
           var emp = e.Item as Employee;
           
            var vm = BindingContext as DetailEmployee;
            
            vm?.ShoworHiddenEmployee(emp);
        }

        private void listview1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        
        }
        
        private void Remove_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
          var employee=  button.BindingContext as Employee;
            var vm = BindingContext as DetailEmployee;
            vm?.RemoveCommand.Execute(employee);
           
        }
        private void Detail_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var employee = button.BindingContext as Employee;
            Navigation.PushModalAsync(new PopUpPage(new EmployeeDetailViewModel(employee)));

        }

      /*  private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            {
                //thats all you need to make a search  

                if (string.IsNullOrEmpty(e.NewTextValue))
                {
                    listview1.ItemsSource = ;
                }

                else
                {
                    listview1.ItemsSource = tempdata.Where(x => x.BagName.ToLower().Contains(e.NewTextValue.ToLower()));
                }
            }
        }
        */
    }
}