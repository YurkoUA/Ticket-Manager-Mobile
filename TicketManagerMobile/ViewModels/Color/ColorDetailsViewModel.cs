using System;
using System.Linq;
using TicketApi.Exceptions;
using TicketApi.Interfaces;
using TicketApi.Models;
using TicketManagerMobile.Views.Package;
using TicketManagerMobile.Wrappers;

namespace TicketManagerMobile.ViewModels
{
    public class ColorDetailsViewModel : BaseViewModel
    {
        private IColorService _colorService;
        private INavigationService _navigationService;

        public ColorDetailsViewModel(IColorService colorService, INavigationService navigationService)
        {
            _colorService = colorService;
            _navigationService = navigationService;
        }

        private Color _selectedColor;
        private bool _isLoading;

        public Color SelectedColor
        {
            get => _selectedColor;
            set
            {
                if (_selectedColor != value)
                {
                    _selectedColor = value;

                    OnPropertyChanged(nameof(SelectedColor));
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

        public string PageTitle => $"Колір \"{SelectedColor?.Name}\"";
        public bool PackagesButtonVisibled => SelectedColor?.PackagesCount > 0;

        public async void LoadColorAsync(int id)
        {
            try
            {
                IsLoading = true;
                SelectedColor = await _colorService.GetByIdAsync(id);
            }
            catch (NotFoundException)
            {
                await MessageBox.ShowAsync("Колір не знайдено.", "Помилка");
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

        public async void OpenPackagesPage()
        {
            try
            {
                var packages = await _colorService.GetPackagesAsync(SelectedColor.Id);

                if (packages.Any())
                {
                    _navigationService.NavigateTo(typeof(PackagesListPage), packages);
                }
            }
            catch (HttpResponseException ex)
            {
                await MessageBox.ShowAsync($"Сталася помилка. Можливо, сервіс недоступний. Спробуйте ще раз.\n\nКод помилки: {ex.StatusCodeNumber}.", "Помилка ");
            }
            catch (Exception ex)
            {
                await MessageBox.ShowAsync($"Сталася помилка.\nСпробуйте пізніше.\n\n{ex.Message}", "Помилка");
            }
        }
    }
}
