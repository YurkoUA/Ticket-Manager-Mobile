using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using TicketApi.Interfaces;

namespace TicketApi.Services
{
    public class NavigationService : INavigationService
    {
        public void NavigateTo(Type page)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(page);
        }

        public void NavigateTo(Type page, object parameter)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(page, parameter);
        }

        public void GoBack()
        {
            var frame = (Frame)Window.Current.Content;
            frame.GoBack();
        }
    }
}
