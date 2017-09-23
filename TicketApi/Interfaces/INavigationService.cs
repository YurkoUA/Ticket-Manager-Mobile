using System;
using Windows.UI.Xaml.Controls;

namespace TicketApi.Interfaces
{
    public interface INavigationService
    {
        Frame Frame { get;  }

        void NavigateTo(Type page);
        void NavigateTo(Type page, object parameter);
        void GoBack();
        void GoForward();
        void ClearHistory();

        void ConfigureFrame(Frame frame);
    }
}
