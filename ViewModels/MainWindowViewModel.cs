using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using Library.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace Library.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IScreen
    {
        [Reactive] public MenuState State { get; private set; }
        [Reactive] public bool IsStaff { get; private set; }
        public RoutingState Router { get; } = new();
        
        public AuthViewModel authViewModel { get; }
        public RecoverViewModel recoverViewModel { get; }
        
        public ReactiveCommand<Unit, Unit> GoToBooks { get; }
        public ReactiveCommand<Unit, Unit> GoToIssueCertificates { get; }
        public ReactiveCommand<Unit, Unit> GoToLibraries { get; }
        public ReactiveCommand<Unit, Unit> GoToBranches { get; }
        public ReactiveCommand<Unit, Unit> GoToEmployees { get; }

        public MainWindowViewModel()
        {
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
            authViewModel = new();
            recoverViewModel = new();
            // Router.Navigate.Execute(new AuthViewModel());
            
            this.WhenAnyValue(x => x.authViewModel.State)
                .Subscribe(x => State = x);

            this.WhenAnyValue(x => x.authViewModel.RoleState)
                .Subscribe(x => IsStaff = x == RoleState.Staff);

            GoToBooks = navigationToVM(new BooksViewModel());
            GoToIssueCertificates = navigationToVM(new IssueCertificateViewModel());
            GoToLibraries = navigationToVM(new LibraryViewModel());
            GoToBranches = navigationToVM(new BranchViewModel());
            GoToEmployees = navigationToVM(new EmployeeViewModel());
        }

        private ReactiveCommand<Unit, Unit> navigationToVM(IRoutableViewModel vm)
            => ReactiveCommand.CreateFromTask(async () =>
                await Router.Navigate.Execute(vm).Select(_ => Unit.Default));

    }
}
