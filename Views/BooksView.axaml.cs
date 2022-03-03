using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Mixins;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Library.ViewModels;
using ReactiveUI;

namespace Library.Views;

public partial class BooksView : ReactiveUserControl<BooksViewModel>
{
    public BooksView()
    {
        InitializeComponent();

        this.WhenActivated(d =>
        {
            this.BindCommand(ViewModel, vm => vm.GoToAuthors, view => view.AuthorsButton)
                .DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.GoToGenres, view => view.GenresButton)
                .DisposeWith(d);
        });
    }
}