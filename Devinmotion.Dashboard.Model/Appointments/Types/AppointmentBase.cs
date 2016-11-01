using System;

namespace Devinmotion.Dashboard.Model.Appointments.Types
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
