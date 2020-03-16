using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReminderApp;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReminderApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }

        public void OnSubmit(object sender, EventArgs e)
        {
            if (taskName.Text == "")
            {
                return; //TODO Error Message
            }

            Task newTask = new Task
            {
                Name = taskName.Text,
                EndDate = taskDate.Date.ToString("yyyyMMdd"),
                Notes = taskNotes.Text
            };

            Variables.Tasks.Add(newTask);

            taskName.Text = "";
            taskDate.Date = DateTime.Today;
            taskNotes.Text = "";
        }
    }
}