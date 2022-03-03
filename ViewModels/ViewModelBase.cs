using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using Library.Services;
using ReactiveUI;
using ReactiveUI.Validation.Helpers;
using Splat;

namespace Library.ViewModels;

public class ViewModelBase : ReactiveValidationObject, IRoutableViewModel
{
    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
    public IScreen HostScreen { get; }
    protected private ApplicationContext db;

    public ViewModelBase()
    {
        db = Locator.Current.GetService<ApplicationContext>() ??
             throw new Exception("Can't locate context via locator");

        HostScreen = Locator.Current.GetService<IScreen>() ??
                     throw new Exception("Can't locate Screen via locator");
    }

    protected ReactiveCommand<Unit, Unit> _naviToVM(IRoutableViewModel vm)
        => ReactiveCommand.CreateFromTask(async () =>
            await HostScreen.Router.Navigate.Execute(vm).Select(_ => Unit.Default));
}
