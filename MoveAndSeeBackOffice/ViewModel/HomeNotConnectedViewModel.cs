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
            LoginUser test = new LoginUser("Chronix","Coucoucoucou007,");
            Token token = await service.LoginUser(test/*this.LoginUser*/);


            //A changer, on ne teste pas le token c'est pas propre
            if (token == null)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("Problème de connection");
                await messageDialog.ShowAsync();
            }
            else
            {
                if (VerificationIsAdmin(token.TokenString))
                {
                    Token.tokenCurrent = token;
                    GoToHomeConnected();
                }
                else
                {
                    var messageDialog = new Windows.UI.Popups.MessageDialog("Vous n'êtes pas administrateur");
                    await messageDialog.ShowAsync();
                }
                
            }
        }

        public bool VerificationIsAdmin(String token)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;
            var role = tokenS.Claims.SingleOrDefault(claim => claim.Type == "Role").Value;

            if(role != null && role == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public void GoToHomeConnected()
        {
            _navigationService.NavigateTo("HomeConnected");
        }
    }
}
