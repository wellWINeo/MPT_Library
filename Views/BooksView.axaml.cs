using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Library.ViewModels;

namespace Library.Views;

public partial class BooksView : ReactiveUserControl<BooksViewModel>
{
    public BooksView()
    {
        InitializeComponent();
    }
}