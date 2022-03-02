using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Mixins;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Library.ViewModels;
using ReactiveUI;

namespace Library.Views;

public partial class OneView : ReactiveUserControl<OneViewModel>
{
    public OneView()
    {
        InitializeComponent();
        this.WhenActivated(disposables =>
        {
            this.BindCommand(ViewModel, vm => vm.GoToSecond,
                    view => view.SecondButton)
                .DisposeWith(disposables);
            this.BindCommand(ViewModel, vm => vm.GoToThird,
                    view => view.ThirdButton)
                .DisposeWith(disposables);
        });
    }
}