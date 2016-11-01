using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Threading;

using Prism.Mvvm;
using RestSharp;

using Devinmotion.Dashboard.Model.Weather.Types;
using Devinmotion.Dashboard.Model.Weather.Services;
using Devinmotion.Dashboard.Model.Appointments.Types;
using Devinmotion.Dashboard.Model.Weather.Serialization;
using Devinmotion.Dashboard.Model.Appointments.Services;

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
            Dispatcher uiDispatcher = Dispatcher.CurrentDispatcher;

            IWeatherConditionService weatherConditionService = new OpenWeatherMapWeatherConditionService();
            IJsonSerializerStrategy serializerStrategy = new OpenWeatherMapWeatherInfoSerializerStrategy(weatherConditionService);

            IWeatherInfoRepository weatherInfoRepository =
                new OpenWeatherMapWeatherInfoRepository(serializerStrategy, uiDispatcher);

            weatherInfos = weatherInfoRepository.LoadWeatherInfos();
            ((INotifyCollectionChanged)weatherInfos).CollectionChanged += WeatherInfosCollectionChangedHandler;

            Now = DateTime.Now;

            const string filePath = @"..\..\..\data\appointments.txt";
            IAppointmentRepository appointmentRepository = new LocalFileAppointmentRepository(filePath, uiDispatcher);
            Appointments = appointmentRepository.LoadAppointments();

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
