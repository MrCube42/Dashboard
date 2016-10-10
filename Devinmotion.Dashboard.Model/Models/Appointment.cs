using System;

namespace Devinmotion.Dashboard.Model.Models
{
    public class Appointment : AppointmentBase
    {
        private readonly DateTime _startDate;

        private readonly DateTime _endDate;

        private readonly string _title;

        private readonly string _name;

        private readonly string _location;

        public Appointment(DateTime startDate, DateTime endDate, string title, string name, string location)
            : base(startDate)
        {
            _startDate = startDate;
            _endDate = endDate;
            _title = title;
            _name = name;
            _location = location;
        }
    }
}
