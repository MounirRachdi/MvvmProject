using MvvmProject.Models;
using MvvmProject.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MvvmProject.ViewModels 
{
   public class DetailEmployee : BaseViewModel, INotifyPropertyChanged 
    {
        private Employee OldEmp;
        public ObservableCollection<Employee> Employees { get; set; }
        public Command LoadItemsCommand { get; set; }

        public DetailEmployee()
        {
            //Title = "Browse";
            Employees = new ObservableCollection<Employee>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<AddEmployee, Employee>(this, "AddEmployee", async (obj, item) =>
            {
                var _item = item as Employee;
                Employees.Add(_item);
                await DataStore.AddItemAsync(_item);
            });

        }
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Employees.Clear();
                var employees = await DataStore.GetItemsAsync(true);
                foreach (var item in employees)
                {
                    Employees.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        /*public void HideOrShowEmployee(Employee emp)
        {
            emp.IsVisible = true;
            UpdateEmployee(emp);
        }

        private void UpdateEmployee(Employee emp)
        {
            var index = Employees.IndexOf(emp);
            Employees.Remove(emp);
            Employees.Insert(index, emp);
        }*/
        public void ShoworHiddenEmployee(Employee emp)
        {
            if (OldEmp == emp)
            {
                emp.IsVisible = !emp.IsVisible;
                UpDateEmployee(emp);
            }
            else
            {
                if (OldEmp != null)
                {
                    OldEmp.IsVisible = false;
                    UpDateEmployee(OldEmp);

                }
                emp.IsVisible = true;
                UpDateEmployee(emp);
            }
            OldEmp = emp;
        }

        private void UpDateEmployee(Employee employee)
        {

            var Index = Employees.IndexOf(employee);
            
           // DataStore.DeleteItemAsync(employee);
            Employees.Remove(employee);
            Employees.Insert(Index, employee);
           // DataStore.AddItemAsync(employee);

        }
        public Command<Employee> RemoveCommand
        {
            get
            {

                return new Command<Employee>((emp) =>
                {
                    Employees.Remove(emp);

                });

            }

        }
    }
}
