using System.Collections.ObjectModel;
using TicketApi.Exceptions;
using TicketApi.Extensions;
using TicketApi.Interfaces;
using TicketApi.Models;
using TicketManagerMobile.Views.Color;
using static TicketManagerMobile.Wrappers.MessageBox;

namespace TicketManagerMobile.ViewModels
{
    public class ColorsViewModel : BaseViewModel
    {
        public ColorsViewModel(IColorService colorService, INavigationService navigationService)
        {
            _colorService = colorService;
            _navigationService = navigationService;
        }

        private IColorService _colorService;
        private INavigationService _navigationService;
        
        private Color _selectedColor;

        public ObservableCollection<Color> Colors { get; set; } = new ObservableCollection<Color>();

        public Color SelectedColor
        {
            get => _selectedColor;
            set
            {
                if (_selectedColor != value)
                {
                    _selectedColor = value;
                    OnPropertyChanged(nameof(SelectedColor));
                }
            }
        }

        public async void LoadColorsAsync()
        {
            try
            {
                var colors = await _colorService.GetColorsAsync();
                Colors.AddRange(colors);
            }
            catch (HttpResponseException ex)
            {
                await ShowAsync($"Помилка {ex.StatusCodeNumber}", "Помилка");
            }
            catch
            {
                await ShowAsync("Помилка");
            }
        }

        public void OpenColorPage()
        {
            if (SelectedColor != null)
            {
                _navigationService.NavigateTo(typeof(ColorDetailsPage), SelectedColor.Id);
            }
        }
    }
}
