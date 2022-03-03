using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Mixins;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Library.ViewModels;
using PropertyChanged;
using ReactiveUI;

namespace Library.Views;

[DoNotNotify]
public partial class RecoverView : ReactiveUserControl<RecoverViewModel>
{
    public RecoverView()
    {
        InitializeComponent();

        this.WhenActivated(d =>
        {
            this.Bind(ViewModel, vm => vm.Email, view => view.EmailBox.Text)
                .DisposeWith(d);

            this.BindCommand(ViewModel, vm => vm.Login, view => view.Login)
                .DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.SendPassword, view => view.SendPassword)
                .DisposeWith(d);
        });
    }
}