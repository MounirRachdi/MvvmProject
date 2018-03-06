using MvvmProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmProject.Services
{
    public interface IQueryable<out T> : IEnumerable<T>, IEnumerable, IQueryable
    {

    }
}
