using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApi.Exceptions;
using TicketApi.Interfaces;
using TicketApi.Models;
using TicketManagerMobile.Wrappers;

namespace TicketManagerMobile.ViewModels
{
    public class SerialDetailsViewModel : BaseViewModel
    {
        private ISerialService _serialService;

        public SerialDetailsViewModel(ISerialService serialService)
        {
            _serialService = serialService;
        }

        private Serial _selectedSerial;
        private bool _isLoading;

        public Serial SelectedSerial
        {
            get => _selectedSerial;
            set
            {
                if (_selectedSerial != value)
                {
                    _selectedSerial = value;

                    OnPropertyChanged(nameof(SelectedSerial));
                    OnPropertyChanged(nameof(PageTitle));
                    OnPropertyChanged(nameof(PackagesButtonVisibled));
                }
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public string PageTitle => $"Серія \"{SelectedSerial?.Name}\"";
        public bool PackagesButtonVisibled => SelectedSerial?.PackagesCount > 0;

        public async void LoadSerialAsync(int id)
        {
            try
            {
                IsLoading = true;
                SelectedSerial = await _serialService.GetByIdAsync(id);
            }
            catch (NotFoundException)
            {
                await MessageBox.ShowAsync("Серію не знайдено.", "Помилка");
            }
            catch (HttpResponseException ex)
            {
                await MessageBox.ShowAsync($"Сталася помилка. Можливо, сервіс недоступний. Спробуйте ще раз.\n\nКод помилки: {ex.StatusCodeNumber}.", "Помилка ");
            }
            catch (Exception ex)
            {
                await MessageBox.ShowAsync($"Сталася помилка.\nСпробуйте пізніше.\n\n{ex.Message}", "Помилка");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
