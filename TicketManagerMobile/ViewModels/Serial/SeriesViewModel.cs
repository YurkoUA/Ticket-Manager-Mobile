using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApi.Exceptions;
using TicketApi.Extensions;
using TicketApi.Interfaces;
using TicketApi.Models;
using TicketManagerMobile.Views.Serial;
using TicketManagerMobile.Wrappers;

namespace TicketManagerMobile.ViewModels
{
    public class SeriesViewModel : BaseViewModel
    {
        private ISerialService _serialService;
        private INavigationService _navigationService;

        public SeriesViewModel(ISerialService serialService, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _serialService = serialService;
        }

        private Serial _selectedSerial;

        public ObservableCollection<Serial> Series { get; set; } = new ObservableCollection<Serial>();

        public Serial SelectedSerial
        {
            get => _selectedSerial;
            set
            {
                if (_selectedSerial != value)
                {
                    _selectedSerial = value;
                    OnPropertyChanged(nameof(SelectedSerial));
                }
            }
        }

        public async void LoadSeriesAsync()
        {
            try
            {
                Series.AddRange(await _serialService.GetSeriesAsync());
            }
            catch (HttpResponseException ex)
            {
                await MessageBox.ShowAsync($"Помилка {ex.StatusCodeNumber}", "Помилка");
            }
            catch
            {
                await MessageBox.ShowAsync("Помилка");
            }
        }

        public void OpenSerialPage()
        {
            if (SelectedSerial != null)
            {
                _navigationService.NavigateTo(typeof(SerialDetailsPage), SelectedSerial.Id);
            }
        }
    }
}
