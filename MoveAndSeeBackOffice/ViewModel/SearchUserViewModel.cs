using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using MoveAndSeeBackOffice.Model;
using MoveAndSeeBackOffice.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Notifications;

namespace MoveAndSeeBackOffice.ViewModel
{
    class SearchUserViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public SearchUserViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        //PseudoUserSearch
        public string PseudoUserSearch { get; set; }

        //Navigation Command SearchUser
        private ICommand _searchUserCommand;

        public ICommand SearchUserCommand {
            get {
                if (this._searchUserCommand == null)
                {
                    this._searchUserCommand = new RelayCommand(async() => await SearchUserByServiceAsync());
                }
                return this._searchUserCommand;
            }
        }

        public async Task SearchUserByServiceAsync()
        {
            var service = new UserService();
            User user = await service.GetUserByPseudo(PseudoUserSearch, Token.tokenCurrent);

            

            if (user == null)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("Utilisateur non trouvé");
                await messageDialog.ShowAsync();
            }
            else
            {
                _navigationService.NavigateTo("EditUser", user);
            }
        }

        //Navigation Command HomeConnected
        private ICommand _homeConnectedCommand;

        public ICommand HomeConnectedCommand {
            get {
                if (this._homeConnectedCommand == null)
                {
                    this._homeConnectedCommand = new RelayCommand(() => GoToHomeConnected());
                }
                return this._homeConnectedCommand;
            }
        }

        private void GoToHomeConnected()
        {
            _navigationService.NavigateTo("HomeConnected");
        }

        //Navigation Command Back

        private ICommand _backCommand;

        public ICommand BackCommand {
            get {
                if (this._backCommand == null)
                {
                    this._backCommand = new RelayCommand(() => GoBack());
                }
                return this._backCommand;
            }
        }

        private void GoBack()
        {
            _navigationService.GoBack();
        }
    }
}