using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using MoveAndSeeBackOffice.Model;
using MoveAndSeeBackOffice.Service;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Notifications;
using Windows.UI.Xaml.Navigation;

namespace MoveAndSeeBackOffice.ViewModel
{
    class DetailInterestPointViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public DetailInterestPointViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
            MessengerInstance.Register<DescriptionWithVote>(this, "deleteDescription", (desc => ListDescriptions.Remove(desc)));
        }

        //Recuperation SelectedInterestPoint
        public InterestPointWithVote SelectedInterestPoint { get; set; }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            SelectedInterestPoint = (InterestPointWithVote)e.Parameter;
            GetAllDescriptionsByServiceAsync();
        }

        //Liste de Description
        private ObservableCollection<DescriptionWithVote> _listDescriptions = null;

        public ObservableCollection<DescriptionWithVote> ListDescriptions {
            get {
                return _listDescriptions;
            }
            set {
                if (_listDescriptions == value)
                {
                    return;
                }
                _listDescriptions = value;
                RaisePropertyChanged("ListDescriptions");
            }
        }

        public async Task GetAllDescriptionsByServiceAsync()
        {
            var service = new DescriptionService();
            var listDescriptions = await service.GetAllDescriptionsByInterestPoint(SelectedInterestPoint.InterestPoint.IdInterestPoint, Token.tokenCurrent);
            ListDescriptions = new ObservableCollection<DescriptionWithVote>(listDescriptions); 
        }

        //Command DeleteInterestPoint
        private ICommand _deleteInterestPointCommand;

        public ICommand DeleteInterestPointCommand {
            get {
                if (this._deleteInterestPointCommand == null)
                {
                    this._deleteInterestPointCommand = new RelayCommand(async() => await DeleteInterestPointAsync());
                }
                return this._deleteInterestPointCommand;
            }
        }

        public async Task DeleteInterestPointAsync()
        {
            var service = new InterestPointService();
            int resultCode = await service.DeleteInterestPointById((int)SelectedInterestPoint.InterestPoint.IdInterestPoint, Token.tokenCurrent);

            if (resultCode == Constants.CODE_SUCCESS)
            {
                MessengerInstance.Send<InterestPointWithVote>(SelectedInterestPoint, "deleteInterestPoint");
            }
            else
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("L'élément à supprimer est introuvable");
                await messageDialog.ShowAsync();
            }
            _navigationService.NavigateTo("ListInterestPoint");
        }

        //SelectedDescription
        private DescriptionWithVote _selectedDescription;
        public DescriptionWithVote SelectedDescription {
            get { return _selectedDescription; }
            set { //Changer la manière de faire (p)
                _selectedDescription = value;
                if (_selectedDescription != null)
                {
                    GoToDetailDescription();
                    RaisePropertyChanged("SelectedDescription");
                }
            }
        }
        

        //Command Navigation DetailDescription
        private ICommand _detailDescriptionCommand;

        public ICommand DetailDescriptionCommand {
            get {
                if (this._detailDescriptionCommand == null)
                {
                    this._detailDescriptionCommand = new RelayCommand(() => GoToDetailDescription());
                }
                return this._detailDescriptionCommand;
            }
        }

        public void GoToDetailDescription()
        {
            if (SelectedDescription != null)
            {
                _navigationService.NavigateTo("DetailDescription", SelectedDescription);
            }
        }

        //Command Navigation HomeConnected
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

        //Command Navigation Back
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
            _navigationService.NavigateTo("ListInterestPoint");
            MessengerInstance.Send<InterestPointWithVote>(SelectedInterestPoint,"nullSelectedInterestPoint");
        }
    }
}