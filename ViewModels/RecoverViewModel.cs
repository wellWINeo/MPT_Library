using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Library.ViewModels;

public class RecoverViewModel : ViewModelBase
{
    [Reactive] public string Email { get; set; }
    
    public ReactiveCommand<Unit, Unit> SendPassword { get; }
    public ReactiveCommand<Unit, Unit> Login { get; }
    
    /// <summary>
    /// ctor
    /// </summary>
    public RecoverViewModel()
    {
        Login = ReactiveCommand.CreateFromTask(async () =>
            await HostScreen.Router.Navigate.Execute(new AuthViewModel()).Select(_ => Unit.Default)
        );
    }
}