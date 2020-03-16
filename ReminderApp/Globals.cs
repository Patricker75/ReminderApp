using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ReminderApp
{
    public static class Constants
    {
        public static string FilePath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Tasks.json");

        public static void SaveData()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(Variables.Tasks));
        }

        public static void LoadData()
        {
            if (JsonConvert.DeserializeObject<List<Task>>(File.ReadAllText(Constants.FilePath)) != null)
            {
                Variables.Tasks = JsonConvert.DeserializeObject<List<Task>>(File.ReadAllText(Constants.FilePath));
            }
        }
    }

    public static class Variables
    {
        public static List<Task> Tasks { get; set; } = new List<Task>();
    }
}
