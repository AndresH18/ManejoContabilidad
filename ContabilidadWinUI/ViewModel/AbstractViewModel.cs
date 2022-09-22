using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using ContabilidadWinUI.ViewModel.Commands;
using DbContextLibrary.Repository;
using Microsoft.UI.Xaml;
using ModelEntities;

namespace ContabilidadWinUI.ViewModel;

public abstract class AbstractViewModel<T> : IBaseViewModel<T>, ITaskRunning, INotifyPropertyChanged
    where T : class, IModel
{
    private readonly IRepository<T> _repo;

    private Visibility _taskVisibility;
    private bool _isError;

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

    public ObservableCollection<T> Models { get; private set; }
    public IModelDialogService<T> DialogService { get; }
    public ViewCommand<T> ViewCommand { get; }
    public CreateCommand<T> CreateCommand { get; }
    public DeleteCommand<T> DeleteCommand { get; }
    public EditCommand<T> EditCommand { get; }

    /// <summary>
    /// <p>
    /// Gets the <see cref="Visibility"/> based on the <see cref="_taskCounter"/>.
    /// </p>
    /// <p>
    /// This is used for bindings in which the user should know that there is an operation running
    /// </p>
    /// </summary>
    public Visibility TaskVisibility
    {
        get => _taskVisibility;
        private set
        {
            _taskVisibility = value;
            NotifyPropertyChanged(nameof(TaskVisibility));
        }
    }
    // public Visibility TaskVisibility => _taskCounter > 0 ? Visibility.Visible : Visibility.Collapsed;


    /// <summary>
    /// <p>
    /// Gets the error state from <see cref="_isError"/>.
    /// </p>
    /// <p>This is used for bindings in which the user should know that an operation was unsuccessful</p>
    /// </summary>
    public bool IsTaskError
    {
        get => _isError;
        private set
        {
            _isError = value;
            NotifyPropertyChanged(nameof(IsTaskError));
        }
    }

    public AbstractViewModel()
    {
        ViewCommand = new ViewCommand<T>(this);
        CreateCommand = new CreateCommand<T>(this);
        DeleteCommand = new DeleteCommand<T>(this);
        EditCommand = new EditCommand<T>(this);

        GetData();
    }

    private async void GetData()
    {
        TaskVisibility = Visibility.Visible;
        try
        {
            var data = await Task.Run(() => _repo.GetAllAsync());
            Models = new ObservableCollection<T>(data);
            NotifyPropertyChanged(nameof(Models));
            TaskVisibility = Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            IsTaskError = true;
        }
    }

    public virtual void Show(T t)
    {
        DialogService.ShowDialog(t);
    }

    public virtual async void Delete(T t)
    {
        TaskVisibility = Visibility.Visible;

        var delete = await DialogService.DeleteDialog(t);

        if (!delete)
            return;

        try
        {
            SelectedModel = null;
            Models.Remove(t);
            await Task.Run(() => _repo.DeleteAsync(t.Id));
            TaskVisibility = Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            IsTaskError = true;
        }
    }

    public virtual async void Edit(T t)
    {
        TaskVisibility = Visibility.Visible;

        var p = await DialogService.UpdateDialog(t);
        if (p is null)
            return;

        SelectedModel = null;

        t.CopyFrom(p);

        try
        {
            var collection = await Task.Run(async () =>
            {
                await _repo.UpdateAsync(t);

                return await _repo.GetAllAsync();
            });

            Models = new ObservableCollection<T>(collection);

            NotifyPropertyChanged(nameof(Models));

            SelectedModel = t;
            TaskVisibility = Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            IsTaskError = true;
        }
    }

    public virtual async void Create()
    {
        TaskVisibility = Visibility.Visible;

        var c = await DialogService.CreateDialog();

        if (c is null)
            return;
        try
        {
            c = await Task.Run(async () =>
            {
                var ac = await _repo.CreateAsync(c);
                ac = await _repo.GetByIdAsync(ac.Id);
                return ac;
            });

            Models.Add(c!);
            TaskVisibility = Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating. {ex}");
            IsTaskError = true;
        }
    }

    protected void NotifyPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}