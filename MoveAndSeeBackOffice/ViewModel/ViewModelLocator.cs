using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MoveAndSeeBackOffice.View;

namespace MoveAndSeeBackOffice.ViewModel
{
    class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<DetailDescriptionViewModel>();
            SimpleIoc.Default.Register<DetailInterestPointViewModel>();
            SimpleIoc.Default.Register<EditUserViewModel>();
            SimpleIoc.Default.Register<HomeConnectedViewModel>();
            SimpleIoc.Default.Register<HomeNotConnectedViewModel>();
            SimpleIoc.Default.Register<ListInterestPointViewModel>();
            SimpleIoc.Default.Register<ListUnknownPointViewModel>();
            SimpleIoc.Default.Register<SearchUserViewModel>();

            NavigationService navigationPages = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationPages);
            navigationPages.Configure("DetailDescription", typeof(DetailDescription));
            navigationPages.Configure("DetailInterestPoint", typeof(DetailInterestPoint));
            navigationPages.Configure("EditUser", typeof(EditUser));
            navigationPages.Configure("HomeConnected", typeof(HomeConnected));
            navigationPages.Configure("HomeNotConnected", typeof(HomeNotConnected));
            navigationPages.Configure("ListInterestPoint", typeof(ListInterestPoint));
            navigationPages.Configure("ListUnknownPoint", typeof(ListUnknownPoint));
            navigationPages.Configure("SearchUser", typeof(SearchUser));
        }

        public DetailDescriptionViewModel DetailDescription {
            get {
                return ServiceLocator.Current.GetInstance<DetailDescriptionViewModel>();
            }
        }

        public DetailInterestPointViewModel DetailInterestPoint {
            get {
                return ServiceLocator.Current.GetInstance<DetailInterestPointViewModel>();
            }
        }

        public EditUserViewModel EditUser {
            get {
                return ServiceLocator.Current.GetInstance<EditUserViewModel>();
            }
        }

        public HomeConnectedViewModel HomeConnected {
            get {
                return ServiceLocator.Current.GetInstance<HomeConnectedViewModel>();
            }
        }

        public HomeNotConnectedViewModel HomeNotConnected {
            get {
                return ServiceLocator.Current.GetInstance<HomeNotConnectedViewModel>();
            }
        }

        public ListInterestPointViewModel ListInterestPoint {
            get {
                return ServiceLocator.Current.GetInstance<ListInterestPointViewModel>();
            }
        }

        public ListUnknownPointViewModel ListUnknownPoint {
            get {
                return ServiceLocator.Current.GetInstance<ListUnknownPointViewModel>();
            }
        }

        public SearchUserViewModel SearchUser {
            get {
                return ServiceLocator.Current.GetInstance<SearchUserViewModel>();
            }
        }
    }
}