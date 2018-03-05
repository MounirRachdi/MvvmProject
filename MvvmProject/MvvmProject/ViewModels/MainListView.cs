using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmProject.Models;
using System.Collections.ObjectModel;

namespace MvvmProject.ViewModels
{
    public class MainListView
    {
        private Employee OldEmp;
        public ObservableCollection<Employee> Employees { get; set; }
        public MainListView()
        {
            Employees = new ObservableCollection<Employee>
            {
                new Employee
                 {
                     Name = "mounir",
                     Department = "IT",
                     ImageUrl = "user1.jpg",
                     IsVisible=false
                 },
                 new Employee
                 {
                     Name = "mounir",
                     Department = "marketing",
                     ImageUrl = "user2.png",
                     IsVisible=false

                 },
                 new Employee
                 {
                     Name = "mounir",
                     Department = "sfax departement",
                     ImageUrl = "user3.jpg",
                     IsVisible=false

                 },
                 new Employee
                 {
                     Name = "mounir",
                     Department = "management",
                     ImageUrl = "user4.jpg",
                     IsVisible=false

                 },


            };
        }
        public void ShoworHiddenEmployees(Employee emp)
        {
            if (OldEmp == emp)
            {
                emp.IsVisible = !emp.IsVisible;
                UpDateEmployees(emp);
            }
            else
            {
                if (OldEmp != null)
                {
                    OldEmp.IsVisible = false;
                    UpDateEmployees(OldEmp);

                }
                emp.IsVisible = true;
                UpDateEmployees(emp);
            }
            OldEmp = emp;
        }

        private void UpDateEmployees(Employee employee)
        {

            var Index = Employees.IndexOf(employee);
           Employees.Remove(employee);
            Employees.Insert(Index, employee);

        }
    }
}
