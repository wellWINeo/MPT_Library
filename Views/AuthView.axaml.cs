using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Mixins;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Library.ViewModels;
using ReactiveUI;
using Splat;

namespace Library.Views;

public partial class AuthView : ReactiveUserControl<AuthViewModel>
{
    public AuthView()
    {
        InitializeComponent();

        this.WhenActivated(d =>
        {
            this.Bind(ViewModel, vm => vm.Email, view => view.EmailBox.Text)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Password, view => view.PasswordBox.Text)
                .DisposeWith(d);

            this.BindCommand(ViewModel, vm => vm.GoToRecovery, view => view.ForgotButton)
                .DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.LoginCommnad, view => view.LoginButton)
                .DisposeWith(d);
        });
    }
}