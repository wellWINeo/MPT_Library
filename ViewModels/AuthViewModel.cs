using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Library.ViewModels;

public class AuthViewModel : ViewModelBase
{
    [Reactive] public string Email { get; set; }
    [Reactive] public string Password { get; set; }
    [Reactive] public bool IsNotAuthed { get; set; } = true;
    
    public ReactiveCommand<Unit, Unit> LoginCommnad { get; }
    public ReactiveCommand<Unit, Unit> GoToRecovery { get; }

    public AuthViewModel()
    {
        GoToRecovery = ReactiveCommand.CreateFromTask(async ()
                => await HostScreen.Router.Navigate.Execute(new RecoverViewModel())
                    .Select(_ => Unit.Default)
        );
        
        LoginCommnad = ReactiveCommand.CreateFromTask(async ()
            => await HostScreen.Router.Navigate.Execute(new IssueCertificateViewModel())
                .Select(_ => Unit.Default),
            this.WhenAnyValue(x => x.Email, y => y.Password,
                (x, y) => !string.IsNullOrWhiteSpace(x) && !string.IsNullOrWhiteSpace(y))
        );
    }
}