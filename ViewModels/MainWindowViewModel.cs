using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using Splat;

namespace Library.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IScreen
    {
        public RoutingState Router { get; } = new();
        
        public AuthViewModel authViewModel { get; }

        public MainWindowViewModel()
        {
            // authViewModel = new();
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
            Router.Navigate.Execute(new AuthViewModel());
        }

    }
}
