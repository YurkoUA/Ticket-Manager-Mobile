using System;
using System.Linq;
using TicketApi.Exceptions;
using TicketApi.Interfaces;
using TicketApi.Models;
using TicketManagerMobile.Wrappers;

namespace TicketManagerMobile.ViewModels
{
    public class PackageDetailsViewModel : AuthorizedViewModel
    {
        public PackageDetailsViewModel(IAuthenticationService authenticationService, INavigationService navigationService, IPackageService packageService) : base(authenticationService)
        {
            _packageService = packageService;
            _navigationService = navigationService;
        }

        private IPackageService _packageService;
        private INavigationService _navigationService;

        private Package _selectedPackage;
        private bool _isLoading;

        public Package SelectedPackage
        {
            get => _selectedPackage;
            set
            {
                if (_selectedPackage != value)
                {
                    _selectedPackage = value;

                    OnPropertyChanged(nameof(SelectedPackage));
                    OnPropertyChanged(nameof(PageTitle));
                    OnPropertyChanged(nameof(IsTicketsButtonVisibled));
                }
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged(nameof(IsLoading));
                }
            }
        }

        public string PageTitle => $"Пачка \"{SelectedPackage?.Name}\"";
        public bool IsTicketsButtonVisibled => SelectedPackage?.TicketsCount > 0;

        public async void LoadPackageAsync(int id)
        {
            try
            {
                IsLoading = true;
                SelectedPackage = await _packageService.GetByIdAsync(id);
            }
            catch (NotFoundException)
            {
                await MessageBox.ShowAsync("Пачку не знайдено.", "Помилка");
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

        public async void OpenTicketsPage()
        {
            try
            {
                var tickets = await _packageService.GetTicketsAsync(SelectedPackage.Id);

                if (tickets.Any())
                {
                    // TODO: Open package's tickets page.
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
