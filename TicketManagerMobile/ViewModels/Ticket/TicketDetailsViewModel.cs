using System;
using TicketApi.Exceptions;
using TicketApi.Interfaces;
using TicketApi.Models;
using TicketManagerMobile.Wrappers;

namespace TicketManagerMobile.ViewModels
{
    public class TicketDetailsViewModel : AuthorizedViewModel
    {
        public TicketDetailsViewModel(IAuthenticationService authenticationService, ITicketService ticketService, INavigationService navigationService) : base(authenticationService)
        {
            _ticketService = ticketService;
            _navigationService = navigationService;
        }

        private ITicketService _ticketService;
        private INavigationService _navigationService;

        private Ticket _selectedTicket;
        private bool _isLoading;

        public Ticket SelectedTicket
        {
            get => _selectedTicket;
            set
            {
                if (_selectedTicket != value)
                {
                    _selectedTicket = value;

                    OnPropertyChanged(nameof(SelectedTicket));
                    OnPropertyChanged(nameof(PageTitle));
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

        public string PageTitle => $"Квиток №{SelectedTicket?.Number}";

        public async void LoadTicketAsync(int id)
        {
            try
            {
                IsLoading = true;
                SelectedTicket = await _ticketService.GetByIdAsync(id);
            }
            catch (NotFoundException)
            {
                await MessageBox.ShowAsync("Квиток не знайдено.", "Помилка");
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
