using MvvmProject.Models;
using MvvmProject.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmProject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShowDataDB : ContentPage
	{
        private SQLiteConnection conn;

        public ShowDataDB ()
		{
            conn = DependencyService.Get<ISQLite>().GetConnection();
            InitializeComponent ();
            var data = (from stu in conn.Table<Employee>() select stu);
            DataList.ItemsSource = data;
        }
	}
}