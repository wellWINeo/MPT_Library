using System.Collections.Generic;
using System.Collections.ObjectModel;
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
public partial class GenresView : ReactiveUserControl<GenresViewModel>
{
    public GenresView()
    {
        InitializeComponent();

        this.WhenActivated(d =>
        {
            this.BindCommand(ViewModel, vm => vm.GoToBooks, view => view.GoToBooksButton)
                .DisposeWith(d);

            this.BindCommand(ViewModel, vm => vm.AddCommand, view => view.AddButton)
                .DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.UpdateCommand, view => view.ChangeButton)
                .DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.DeleteCommand, view => view.RemoveButton)
                .DisposeWith(d);

            this.Bind(ViewModel, vm => vm.SelectedIdx, view => view.Grid.SelectedIndex)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Name, view => view.Name.Text)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Genres, view => view.Grid.Items,
                    value => value as IEnumerable<Genre>,
                    value => value as ObservableCollection<Genre>)
                .DisposeWith(d);
        });
    }

    private void DataGrid_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        Name.Text = (Grid.SelectedItem as Genre)?.Name;
    }
}