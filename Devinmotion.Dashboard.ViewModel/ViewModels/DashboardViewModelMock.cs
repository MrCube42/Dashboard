using System;
using System.Collections.ObjectModel;
using Devinmotion.Dashboard.Model.Models;

namespace Devinmotion.Dashboard.ViewModel.ViewModels
{
    public class DashboardViewModelMock : IDashboardViewModel
    {
        public WeatherInfo CurrentWeatherInfo { get; }

        public DateTime Today { get; }

        public ReadOnlyObservableCollection<AppointmentBase> Appointments { get; }

        public Birthday CurrentBirthday { get; }

        public DashboardViewModelMock()
        {
            CurrentWeatherInfo =
                new WeatherInfo(
                    "Köln",
                    "21°C",
                    "bewölkt",
                    "CLOUDICON");

            Today = DateTime.Now;

            ObservableCollection<AppointmentBase> appointments = new ObservableCollection<AppointmentBase>();
            appointments.Add(
                new Appointment(
                    DateTime.Today.AddHours(9), 
                    DateTime.Today.AddHours(17), 
                    "Workshop 'Clean Code Developer'", 
                    "Stefan Lieser", 
                    "Chiang Mai"));
            appointments.Add(
                new Birthday(
                    DateTime.Parse("18.07.2016"),
                    "Karl Coder"));
            appointments.Add(
                new Appointment(
                    DateTime.Parse("19.07.2016 9:00"),
                    DateTime.Parse("19.07.2016 17:00"),
                    "Workshop 'Refactoring Legacy Code'",
                    "Stefan Lieser",
                    "Shanghai"));
            Appointments = new ReadOnlyObservableCollection<AppointmentBase>(appointments);

            CurrentBirthday =
                new Birthday(
                    DateTime.Today,
                    "Peter Müller");
        }
    }
}
