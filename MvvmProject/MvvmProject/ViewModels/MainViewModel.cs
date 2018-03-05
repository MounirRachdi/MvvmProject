using MvvmProject.Models;
using MvvmProject.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MvvmProject.ViewModels
{
   public class MainViewModel : INotifyPropertyChanged
    {
        private List<Employee> _employees;

        public List<Employee> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged();


            }
        }

        public MainViewModel()
        {
            var employeeServices = new DataEmployee();
           // Employees = employeeServices.GetEmployees();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
