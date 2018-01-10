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
using Windows.UI.Xaml.Navigation;

namespace MoveAndSeeBackOffice.ViewModel
{
    class DetailDescriptionViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public DetailDescriptionViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
        }

        //Recuperation SelectedDescription
        public DescriptionWithVote SelectedDescription { get; set; }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            SelectedDescription = (DescriptionWithVote)e.Parameter;
        }

        //Command DeleteDescription
        private ICommand _deleteDescriptionCommand;

        public ICommand DeleteDescriptionCommand {
            get {
                if (this._deleteDescriptionCommand == null)
                {
                    this._deleteDescriptionCommand = new RelayCommand(async() => await DeleteDescriptionAsync());
                }
                return this._deleteDescriptionCommand;
            }
        }

        public async Task DeleteDescriptionAsync()
        {
            var service = new DescriptionService();
            int resultCode = await service.DeleteDescriptionById(SelectedDescription.Description.IdDescription, Token.tokenCurrent);

            if (resultCode == 200)
            {
                MessengerInstance.Send<DescriptionWithVote>(SelectedDescription, "deleteDescription");
            }
            else
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("L'élément à supprimer est introuvable");
                await messageDialog.ShowAsync();
            }
            _navigationService.GoBack();
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
            _navigationService.GoBack();
        }
    }
}