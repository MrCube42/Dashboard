using System;

namespace Devinmotion.Dashboard.Model.Models
{
    public class Appointment : AppointmentBase
    {
        public DateTime StartDate { get; }
                                   
        public DateTime EndDate  { get; }
                                   
        public string Title      { get; }
                                   
        public string Name       { get; }
                                   
        public string Location   { get; }

        public Appointment(DateTime startDate, DateTime endDate, string title, string name, string location)
            : base(startDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            Title = title;
            Name = name;
            Location = location;
        }
    }
}
