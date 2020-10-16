using App1.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }
        void AddDog_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Add_A__Dog());
        }
        void AddEvent_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddEvent());
        }
        void Stats_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new StatsView());
        }
        void EventTracker_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new EventTracker());
        }

         void Weather_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CurrentWeather());
        }
    }
}
