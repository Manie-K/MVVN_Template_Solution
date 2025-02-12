using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopUI.Core;
using DesktopUI.Service;

namespace DesktopUI.MVVN.Viewmodel
{
    public class MainViewModel : ViewModelBase
    {

        private INavigationService _navigation;
        public INavigationService Navigation
        {
            get { return _navigation; }
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToSettingsCommand { get; private set; }

        public MainViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;

            NavigateToSettingsCommand = new RelayCommand(o => Navigation.NavigateTo<SettingsViewModel>(), o => true);
        }

    }
}
