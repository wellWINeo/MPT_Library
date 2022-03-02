using System;
using System.Collections.Generic;
using System.Text;
using Library.Services;
using ReactiveUI;
using ReactiveUI.Validation.Helpers;
using Splat;

namespace Library.ViewModels
{
    public class ViewModelBase : ReactiveValidationObject, IRoutableViewModel
    {
        public string? UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
        public IScreen HostScreen { get; }
        protected private IApplicationContext db;

        public ViewModelBase()
        {
            // db = Locator.Current.GetService<IApplicationContext>() ??
            //      throw new Exception("Can't locate context via locator");

            HostScreen = Locator.Current.GetService<IScreen>() ??
                         throw new Exception("Can't locate Screen via locator");
        }
    }
}
