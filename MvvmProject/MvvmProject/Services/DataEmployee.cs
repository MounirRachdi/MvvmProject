using MvvmProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmProject.Services
{
    public class DataEmployee : IDataStore<Employee>
    {
       List<Employee> employees;

        public DataEmployee()
        {
            employees = new List<Employee>();
            var mockItems = new List<Employee>
            {
                new Employee
                 {  Id="1",
                     Name = "Mounir",
                     Department = "IT",
                     ImageUrl = "user1.jpg",
                     IsVisible=false
                 },
                 new Employee
                 {    Id="2",
                     Name = "Mohamed",
                     Department = "marketing",
                     ImageUrl = "user2.png",
                     //IsVisible=false

                 },
                 new Employee
                 {    Id="3",
                     Name = "Ahmed",
                     Department = "sfax departement",
                     ImageUrl = "user3.jpg",
                     //IsVisible=false

                 },
                 new Employee
                 {   Id="4",
                     Name = "Asma",
                     Department = "management",
                     ImageUrl = "user4.jpg",
                     //IsVisible=false

                 },

             
        };

            foreach (var item in mockItems)
            {
                employees.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Employee item)
        {
            employees.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Employee item)
        {
            var _item = employees.Where((Employee arg) => arg.Id == item.Id).FirstOrDefault();
            employees.Remove(_item);
            employees.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Employee item)
        {
            var _item = employees.Where((Employee arg) => arg.Id == item.Id).FirstOrDefault();
            employees.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Employee> GetItemAsync(string id)
        {
            return await Task.FromResult(employees.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Employee>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(employees);
        }
        /*public List<Employee> GetEmployees()
         {
             var list = new List<Employee>
             {
                 new Employee
                 {
                     Name = "mounir",
                     Department = "IT",
                     ImageUrl = "user1.jpg",

                 },
                 new Employee
                 {
                     Name = "mounir",
                     Department = "marketing",
                     ImageUrl = "user2.png",

                 },
                 new Employee
                 {
                     Name = "mounir",
                     Department = "sfax departement",
                     ImageUrl = "user3.jpg",

                 },
                 new Employee
                 {
                     Name = "mounir",
                     Department = "management",
                     ImageUrl = "user4.jpg",


                 },

             };
             return list;


         }*/

    }
}
