using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Globalization;
using System.Linq;

namespace App1.DogInfo
{
    public class DogInfo1 : INotifyPropertyChanged
    {

        public int Id { get; set; }
        public string DogName { get; set; }
        public string Age { get; set; }
        public string SledPosition { get; set; }
        public string WorksWell { get; set; }
        public string DoesntWorkWell { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class EventInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        //private EventInfo _Event;
        //public EventInfo Event
        //{
        //    set { _Event = value; OnPropertyChanged(); }
        //    get { return _Event; }
        //}
        public int Id { get; set;}
        private string _Date;
        public string Date {
            set { _Date = value; OnPropertyChanged(); }
            get { return _Date; }
        }
        private string _EventName;
        public string EventName
        {
            set { _EventName = value; OnPropertyChanged(); }
            get { return _EventName; }
        }
        private string _StartTime;
        public string StartTime
        {
            set { _StartTime = value; OnPropertyChanged(); }
            get { return _StartTime; }
        }
        private string _EndTime;
        public string EndTime
        {
            set { _EndTime = value; OnPropertyChanged(); }
            get { return _EndTime; }
        }
        private string _NumberOfSleds;
        public string NumberOfSleds
        {
            set { _NumberOfSleds = value; OnPropertyChanged(); }
            get { return _NumberOfSleds; }
        }
        //public Command EventInfoCommand { get; set; }
        //public EventInfo()
        //{
        //    EventInfoCommand = new Command(() => EventInfoShow());
        //}

    //    private void EventInfoShow()
    //    {
    //        EventInfo eventInfo = new EventInfo()
    //        {
    //            Date = Date,
    //            EventName = EventName,
    //            StartTime = StartTime,
    //            EndTime = EndTime,
    //            NumberOfSleds = NumberOfSleds
    //        };
    //    }
    }
    public class AllTrueMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || !targetType.IsAssignableFrom(typeof(bool)))
            {
                return false;
                // Alternatively, return BindableProperty.UnsetValue to use the binding FallbackValue
            }

            foreach (var value in values)
            {
                if (!(value is bool b))
                {
                    return false;
                    // Alternatively, return BindableProperty.UnsetValue to use the binding FallbackValue
                }
                else if (!b)
                {
                    return false;
                }
            }
            return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (!(value is bool b) || targetTypes.Any(t => !t.IsAssignableFrom(typeof(bool))))
            {
                // Return null to indicate conversion back is not possible
                return null;
            }

            if (b)
            {
                return targetTypes.Select(t => (object)true).ToArray();
            }
            else
            {
                // Can't convert back from false because of ambiguity
                return null;
            }
        }
    }
}
