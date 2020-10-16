using App1.DogInfo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewStats : ContentPage 
    {
        public ViewStats()
        {
            InitializeComponent();

           
        }
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
        //    {
        //        conn.CreateTable<EventInfo>();
        //        var eventInfo = conn.Table<EventInfo>().ToList();
        //        eventInfoModel.ItemsSource = eventInfo;
        //    }
        //}
    }
}