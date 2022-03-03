using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Mixins;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Library.ViewModels;
using ReactiveUI;

namespace Library.Views;

public partial class ReadRoomView : ReactiveUserControl<ReadRoomViewModel>
{
    public ReadRoomView()
    {
        InitializeComponent();

        this.WhenActivated(d =>
        {
            this.BindCommand(ViewModel, vm => vm.GoBack, view => view.GoBack)
                .DisposeWith(d);
        });
    }
}