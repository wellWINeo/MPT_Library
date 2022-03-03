using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Mixins;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Library.Models;
using Library.ViewModels;
using PropertyChanged;
using ReactiveUI;

namespace Library.Views;

[DoNotNotify]
public partial class ReadRoomView : ReactiveUserControl<ReadRoomViewModel>
{
    public ReadRoomView()
    {
        InitializeComponent();

        this.WhenActivated(d =>
        {
            this.BindCommand(ViewModel, vm => vm.GoBack, view => view.GoBack)
                .DisposeWith(d);
            
            this.BindCommand(ViewModel, vm => vm.AddCommand, view => view.AddButton)
                .DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.UpdateCommand, view => view.ChangeButton)
                .DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.DeleteCommand, view => view.RemoveButton)
                .DisposeWith(d);

            this.Bind(ViewModel, vm => vm.SelectedIdx, view => view.Grid.SelectedIndex)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Number, view => view.Number.Value)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.SeatsCount, view => view.SeatsCount.Value)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.ReadingRooms, view => view.Grid.Items,
                    value => value as IEnumerable<ReadingRoom>,
                    value => value as ObservableCollection<ReadingRoom>)
                .DisposeWith(d);
        });
    }

    private void Grid_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        Number.Value = (Grid.SelectedItem as ReadingRoom)?.Number ?? 0;
        SeatsCount.Value = (Grid.SelectedItem as ReadingRoom)?.SeatsCount ?? 0;
    }
}