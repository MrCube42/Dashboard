using System;

namespace Devinmotion.Dashboard.Model.Models
{
    public class Birthday : AppointmentBase
    {
        private readonly string _name;

        public Birthday(DateTime birthday, string name) : base(birthday)
        {
            _name = name;
        }
    }
}
