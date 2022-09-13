using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ContabilidadWinUI.ViewModel.Commands;
using ModelEntities;

namespace ContabilidadWinUI.ViewModel;

public abstract class AbstractViewModel<T> : IBaseViewModel<T>, INotifyPropertyChanged
{
    protected T? Model;

    public T? SelectedModel
    {
        get => Model;
        set
        {
            Model = value;
            NotifyPropertyChanged(nameof(SelectedModel));
        }
    }

    public ObservableCollection<T> Models { get; }
    public IModelDialogService<T> DialogService { get; }
    public ViewCommand<T> ViewCommand { get; }
    public CreateCommand<T> CreateCommand { get; }
    public DeleteCommand<T> DeleteCommand { get; }
    public EditCommand<T> EditCommand { get; }


    public void Show(T t)
    {
        throw new System.NotImplementedException();
    }

    public void Delete(T t)
    {
        throw new System.NotImplementedException();
    }

    public void Edit(T t)
    {
        throw new System.NotImplementedException();
    }

    public void Create()
    {
        throw new System.NotImplementedException();
    }

    private void NotifyPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}