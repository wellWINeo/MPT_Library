using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Library.ViewModels;

namespace Library.Views;

public partial class SecondView : ReactiveUserControl<SecondViewModel>
{
    public SecondView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}