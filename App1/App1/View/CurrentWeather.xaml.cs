using App1.Model;
using App1.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentWeather : ContentPage
    {
        public CurrentWeather()
        {
            InitializeComponent();
            //GetCoordinates();
            GetWeatherInfo();
        }

        private string Location /*{ get; set;}*/ = "Osseo";
        //public double Latitude { get; set; }
        //public double Longitude { get; set; }

        //private async void GetCoordinates()
        //{
        //    try
        //    {
        //        var request = new GeolocationRequest(GeolocationAccuracy.Best);
        //        var location = await Geolocation.GetLocationAsync(request);

        //        if(location != null)
        //        {
        //            Latitude = location.Latitude;
        //            Longitude = location.Longitude;
        //            Location = await GetCity(location);
                    
        //            GetWeatherInfo();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.StackTrace);
        //    }
        //}
        //private async Task<string> GetCity(Location location)
        //{
        //    var places = await Geocoding.GetPlacemarksAsync(location);
        //    var currentPlace = places?.FirstOrDefault();

        //    if (currentPlace != null)
        //        return $"{currentPlace.Locality},{currentPlace.CountryName}";
        //    return null;
        //}
        private async void GetWeatherInfo()
        {
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={Location}&appid=ef5a820969b28ba639efc75ac4f84af9&units=imperial";
            var result = await ApiCaller.Get(url);

            if (result.Successful)
            {
                try
                {
                    var weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(result.Response);
                    descriptionTxt.Text = weatherInfo.weather[0].description.ToUpper();
                    iconImg.Source = $"w{weatherInfo.weather[0].icon}";
                    cityTxt.Text = weatherInfo.name.ToUpper();
                    temperatureTxt.Text = weatherInfo.main.temp.ToString("0");
                    humidityTxt.Text = $"{weatherInfo.main.humidity}%";
                    pressureTxt.Text = $"{weatherInfo.main.pressure} hpa";
                    windTxt.Text = $"{weatherInfo.wind.speed} mph";
                    cloudinessTxt.Text = $"{weatherInfo.clouds.all}%";
                    
                    var dt = new DateTime().ToUniversalTime().AddSeconds(weatherInfo.dt);
                    dateTxt.Text = dt.ToString("dddd, MMM dd").ToUpper();

                    GetForecast();
                }
                catch(Exception ex)
                {
                    await DisplayAlert("Weather Info", ex.Message, "OK");
                }
            }
            else
            {
                await DisplayAlert("Weather Info", "No weather information found", "OK");
            }
        }

        private async void GetForecast()
        {
            var url = $"http://api.openweathermap.org/data/2.5/forecast?q={Location}&appid=ef5a820969b28ba639efc75ac4f84af9&units=imperial";
            var result = await ApiCaller.Get(url);

            if (result.Successful)
            {
                try
                {
                    var forecastInfo = JsonConvert.DeserializeObject<ForeCastInfo>(result.Response);
                    List<List> allList = new List<List>();
                    foreach(var list in forecastInfo.list)
                    {
                        var date = DateTime.Parse(list.dt_text);
                        if (date > DateTime.Now && date.Hour == 0 && date.Minute == 0 && date.Second == 0)
                            allList.Add(list);
                    }

                    dayOneTxt.Text = DateTime.Parse(allList[0].dt_text).ToString("dddd");
                    dateOneTxt.Text = DateTime.Parse(allList[0].dt_text).ToString("dd MMM");
                    iconOneImg.Source = $"w{allList[0].weather[0].icon}";
                    tempOneTxt.Text = allList[0].main.temp.ToString("0");

                    dayTwoTxt.Text = DateTime.Parse(allList[1].dt_text).ToString("dddd");
                    dateTwoTxt.Text = DateTime.Parse(allList[1].dt_text).ToString("dd MMM");
                    iconTwoImg.Source = $"w{allList[1].weather[0].icon}";
                    tempTwoTxt.Text = allList[1].main.temp.ToString("0");

                    dayThreeTxt.Text = DateTime.Parse(allList[2].dt_text).ToString("dddd");
                    dateThreeTxt.Text = DateTime.Parse(allList[2].dt_text).ToString("dd MMM");
                    iconThreeImg.Source = $"w{allList[2].weather[0].icon}";
                    tempThreeTxt.Text = allList[2].main.temp.ToString("0");

                    dayFourTxt.Text = DateTime.Parse(allList[3].dt_text).ToString("dddd");
                    dateFourTxt.Text = DateTime.Parse(allList[3].dt_text).ToString("dd MMM");
                    iconFourImg.Source = $"w{allList[3].weather[0].icon}";
                    tempFourTxt.Text = allList[3].main.temp.ToString("0");
                }
                catch(Exception ex)
                {
                    await DisplayAlert("Weather Info", ex.Message, "OK");
                }
            }
            else
            {
                await DisplayAlert("Weather Info", "No forecast infromation found", "OK");
            }
        }
    }
}