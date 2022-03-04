using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Library.Services;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Library.ViewModels;

public class AuthViewModel : ViewModelBase
{
    [Reactive] public string Email { get; set; }
    [Reactive] public string Password { get; set; }
    [Reactive] public MenuState State { get; private set; }
    [Reactive] public RoleState RoleState { get; private set; }
    
    public ReactiveCommand<Unit, Unit> LoginCommnad { get; }
    public ReactiveCommand<Unit, MenuState> GoToRecovery { get; }
    
    /// <summary>
    /// ctor
    /// </summary>
    public AuthViewModel()
    {
        GoToRecovery = ReactiveCommand.Create(() => State = MenuState.Recover);
        LoginCommnad = ReactiveCommand.CreateFromTask(login,
            this.WhenAnyValue(x => x.Email, y => y.Password,
                (x, y) => !string.IsNullOrWhiteSpace(x) && !string.IsNullOrWhiteSpace(y)));
    }
    
    /// <summary>
    /// Мето для аутентификации
    /// </summary>
    private async Task login()
    {
        if (await db.Staves.FirstOrDefaultAsync(x
                => x.Email == Email && x.Password == Password)
            != null)
            RoleState = RoleState.Staff;
        else if (await db.Clients.FirstOrDefaultAsync(x
                     => x.Email == Email && x.Password == Password)
                 != null)
            RoleState = RoleState.Client;
        else
            RoleState = RoleState.NotAuth;

        if (RoleState != RoleState.NotAuth)
            State = MenuState.Menu;
    }
}