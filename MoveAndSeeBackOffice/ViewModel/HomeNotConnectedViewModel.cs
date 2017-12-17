using MoveAndSeeBackOffice.Model;
using MoveAndSeeBackOffice.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Windows.UI.Notifications;
using Windows.Web.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.ComponentModel.DataAnnotations;

namespace MoveAndSeeBackOffice.ViewModel
{
    class HomeNotConnectedViewModel : ViewModelBase
    {
        
        private INavigationService _navigationService;

        public HomeNotConnectedViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        //Login et password User
        public string PseudoUserEntry { get ; set; }
        public string PasswordUserEntry { get; set; }

        public LoginUser LoginUser { get { return new LoginUser(this.PseudoUserEntry, this.PasswordUserEntry); } }

        //Navigation Command Login
        private ICommand _loginCommand;

        public ICommand LoginCommand {
            get {
                if (this._loginCommand == null)
                {
                    this._loginCommand = new RelayCommand(() => LoginServiceAsync());
                }
                return this._loginCommand;
            }
        }

        public async Task LoginServiceAsync()
        {
            var service = new UserService();
            //LoginUser test = new LoginUser("Chronix","Coucoucoucou007,");
            
            int resultCode = await service.LoginUser(/*test*/this.LoginUser);

            switch (resultCode)
            {
                case 200:
                    GoToHomeConnected();
                    break;
                case 401:
                    var messageNotAdmin = new Windows.UI.Popups.MessageDialog("Accès interdit");
                    await messageNotAdmin.ShowAsync();
                    break;
                case 404:
                    var messageNotFound = new Windows.UI.Popups.MessageDialog("Serveur non trouvé");
                    await messageNotFound.ShowAsync();
                    break;
                case 0:
                    var messageProbleme = new Windows.UI.Popups.MessageDialog("Problème de connection");
                    await messageProbleme.ShowAsync();
                    break;
            }
        }

        public void GoToHomeConnected()
        {
            _navigationService.NavigateTo("HomeConnected");
        }
    }
}
