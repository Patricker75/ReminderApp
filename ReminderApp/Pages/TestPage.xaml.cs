using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ReminderApp;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReminderApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        readonly string filePath;
        /*public TestPage()
        {
            InitializeComponent();

            // Creates the path to the data file
            string basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            filePath = Path.Combine(basePath, "Tasks.json");

            // Creates the file and disposes the stream to avoid IOException
            if(!File.Exists(filePath))
            {
                FileStream fs = new FileStream(filePath, FileMode.Create);
                fs.Dispose();
            }
        }*/

        public TestPage()
        {
            InitializeComponent();

            List<Task> tasks = Variables.Tasks;

            foreach (Task task in tasks)
            {
                testLabel.Text += task.ToString() + "\n";
            }
        }
    }
}