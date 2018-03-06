using Microsoft.EntityFrameworkCore;
using MvvmProject.Models;
using System;

namespace SqlApp
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Employee> employees { get; set; }
        private string _databasePath;
    }
}
