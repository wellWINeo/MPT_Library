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
public partial class LibraryView : ReactiveUserControl<LibraryViewModel>
{
    public LibraryView()
    {
        InitializeComponent();
        
        this.WhenActivated(d =>
        {
            this.BindCommand(ViewModel, vm => vm.GoToReadRooms, view => view.GoToReadRooms)
                .DisposeWith(d);
        });
    }
}