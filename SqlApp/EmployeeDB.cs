using Microsoft.EntityFrameworkCore;
using MvvmProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlApp
{
    public class EmployeeDB : DbContext
    {
        public DbSet<Employee> employees { get; set; }
        private string _databasePath;
    }
}
