using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using MoveAndSeeBackOffice.Model;
using MoveAndSeeBackOffice.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Notifications;

namespace MoveAndSeeBackOffice.ViewModel
{
    class ListUnknownPointViewModel : ViewModelBase
    {

        private INavigationService _navigationService;

        public ListUnknownPointViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GetAllUnknownPointByServiceAsync();
        }

        public void InitializationListUnknownPointViewModel()
        {
            SelectedUnknownPoint = null;
            GetAllUnknownPointByServiceAsync();
        }

        //Liste de UnknownPoint
        private ObservableCollection<UnknownPoint> _listUnknownPoints = null;

        public ObservableCollection<UnknownPoint> ListUnknownPoints {
            get {
                return _listUnknownPoints;
            }
            set {
                if (_listUnknownPoints == value)
                {
                    return;
                }
                _listUnknownPoints = value;
                RaisePropertyChanged("ListUnknownPoints");
            }
        }
        
        public async Task GetAllUnknownPointByServiceAsync()
        {
            var service = new UnknownPointService();
            var listUnknownPoints = await service.GetAllUnknownPoints(Token.tokenCurrent);
            ListUnknownPoints = new ObservableCollection<UnknownPoint>(listUnknownPoints);
        }

        //SelectedUnknownPoint
        private UnknownPoint _selectedUnknownPoint;
        public UnknownPoint SelectedUnknownPoint {
            get { return _selectedUnknownPoint; }
            set {
                _selectedUnknownPoint = value;
                if (_selectedUnknownPoint != null)
                {
                    RaisePropertyChanged("SelectedUnknownPoint");
                }
            }
        }

        //Command DeleteUnknownPoint
        private ICommand _deleteUnknownPointCommand;

        public ICommand DeleteUnknownPointCommand {
            get {
                if (this._deleteUnknownPointCommand == null)
                {
                    this._deleteUnknownPointCommand = new RelayCommand(() => DeleteUnknownPointAsync());
                }
                return this._deleteUnknownPointCommand;
            }
        }

        public async Task DeleteUnknownPointAsync()
        {
            var service = new UnknownPointService();
            int resultCode = await service.DeleteUnknownPointById((int)SelectedUnknownPoint.IdUnknownPoint, Token.tokenCurrent);

            if (resultCode == Constants.CODE_SUCCESS)
            {
                ListUnknownPoints.Remove(SelectedUnknownPoint);
            }
            else
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("L'élément à supprimer est introuvable");
                await messageDialog.ShowAsync();
            }
            _navigationService.NavigateTo("ListUnknownPoint");
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
                    this._backCommand = new RelayCommand(() => GoToHomeConnected());
                }
                return this._backCommand;
            }
        }
    }
}