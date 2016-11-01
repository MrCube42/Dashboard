using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Threading;

using Devinmotion.Dashboard.Model.Appointments.Types;

namespace Devinmotion.Dashboard.Model.Appointments.Services
{
    public class LocalFileAppointmentRepository : IAppointmentRepository
    {
        private const char CSV_SEPARATOR = ';';

        private const char TIME_SEPARATOR = '-';

        private string FilePath { get; }

        private Dispatcher uiDispatcher;

        public LocalFileAppointmentRepository(string filePath, Dispatcher theUiDispatcher)
            : this(filePath)
        {
            uiDispatcher = theUiDispatcher;
        }

        private LocalFileAppointmentRepository(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException($"File '{filePath}' does not exist.");
            }

            FilePath = filePath;
        }

        public ReadOnlyObservableCollection<AppointmentBase> LoadAppointments()
        {
            ObservableCollection<AppointmentBase> observableAppointments
                = new ObservableCollection<AppointmentBase>();
            ReadOnlyObservableCollection<AppointmentBase> readonlyAppointments
                = new ReadOnlyObservableCollection<AppointmentBase>(observableAppointments);

            string[] lines = File.ReadAllLines(FilePath);
            foreach (string line in lines)
            {
                //date; time; title; names; location
                string[] items = line.Split(CSV_SEPARATOR);

                string date = items[0];

                DateTime startDay = DateTime.Parse(date);

                string[] time = items[1].Split(TIME_SEPARATOR);
                DateTime startTime = DateTime.Parse(time[0]);
                DateTime endTime = DateTime.Parse(time[1]);

                DateTime startDate = startDay
                    .Add(TimeSpan.FromHours(startTime.Hour))
                    .Add(TimeSpan.FromMinutes(startTime.Minute));

                DateTime endDate = startDay
                    .Add(TimeSpan.FromHours(endTime.Hour))
                    .Add(TimeSpan.FromMinutes(endTime.Minute));

                string title = items[2];
                string names = items[3];
                string location = items[4];

                Appointment appointment =
                    new Appointment(startDate, endDate, title, names, location);

                uiDispatcher.InvokeAsync(() =>
                {
                    observableAppointments.Add(appointment);
                }, DispatcherPriority.Background);
            }

            return readonlyAppointments;
        }
    }
}
