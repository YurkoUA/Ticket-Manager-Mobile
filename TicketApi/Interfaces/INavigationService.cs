using System;

namespace TicketApi.Interfaces
{
    public interface INavigationService
    {
        void NavigateTo(Type page);
        void NavigateTo(Type page, object parameter);
        void GoBack();
    }
}
