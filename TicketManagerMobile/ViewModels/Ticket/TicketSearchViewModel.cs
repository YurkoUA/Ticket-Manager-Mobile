using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using TicketApi.Exceptions;
using TicketApi.Extensions;
using TicketApi.Interfaces;
using TicketApi.Models;
using TicketManagerMobile.Views.Ticket;
using TicketManagerMobile.Wrappers;

namespace TicketManagerMobile.ViewModels
{
    public class TicketSearchViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private ITicketService _ticketService;

        public TicketSearchViewModel(ITicketService ticketService, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _ticketService = ticketService;
        }

        private Ticket _selectedTicket;
        private bool _isLoading;
        private bool _isNotFounded;
        private string _inputNumber;

        public Ticket SelectedTicket
        {
            get => _selectedTicket;
            set
            {
                if (_selectedTicket != value)
                {
                    _selectedTicket = value;
                    OnPropertyChanged(nameof(SelectedTicket));
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

        public string InputNumber
        {
            get => _inputNumber;
            set
            {
                if (_inputNumber != value)
                {
                    _inputNumber = value;
                    OnPropertyChanged(nameof(InputNumber));
                }
            }
        }

        public ObservableCollection<Ticket> Tickets { get; set; } = new ObservableCollection<Ticket>();

        public async void FindTickets()
        {
            if (!Regex.IsMatch(InputNumber, @"^\d{1,6}$"))
                return;

            IsNotFounded = false;
            IsLoading = true;

            try
            {
                Tickets.Clear();
                var tickets = await _ticketService.SearchAsync(InputNumber);

                if (tickets.Any())
                {
                    Tickets.AddRange(tickets);
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
            if (SelectedTicket != null)
            {
                _navigationService.NavigateTo(typeof(TicketDetailsPage), SelectedTicket.Id);
            }
        }
    }
}
