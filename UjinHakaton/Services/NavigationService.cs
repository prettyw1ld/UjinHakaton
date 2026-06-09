using System;
using System.Collections.Generic;
using System.Text;
using UjinHakaton.ViewModels;

namespace UjinHakaton.Services
{
    public class NavigationService(ShellViewModel shell)
    {
        private readonly ShellViewModel _shell = shell;

        public void Navigate(ViewModelBase vm)
        {
            _shell.CurrentViewModel = vm;
            //BrowserStorage.SetItem("CurrentPage", vm.GetType().Name);
        }
    }
}
