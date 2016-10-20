using System.Collections.Generic;

using Devinmotion.Dashboard.Model.Appointments.Types;

namespace Devinmotion.Dashboard.Model.Appointments.Services
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> LoadAppointments();
    }
}
