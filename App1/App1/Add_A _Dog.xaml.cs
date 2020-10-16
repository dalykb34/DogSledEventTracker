using App1.DogInfo;
using MySql.Data.MySqlClient;
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
    public partial class Add_A__Dog : ContentPage
    {
        public Add_A__Dog()
        {
            InitializeComponent();
        }
        void AddDog_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

         void AddDogSubmit_Clicked(object sender, EventArgs e)
        {
            DogInfo1 dogInfo = new DogInfo1()
            {
                DogName = dogName.Text,
                Age = dogAge.Text,
                SledPosition = SledPosition.Text,
                WorksWell = worksWell.Text,
                DoesntWorkWell = doesntWorkWell.Text,
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<DogInfo1>();
                int rowsAdded = conn.Insert(dogInfo);
            }
        }
        void SledPosition_Checked()
        {
            if(CheckLead.Checked == true)
            {
                CheckTeam.Checked = false;
                CheckWheel.Checked = false;
            }
            if(CheckTeam.Checked == true)
            {
                CheckLead.Checked = false;
                CheckWheel.Checked = false;
            }
            if(CheckWheel.Checked == true)
            {
                CheckTeam.Checked = false;
                CheckLead.Checked = false;
            }
        }
    }
}