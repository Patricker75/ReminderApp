using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReminderApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskList : ContentPage
    {
        SortedDictionary<string, List<Task>> sortedTask = new SortedDictionary<string, List<Task>>();
        public TaskList()
        {
            InitializeComponent();

            FormatList();

            foreach (KeyValuePair<string, List<Task>> entry in sortedTask)
            {
                StackLayout stack = new StackLayout()
                {
                    Margin = new Thickness(5, 5, 5, 7.5),
                    Padding = new Thickness(5),
                    BackgroundColor = new Color(0, 0, 255)
                };
                stack.Children.Add(new Label()
                {
                    Text = GetDate(entry.Value[0]),
                    HorizontalTextAlignment = TextAlignment.Start,
                    TextDecorations = TextDecorations.Underline,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                });
                foreach (Task item in entry.Value)
                {
                    stack.Children.Add(new Label()
                    {
                        Text = item.Name,
                        HorizontalTextAlignment = TextAlignment.Start
                    });
                }
                list.Children.Add(stack);
            }
        }

        private void FormatList()
        {
            List<Task> tasks = Variables.Tasks;
            foreach (Task task in tasks)
            {
                List<Task> dictVal = new List<Task>();

                if (sortedTask.ContainsKey(task.EndDate))
                {
                    dictVal = sortedTask[task.EndDate];
                    dictVal.Add(task);

                    sortedTask.Remove(task.EndDate);
                    sortedTask.Add(task.EndDate, dictVal);
                }
                else
                {
                    dictVal.Add(task);

                    sortedTask.Add(task.EndDate, dictVal);
                }
            }
        }

        private string GetDate(Task t)
        {
            return String.Format("{0}/{1:D2}/{2:D2}", t.GetYear(), t.GetMonth(), t.GetDay());
        }
    }
}