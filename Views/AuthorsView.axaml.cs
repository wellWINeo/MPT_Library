using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Library.ViewModels;

namespace Library.Views;

public partial class AuthorsView : ReactiveUserControl<AuthorsViewModel>
{
    public AuthorsView()
    {
        InitializeComponent();
    }
}