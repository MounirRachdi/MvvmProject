using MvvmProject.Models;
using MvvmProject.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
//using System.Data.Entity;


namespace MvvmProject.ViewModels
{
    public class EmployeeDB 
    {
        private SQLiteConnection sqlconnection;
        public EmployeeDB()
        {
            sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            sqlconnection.CreateTable<Employee>();
        }
        public IEnumerable<Employee> GetEmplouyees()
        {
            IEnumerable<Employee> list = sqlconnection.Table<Employee>().Where(d => d.Department.StartsWith("m")).ToList();
            return list;
        }

        //Get specific student  
        public Employee GetStudent(string id)
        {
            return sqlconnection.Table<Employee>().FirstOrDefault(t => t.Id == id);
        }

        //Delete specific student  
        public void DeleteStudent(string id)
        {
            sqlconnection.Delete<Employee>(id);
        }

        //Add new student to DB  
        public void AddStusent(Employee employee)
        {
            sqlconnection.Insert(employee);
        }
    }
}
