using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using System.Reactive.Disposables;
using Library.Services;
using Library.ViewModels;
using PropertyChanged;
using ReactiveUI;

namespace Library.Views;

[DoNotNotify]
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(disposables =>
        {
            this.Bind(ViewModel, vm => vm.Router, view => view.ViewHost.Router)
                .DisposeWith(disposables);

            this.Bind(ViewModel, vm => vm.State, view => view.AuthView.IsVisible,
                state => state == MenuState.Auth, 
                visible => visible ? MenuState.Auth : MenuState.Menu)
                .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.State, view => view.RecoverView.IsVisible,
                state => state == MenuState.Recover,
                visible => visible ? MenuState.Recover : MenuState.Auth)
                .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.State, view => view.Menu.IsVisible,
                state => state == MenuState.Menu,
                visible => visible ? MenuState.Menu : MenuState.Auth)
                .DisposeWith(disposables);
            
            // Lock button by Role
            this.Bind(ViewModel, vm => vm.IsStaff, view => view.GoToLibraries.IsVisible)
                .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.IsStaff, view => view.GoToBranches.IsVisible)
                .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.IsStaff, view => view.GoToEmployees.IsVisible)
                .DisposeWith(disposables);

            this.BindCommand(ViewModel, vm => vm.GoToBooks, view => view.GoToBooks)
                .DisposeWith(disposables);
            this.BindCommand(ViewModel, vm => vm.GoToIssueCertificates, view => view.GoToIssueCertificates)
                .DisposeWith(disposables);
            this.BindCommand(ViewModel, vm => vm.GoToLibraries, view => view.GoToLibraries)
                .DisposeWith(disposables);
            this.BindCommand(ViewModel, vm => vm.GoToBranches, view => view.GoToBranches)
                .DisposeWith(disposables);
            this.BindCommand(ViewModel, vm => vm.GoToEmployees, view => view.GoToEmployees)
                .DisposeWith(disposables);
        });
#if DEBUG
        this.AttachDevTools();
#endif
    }

}