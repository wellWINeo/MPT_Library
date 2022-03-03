using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Library.ViewModels;
using PropertyChanged;

namespace Library.Views;

[DoNotNotify]
public partial class IssueCertificateView : ReactiveUserControl<IssueCertificateViewModel>
{
    public IssueCertificateView()
    {
        InitializeComponent();
    }
}