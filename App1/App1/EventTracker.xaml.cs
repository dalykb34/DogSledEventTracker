using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventTracker : ContentPage
    {
        Stopwatch stopwatch;
        Stopwatch stopwatch1;
        Stopwatch stopwatch2;
        Stopwatch stopwatch3;
        Stopwatch stopwatch4;
        public EventTracker()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            stopwatch1 = new Stopwatch();
            stopwatch2 = new Stopwatch();
            stopwatch3 = new Stopwatch();
            stopwatch4 = new Stopwatch();
            
            lblStopwatch.Text = "00:00:00.0000";
            lblStopwatch2.Text = "00:00:00.0000";
            lblStopwatch3.Text = "00:00:00.0000";
            lblStopwatch4.Text = "00:00:00.0000";
            lblStopwatch5.Text = "00:00:00.0000";
        }

        private void btn1Start_Clicked(object sender, EventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                 {
                     lblStopwatch.Text = stopwatch.Elapsed.ToString();
                     if (!stopwatch.IsRunning)
                     {
                         return false;
                     }

                     return true;
                 }
                 );
            }
        }
        private void btn1Stop_Clicked(object sender, EventArgs e)
        {
            btn1Start.Text = "Resume";
            stopwatch.Stop();
            //totalTime1.Text = stopwatch.Elapsed.ToString();
        }
        private void btn1Reset_Clicked(object sender, EventArgs e)
        {
            lblStopwatch.Text = "00:00:00.0000";
            btn1Start.Text = "Start";
            stopwatch.Restart();
        }

        private void btn2Start_Clicked(object sender, EventArgs e)
        {
            if (!stopwatch1.IsRunning)
            {
                stopwatch1.Start();
                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {
                    lblStopwatch2.Text = stopwatch1.Elapsed.ToString();
                    if (!stopwatch1.IsRunning)
                    {
                        return false;
                    }

                    return true;
                }
                 );
            }
        }
        private void btn2Stop_Clicked(object sender, EventArgs e)
        {
            btn2Start.Text = "Resume";
            stopwatch1.Stop();
        }
        private void btn2Reset_Clicked(object sender, EventArgs e)
        {
            lblStopwatch2.Text = "00:00:00.0000";
            btn2Start.Text = "Start";
            stopwatch1.Restart();
        }
        private void btn3Start_Clicked(object sender, EventArgs e)
        {
            if (!stopwatch2.IsRunning)
            {
                stopwatch2.Start();
                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {
                    lblStopwatch3.Text = stopwatch2.Elapsed.ToString();
                    if (!stopwatch2.IsRunning)
                    {
                        return false;
                    }

                    return true;
                }
                 );
            }
        }
        private void btn3Stop_Clicked(object sender, EventArgs e)
        {
            btn3Start.Text = "Resume";
            stopwatch2.Stop();
        }
        private void btn3Reset_Clicked(object sender, EventArgs e)
        {
            lblStopwatch3.Text = "00:00:00.0000";
            btn3Start.Text = "Start";
            stopwatch2.Restart();
        }
        private void btn4Start_Clicked(object sender, EventArgs e)
        {
            if (!stopwatch3.IsRunning)
            {
                stopwatch3.Start();
                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {
                    lblStopwatch4.Text = stopwatch3.Elapsed.ToString();
                    if (!stopwatch3.IsRunning)
                    {
                        return false;
                    }

                    return true;
                }
                 );
            }
        }
        private void btn4Stop_Clicked(object sender, EventArgs e)
        {
            btn4Start.Text = "Resume";
            stopwatch3.Stop();
        }
        private void btn4Reset_Clicked(object sender, EventArgs e)
        {
            lblStopwatch4.Text = "00:00:00.0000";
            btn4Start.Text = "Start";
            stopwatch3.Restart();
        }
        private void btn5Start_Clicked(object sender, EventArgs e)
        {
            if (!stopwatch4.IsRunning)
            {
                stopwatch4.Start();
                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {
                    lblStopwatch5.Text = stopwatch4.Elapsed.ToString();
                    if (!stopwatch4.IsRunning)
                    {
                        return false;
                    }

                    return true;
                }
                 );
            }
        }
        private void btn5Stop_Clicked(object sender, EventArgs e)
        {
            btn5Start.Text = "Resume";
            stopwatch4.Stop();
        }
        private void btn5Reset_Clicked(object sender, EventArgs e)
        {
            lblStopwatch5.Text = "00:00:00.0000";
            btn5Start.Text = "Start";
            stopwatch4.Restart();
        }
    }
}