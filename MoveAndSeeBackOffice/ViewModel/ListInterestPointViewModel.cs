﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using MoveAndSeeBackOffice.Model;
using MoveAndSeeBackOffice.Service;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoveAndSeeBackOffice.ViewModel
{
    class ListInterestPointViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public ListInterestPointViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GetAllInterestPointByServiceAsync();
            MessengerInstance.Register<InterestPointWithVote>(this, "deleteInterestPoint", (ip => ListInterestPoints.Remove(ip)));            
        }
      
        public void InitializationListInterestPointViewModel()
        {
            SelectedInterestPoint = null;
            GetAllInterestPointByServiceAsync();
        }

        //ListInterestPoints
        private ObservableCollection<InterestPointWithVote> _listInterestPoints = null;

        public ObservableCollection<InterestPointWithVote> ListInterestPoints {
            get {
                return _listInterestPoints;
            }
            set {
                if (_listInterestPoints == value)
                {
                    return;
                }
                _listInterestPoints = value;
                RaisePropertyChanged("ListInterestPoints");
            }
        }

        public async Task GetAllInterestPointByServiceAsync()
        {
            var service = new InterestPointService();
            var listInterestPoints = await service.GetAllInterestPointSortedByVoteInterestPoint(Token.tokenCurrent);
            ListInterestPoints = new ObservableCollection<InterestPointWithVote>(listInterestPoints);
        }

        //SelectedInterestPoint
        private InterestPointWithVote _selectedInterestpoint;
        public InterestPointWithVote SelectedInterestPoint {
            get { return _selectedInterestpoint; }
            set {
                _selectedInterestpoint = value;

                if (_selectedInterestpoint != null)
                {
                    GoToDetailInterestPoint();
                    RaisePropertyChanged("SelectedInterestPoint");
                }
            }
        }

        public void GoToDetailInterestPoint()
        {
            if (SelectedInterestPoint != null)
            {
                _navigationService.NavigateTo("DetailInterestPoint", SelectedInterestPoint);
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

        //Navigation Back

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