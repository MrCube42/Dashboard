using System;

namespace Devinmotion.Dashboard.Model.Models
{
    public class AppointmentBase
    {
        public DateTime Date { get; }

        public AppointmentBase(DateTime date)
        {
            Date = date;
        }
    }
}
