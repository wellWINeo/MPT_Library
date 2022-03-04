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
public partial class LibraryView : ReactiveUserControl<LibraryViewModel>
{
    
    /// <summary>
    /// ctor
    /// </summary>
    public LibraryView()
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
            this.Bind(ViewModel, vm => vm.SelectedReadingRoomIdx, view => view.ReadRoom.SelectedIndex)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Address, view => view.Address.Text)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.OpenTime, view => view.OpenTime.SelectedTime,
                    viewToVMConverterOverride: new TimeSpanToTimeOnlyBindingConverter(),
                    vmToViewConverterOverride: new TimeOnlyToTimeSpanBindingConverter())
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.CloseTime, view => view.CloseTime.SelectedTime,
                    viewToVMConverterOverride: new TimeSpanToTimeOnlyBindingConverter(),
                    vmToViewConverterOverride: new TimeOnlyToTimeSpanBindingConverter())
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.PhoneNumber, view => view.PhoneNumber.Text)
                .DisposeWith(d);
            
            this.Bind(ViewModel, vm => vm.Libraries, view => view.Grid.Items,
                    value => value as IEnumerable<Models.Library>,
                    value => value as ObservableCollection<Models.Library>)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.ReadingRooms, view => view.ReadRoom.Items,
                    value => value as IEnumerable<ReadingRoom>,
                    value => value as ObservableCollection<ReadingRoom>)
                .DisposeWith(d);
        });
    }

    /// <summary>
    /// изменение значений при выборе записи в таблице
    /// </summary>
    /// <param name="sender">Event raiser</param>
    /// <param name="e">Arguments</param>
    private void Grid_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (Grid.SelectedItem == null) return;
        var library = Grid.SelectedItem as Models.Library;
        Address.Text = library.Address;
        OpenTime.SelectedTime = library.OpenTime.ToTimeSpan();
        CloseTime.SelectedTime = library.CloseTime.ToTimeSpan();
        PhoneNumber.Text = library.PhoneNumber;
    }
}