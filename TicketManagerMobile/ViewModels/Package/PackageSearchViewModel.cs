using System.Collections.ObjectModel;
using System.Linq;
using TicketApi.Exceptions;
using TicketApi.Extensions;
using TicketApi.Interfaces;
using TicketApi.Models;
using TicketManagerMobile.Views.Package;
using TicketManagerMobile.Wrappers;

namespace TicketManagerMobile.ViewModels
{
    public class PackageSearchViewModel : BaseViewModel
    {
        public PackageSearchViewModel(IPackageService packageService, INavigationService navigationService)
        {
            _packageService = packageService;
            _navigationService = navigationService;
        }

        private IPackageService _packageService;
        private INavigationService _navigationService;

        private Package _selectedPackage;
        private bool _isLoading;
        private bool _isNotFounded;
        private string _inputText;

        public Package SelectedPackage
        {
            get => _selectedPackage;
            set
            {
                if (_selectedPackage != value)
                {
                    _selectedPackage = value;
                    OnPropertyChanged(nameof(SelectedPackage));
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

        public bool IsNotFounded
        {
            get => _isNotFounded;
            set
            {
                if (_isNotFounded != value)
                {
                    _isNotFounded = value;
                    OnPropertyChanged(nameof(IsNotFounded));
                }
            }
        }

        public string InputText
        {
            get => _inputText;
            set
            {
                if (_inputText != value)
                {
                    _inputText = value;

                    OnPropertyChanged(nameof(InputText));
                }
            }
        }

        public ObservableCollection<Package> Packages { get; set; } = new ObservableCollection<Package>();

        public async void FindPackages()
        {
            if (string.IsNullOrEmpty(InputText))
                return;

            IsLoading = true;
            IsNotFounded = false;

            try
            {
                Packages.Clear();
                var packages = await _packageService.SearchAsync(InputText);

                if (packages.Any())
                {
                    Packages.AddRange(packages);
                }
                else
                {
                    IsNotFounded = true;
                }
            }
            catch (NoContentException)
            {
                IsNotFounded = true;
            }
            catch (HttpResponseException ex)
            {
                await MessageBox.ShowAsync($"Помилка {ex.StatusCodeNumber}", "Помилка");
            }
            catch
            {
                await MessageBox.ShowAsync("Помилка");
            }
            finally
            {
                IsLoading = false;
            }
        }

        public void OpenDetailsPage()
        {
            if (SelectedPackage != null)
            {
                _navigationService.NavigateTo(typeof(PackageDetailsPage), SelectedPackage.Id);
            }
        }
    }
}
