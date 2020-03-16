using System;

namespace ReminderApp
{
    public struct Task
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public string EndDate { get; set; }

        public int GetYear()
        {
            return int.Parse(EndDate.Substring(0, 4));
        }

        public int GetMonth()
        {
            return int.Parse(EndDate.Substring(4, 2));
        }

        public int GetDay()
        {
            return int.Parse(EndDate.Substring(6));
        }

        public override string ToString()
        {
            return String.Format("Name: {0}\nNotes: {1}\nEnd Date (DD/MM/YYYY): {2:D2}/{3:D2}/{4}", Name, Notes, GetDay(), GetMonth(), GetYear());
        }
    }
}
