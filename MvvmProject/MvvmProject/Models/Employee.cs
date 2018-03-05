using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmProject.Models
{
   public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
       // public byte[] Image { get; set; }
        public string ImageUrl { get; set; }
        public bool IsVisible { get; set; }
    }
}
