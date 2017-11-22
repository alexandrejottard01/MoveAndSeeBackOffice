using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoveAndSeeBackOffice.ViewModel
{
    class HomeConnectedViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public HomeConnectedViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        //Command Navigation ListInterestPoint
        private ICommand _listInterestPointCommand;

        public ICommand ListInterestPointCommand {
            get {
                if (this._listInterestPointCommand == null)
                {
                    this._listInterestPointCommand = new RelayCommand(() => GoToListInterestPoint());
                }
                return this._listInterestPointCommand;
            }
        }

        private void GoToListInterestPoint()
        {
            _navigationService.NavigateTo("ListInterestPoint");
        }

        //Command Navigation ListUnknownPoint
        private ICommand _listUnknownPointCommand;

        public ICommand ListUnknownPointCommand {
            get {
                if (this._listUnknownPointCommand == null)
                {
                    this._listUnknownPointCommand = new RelayCommand(() => GoToListUnknownPoint());
                }
                return this._listUnknownPointCommand;
            }
        }

        private void GoToListUnknownPoint()
        {
            _navigationService.NavigateTo("ListUnknownPoint");
        }

        //Command Navigation SearchUser
        private ICommand _searchUserCommand;

        public ICommand SearchUserCommand {
            get {
                if (this._searchUserCommand == null)
                {
                    this._searchUserCommand = new RelayCommand(() => GoToSearchUser());
                }
                return this._searchUserCommand;
            }
        }

        private void GoToSearchUser()
        {
            _navigationService.NavigateTo("SearchUser");
        }
    }
}