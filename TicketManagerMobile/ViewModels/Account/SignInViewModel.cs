using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicketApi.Exceptions;
using TicketApi.Interfaces;
using TicketManagerMobile.Views.Home;
using static TicketManagerMobile.Wrappers.MessageBox;

namespace TicketManagerMobile.ViewModels.Account
{
    public class SignInViewModel : BaseViewModel
    {
        private IAuthenticationService _authService;
        private INavigationService _navigationService;

        private string _userName;
        private string _password;
        private bool? _isRemember = false;
        private bool _isLoading;

        public SignInViewModel(IAuthenticationService authService, INavigationService navigService)
        {
            _authService = authService;
            _navigationService = navigService;
        }

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public bool? IsRemember
        {
            get => _isRemember;
            set
            {
                _isRemember = value;
                OnPropertyChanged("IsRemember");
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }

        public async Task Authorize()
        {
            try
            {
                IsLoading = true;
                await _authService.AuthorizeAsync(UserName, Password, IsRemember != null ? IsRemember.Value : false);
                _navigationService.NavigateTo(typeof(HomePage));
            }
            catch (BadRequestException)
            {
                await ShowAsync("Невірний логін або пароль", "Помилка");
            }
            catch (HttpResponseException ex)
            {
                await ShowAsync($"Сервіс недоступний. Перевірте підключення до мережі або спробуйте ще раз.\n\nКод помилки: {ex.StatusCodeNumber}",
                    "Помилка");
            }
            catch
            {
                await ShowAsync("Сталася якась помилка.\n\nПеревірте підключення до мережі.", "Помилка");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
