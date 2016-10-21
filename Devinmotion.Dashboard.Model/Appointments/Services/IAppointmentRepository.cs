using System.Collections.ObjectModel;

using Devinmotion.Dashboard.Model.Appointments.Types;

namespace Devinmotion.Dashboard.Model.Appointments.Services
{
    public interface IAppointmentRepository
    {
        ReadOnlyObservableCollection<AppointmentBase> LoadAppointments();
    }
}
