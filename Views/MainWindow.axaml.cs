using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using System.Reactive.Disposables;
using Library.ViewModels;
using ReactiveUI;

namespace Library.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WhenActivated(disposables =>
            {
                this.Bind(ViewModel, vm => vm.Router, view => view.ViewHost.Router)
                    .DisposeWith(disposables);
            });
#if DEBUG
            this.AttachDevTools();
#endif
        }

    }
}