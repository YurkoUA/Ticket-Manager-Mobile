using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApi.Enums;
using TicketApi.Exceptions;
using TicketApi.Extensions;
using TicketApi.Interfaces;
using TicketApi.Models;
using TicketManagerMobile.Wrappers;

namespace TicketManagerMobile.ViewModels
{
    public class PackagesCategoryViewModel : BaseViewModel
    {
        public PackagesCategoryViewModel(IPackageService packageService, PackagesFilter filter)
        {
            _packageService = packageService;
            _filter = filter;
            
            LoadPackagesAsync();
        }

        private const int ITEMS_PER_PAGE = 20;

        private IPackageService _packageService;
        private PackagesFilter _filter;
        private int _page = 1;

        private Package _selectedPackage;
        private bool _isLoadMoreButtonEnabled;

        public ObservableCollection<Package> Packages { get; set; } = new ObservableCollection<Package>();
        public int TotalCount { get; set; }

        public bool IsLoadMoreButtonVisibled => Packages.Count < TotalCount;

        public bool IsLoadMoreButtonEnabled
        {
            get => _isLoadMoreButtonEnabled;
            set
            {
                if (_isLoadMoreButtonEnabled != value)
                {
                    _isLoadMoreButtonEnabled = value;
                    OnPropertyChanged(nameof(IsLoadMoreButtonEnabled));
                }
            }
        }

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

        public async void LoadPackagesAsync()
        {
            try
            {
                IsLoadMoreButtonEnabled = false;
                Packages.AddRange(await _packageService.GetPackagesAsync((_page - 1) * ITEMS_PER_PAGE, ITEMS_PER_PAGE, _filter));
                OnPropertyChanged(nameof(IsLoadMoreButtonVisibled));
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
                IsLoadMoreButtonEnabled = true;
            }
        }

        public void LoadMore()
        {
            _page++;
            LoadPackagesAsync();
        }

        public void Refresh()
        {
            Packages.Clear();
            _page = 1;
            LoadPackagesAsync();
        }

        public void OpenPackageDetails()
        {
            if (SelectedPackage != null)
            {
                // TODO: Open package's details.
            }
        }
    }
}
