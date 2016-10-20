using Devinmotion.Dashboard.Model.Appointments.Types;
using Devinmotion.Dashboard.Model.Weather.Types;
using System;
using System.Collections.ObjectModel;

namespace Devinmotion.Dashboard.ViewModel.ViewModels
{
    public interface IDashboardViewModel
    {
        WeatherInfo CurrentWeatherInfo { get; }

        DateTime Now { get; }

        ReadOnlyObservableCollection<AppointmentBase> Appointments { get; }

        Birthday CurrentBirthday { get; }
    }
}
