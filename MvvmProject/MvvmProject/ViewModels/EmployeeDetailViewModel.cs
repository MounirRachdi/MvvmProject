using MvvmProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmProject.ViewModels
{ 
   public class EmployeeDetailViewModel : BaseViewModel
    { 
        public Employee employee { get; set; }
        public EmployeeDetailViewModel(Employee emp=null)
        {
            employee = emp;

        }
    }
}
