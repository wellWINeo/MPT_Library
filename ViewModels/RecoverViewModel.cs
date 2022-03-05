using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Library.Services;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace Library.ViewModels;

public class RecoverViewModel : ViewModelBase
{
    [Reactive] public string Email { get; set; }
    
    public ReactiveCommand<Unit, Unit> SendPassword { get; }
    public ReactiveCommand<Unit, Unit> Login { get; }

    private IEmailRecoverService _recoverService { get; }
    
    /// <summary>
    /// ctor
    /// </summary>
    public RecoverViewModel()
    {
        _recoverService = Locator.Current.GetService<IEmailRecoverService>() ??
                          throw new Exception("can't locate email recovery service via locator");
        
        Login = ReactiveCommand.CreateFromTask(async () =>
            await HostScreen.Router.Navigate.Execute(new AuthViewModel()).Select(_ => Unit.Default)
        );
        SendPassword = ReactiveCommand.CreateFromTask(async () =>
        {
            await _recoverService.Recover(Email);
        });
    }

    private async Task reset()
    {
        await _recoverService.Recover(Email);
    }
    
    
}