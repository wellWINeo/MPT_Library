using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Mixins;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Library.ViewModels;
using ReactiveUI;

namespace Library.Views;

public partial class BranchView : ReactiveUserControl<BranchViewModel>
{
    public BranchView()
    {
        InitializeComponent();

        this.WhenActivated(d =>
        {
            this.BindCommand(ViewModel, vm => vm.GoToReadRooms, view => view.GoToReadRooms)
                .DisposeWith(d);
        });
    }
}