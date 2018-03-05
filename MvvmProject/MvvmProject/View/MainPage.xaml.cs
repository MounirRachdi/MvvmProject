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
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            //MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

       private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddEmployee());

        }
        private void Button_Clicked2(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DetailsPage());
        }
    }
}