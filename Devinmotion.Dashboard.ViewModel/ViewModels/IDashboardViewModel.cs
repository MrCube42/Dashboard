using Devinmotion.Dashboard.Model.Models;
using System;
using System.Collections.ObjectModel;

namespace Devinmotion.Dashboard.ViewModel.ViewModels
{
    public interface IDashboardViewModel
    {
        WeatherInfo CurrentWeatherInfo { get; }

        DateTime Today { get; }

        ReadOnlyObservableCollection<AppointmentBase> Appointments { get; }

        Birthday CurrentBirthday { get; }
    }
}
