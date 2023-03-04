using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BindingExample;

internal class MainWindowViewModel : ObservableObject
{
    public MainWindowViewModel()
    {
        AddItem = new RelayCommand(AddItemImpl);
        DeleteItem = new RelayCommand<DataItem>(DeleteItemImpl);

        Data = new ObservableCollection<DataItem>(Enumerable.Range(0, 10).Select(i => new DataItem { Value = i }));
    }


    public RelayCommand AddItem { get; }
    public RelayCommand<DataItem> DeleteItem { get; }

    public ObservableCollection<DataItem> Data { get; }


    private void AddItemImpl()
    {
        Data.Add(new DataItem { Value = Random.Shared.Next(100) });
    }

    private void DeleteItemImpl(DataItem? item)
    {
        if (item is not null)
            Data.Remove(item);
    }
}

public record DataItem
{
    public required int Value { get; init; }
}