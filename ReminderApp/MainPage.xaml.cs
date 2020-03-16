using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace ReminderApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.MasterList.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Handles the selection of items on the master page
            if (e.SelectedItem is MasterPageItem selected)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(selected.TargetType));
                masterPage.MasterList.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
