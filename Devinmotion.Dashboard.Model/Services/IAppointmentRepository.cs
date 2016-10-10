using Devinmotion.Dashboard.Model.Models;
using System.Collections.Generic;

namespace Devinmotion.Dashboard.Model.Services
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> LoadAppointments();
    }
}
