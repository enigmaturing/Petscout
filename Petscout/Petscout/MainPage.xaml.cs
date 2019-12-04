using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Petscout
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonON_Clicked(object sender, EventArgs e)
        {
            toggleMotor("on");
        }

        private void ButtonOFF_Clicked(object sender, EventArgs e)
        {
            toggleMotor("off");
        }

        private async void toggleMotor(string s)
        {
            if (tokenEntry.Text == null)
            {
                await DisplayAlert("Alert", "Insert a valid token first!", "OK");
            }
            else
            {
                using (var httpClient = new HttpClient())
                {
                    var formcontent = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("arg", s) });
                    var request = await httpClient.PostAsync("https://api.particle.io/v1/devices/e00fce68ba9a1f5ea4870186/motorToggle?access_token=" + tokenEntry.Text.ToString(), formcontent);
                }
            }

        }
    }
}
