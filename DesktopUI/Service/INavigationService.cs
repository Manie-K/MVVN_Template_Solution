using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopUI.Core;

namespace DesktopUI.Service
{
    public interface INavigationService
    {
        public ViewModelBase CurrentViewModel { get; }
        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase;
    }
}
