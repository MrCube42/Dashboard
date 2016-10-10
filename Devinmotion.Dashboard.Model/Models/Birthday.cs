using System;

namespace Devinmotion.Dashboard.Model.Models
{
    public class Birthday : AppointmentBase
    {
        public string Name { get; }

        public Birthday(DateTime birthday, string name) : base(birthday)
        {
            Name = name;
        }
    }
}
