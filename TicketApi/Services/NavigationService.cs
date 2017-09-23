using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using TicketApi.Interfaces;

namespace TicketApi.Services
{
    public class NavigationService : INavigationService
    {
        public Frame Frame => _frame;

        private Frame _frame;

        public NavigationService()
        {
            _frame = (Frame)Window.Current.Content;
        }

        public void NavigateTo(Type page)
        {
            _frame.Navigate(page);
        }

        public void NavigateTo(Type page, object parameter)
        {
            _frame.Navigate(page, parameter);
        }

        public void GoBack()
        {
            _frame.GoBack();
        }

        public void GoForward()
        {
            _frame.GoForward();
        }

        public void ClearHistory()
        {
            _frame.BackStack.Clear();
        }

        public void ConfigureFrame(Frame frame)
        {
            _frame = frame;
        }
    }
}
