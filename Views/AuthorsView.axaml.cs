using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Mixins;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Library.ViewModels;
using ReactiveUI;

namespace Library.Views;

public partial class AuthorsView : ReactiveUserControl<AuthorsViewModel>
{
    public AuthorsView()
    {
        InitializeComponent();

        this.WhenActivated(d =>
        {
            this.BindCommand(ViewModel, vm => vm.GoToBooks, view => view.GoToBooksButton)
                .DisposeWith(d);
        });
    }
}