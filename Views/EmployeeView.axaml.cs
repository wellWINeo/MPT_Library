using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Library.ViewModels;
using PropertyChanged;

namespace Library.Views;

[DoNotNotify]
public partial class EmployeeView : ReactiveUserControl<EmployeeViewModel>
{
    public EmployeeView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}