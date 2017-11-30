﻿using GalaSoft.MvvmLight;
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
    class EditUserViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public EditUserViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        //Recuperation UserEdit
        public User _userEdit = null;

        public User UserEdit {
            get {
                return _userEdit;
            }
            set {
                if (_userEdit == value)
                {
                    return;
                }
                _userEdit = value;
                RaisePropertyChanged("UserEdit");
            }
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            UserEdit = (User)e.Parameter;
        }

        //Command Navigation EditUser
        private ICommand _editUserCommand;

        public ICommand EditUserCommand {
            get {
                if (this._editUserCommand == null)
                {
                    this._editUserCommand = new RelayCommand(() => EditUserByServiceAsync());
                }
                return this._editUserCommand;
            }
        }

        public async Task EditUserByServiceAsync()
        {
            var service = new UserService();

            int resultCode = await service.EditUser(UserEdit, Token.tokenCurrent);

            if (resultCode == Constants.CODE_SUCCESS)
            {
                //Se renseigner sur un autre moyen de faire des notifications
                var notificationXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
                var toastElements = notificationXml.GetElementsByTagName("text");
                toastElements[0].AppendChild(notificationXml.CreateTextNode("Modifications Enregistrés"));
                var toastNotification = new ToastNotification(notificationXml);
                ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
                GoToHomeConnected();
            }
            else
            {
                //Se renseigner sur un autre moyen de faire des notifications
                var notificationXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
                var toastElements = notificationXml.GetElementsByTagName("text");
                toastElements[0].AppendChild(notificationXml.CreateTextNode("Modifications Non Entregistrés"));
                var toastNotification = new ToastNotification(notificationXml);
                ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
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

        //Command Navigation HomeConnected
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