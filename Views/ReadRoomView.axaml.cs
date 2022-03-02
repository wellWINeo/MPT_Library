using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Library.ViewModels;

namespace Library.Views;

public partial class ReadRoomView : ReactiveUserControl<ReadRoomViewModel>
{
    public ReadRoomView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}