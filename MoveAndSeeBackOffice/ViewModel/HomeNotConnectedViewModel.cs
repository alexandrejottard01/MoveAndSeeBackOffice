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
            Token token = await service.LoginUser(this.LoginUser);



            if (token == null)
            {
                //Se renseigner sur un autre moyen de faire des notifications
                var notificationXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
                var toastElements = notificationXml.GetElementsByTagName("text");
                toastElements[0].AppendChild(notificationXml.CreateTextNode("Problème de connection"));
                var toastNotification = new ToastNotification(notificationXml);
                ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
            }
            else
            {
                Token.tokenCurrent = token;
                GoToHomeConnected();
            }
        }

        public void GoToHomeConnected()
        {
            _navigationService.NavigateTo("HomeConnected");  
        }
    }
}