using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Prism.Mvvm;
using Devinmotion.Dashboard.Model.Weather.Types;
using Devinmotion.Dashboard.Model.Weather.Services;
using Devinmotion.Dashboard.Model.Appointments.Types;
using Devinmotion.Dashboard.Model.Weather.Serialization;
using RestSharp;

namespace Devinmotion.Dashboard.ViewModel.ViewModels
{
    public class DashboardViewModel : BindableBase, IDashboardViewModel
    {
        private readonly ReadOnlyObservableCollection<WeatherInfo> weatherInfos;

        private WeatherInfo currentWeatherInfo;

        public WeatherInfo CurrentWeatherInfo
        {
            get
            {
                return currentWeatherInfo;
            }

            set
            {
                if (!Equals(currentWeatherInfo, value))
                {
                    currentWeatherInfo = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Now { get; }

        public ReadOnlyObservableCollection<AppointmentBase> Appointments { get; }

        public Birthday CurrentBirthday { get; }

        public DashboardViewModel()
        {
            IWeatherConditionService weatherConditionService = new OpenWeatherMapWeatherConditionService();
            IJsonSerializerStrategy serializerStrategy = new OpenWeatherMapWeatherInfoSerializerStrategy(weatherConditionService);
            IWeatherInfoRepository weatherInfoRepository = new OpenWeatherMapWeatherInfoRepository(serializerStrategy);

            weatherInfos = weatherInfoRepository.LoadWeatherInfos();
            ((INotifyCollectionChanged)weatherInfos).CollectionChanged += WeatherInfosCollectionChangedHandler;

            WeatherCondition weatherCondition = weatherConditionService.ConvertKeyToWeatherCondition("03n");

            Now = DateTime.Now;

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
                    new DateTime(2016, 7, 18),
                    "Karl Coder"));
            appointments.Add(
                new Appointment(
                    new DateTime(2016, 7, 19, 8, 0, 0),
                    new DateTime(2016, 7, 19, 16, 0, 0),
                    "Workshop 'Refactoring Legacy Code'",
                    "Stefan Lieser",
                    "Shanghai"));
            Appointments = new ReadOnlyObservableCollection<AppointmentBase>(appointments);

            CurrentBirthday =
                new Birthday(
                    DateTime.Today,
                    "Peter Müller");
        }

        private void WeatherInfosCollectionChangedHandler(object sender, NotifyCollectionChangedEventArgs collectionChangeEvent)
        {
            CurrentWeatherInfo = collectionChangeEvent.NewItems[0] as WeatherInfo;

            // handle only once
            ((INotifyCollectionChanged)weatherInfos).CollectionChanged += WeatherInfosCollectionChangedHandler;
        }
    }
}
