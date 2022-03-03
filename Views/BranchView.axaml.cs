using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Mixins;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Library.Helper;
using Library.Models;
using Library.ViewModels;
using PropertyChanged;
using ReactiveUI;

namespace Library.Views;

[DoNotNotify]
public partial class BranchView : ReactiveUserControl<BranchViewModel>
{
    public BranchView()
    {
        InitializeComponent();

        this.WhenActivated(d =>
        {
            this.BindCommand(ViewModel, vm => vm.GoToReadRooms, view => view.GoToReadRooms)
                .DisposeWith(d);
            
            this.BindCommand(ViewModel, vm => vm.AddCommand, view => view.AddButton)
                .DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.UpdateCommand, view => view.ChangeButton)
                .DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.DeleteCommand, view => view.RemoveButton)
                .DisposeWith(d);

            this.Bind(ViewModel, vm => vm.SelectedIdx, view => view.Grid.SelectedIndex)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.SelectedLibraryIdx, view => view.Library.SelectedIndex)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Address, view => view.Address.Text)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Number, view => view.Number.Value)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.OpenTime, view => view.OpenTime.SelectedTime,
                    viewToVMConverterOverride: new TimeSpanToTimeOnlyBindingConverter(),
                    vmToViewConverterOverride: new TimeOnlyToTimeSpanBindingConverter())
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.CloseTime, view => view.CloseTime.SelectedTime,
                    viewToVMConverterOverride: new TimeSpanToTimeOnlyBindingConverter(),
                    vmToViewConverterOverride: new TimeOnlyToTimeSpanBindingConverter())
                .DisposeWith(d);

            this.Bind(ViewModel, vm => vm.Libraries, view => view.Library.Items,
                    value => value as IEnumerable<Models.Library>,
                    value => value as ObservableCollection<Models.Library>)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Branches, view => view.Grid.Items,
                    value => value as IEnumerable<Branch>,
                    value => value as ObservableCollection<Branch>)
                .DisposeWith(d);
        });
    }
}