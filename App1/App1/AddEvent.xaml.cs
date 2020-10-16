using App1.DogInfo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEvent : ContentPage
    {
        public AddEvent()
        {
            InitializeComponent();
        }

        private void EventSubmit_Clicked(object sender, EventArgs e)
        {
            EventInfoModel eventInfo = new EventInfoModel()
            {
                Date = eventDate.Text,
                EventName = eventName.Text,
                StartTime = startTime.Text,
                EndTime = endTime.Text,
                NumberOfSleds = numberOfSleds.Text,
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<EventInfoModel>();
                int rowsAdded = conn.Insert(eventInfo);
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<DogInfo1>();
                var dogInfo = conn.Table<DogInfo1>().ToList();
                dogInfoListView.ItemsSource = dogInfo;
            }
        }
    }
}