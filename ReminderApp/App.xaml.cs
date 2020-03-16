using System;
using System.IO;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace ReminderApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            Constants.LoadData();
        }

        protected override void OnSleep()
        {
            Constants.SaveData();
        }

        protected override void OnResume()
        {
            Constants.LoadData();
        }
    }
}
