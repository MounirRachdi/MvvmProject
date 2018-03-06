using MvvmProject.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

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
    }
}
