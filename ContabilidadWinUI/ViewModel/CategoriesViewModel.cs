using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using ContabilidadWinUI.ViewModel.Commands;
using DbContextLibrary.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using ModelEntities;

namespace ContabilidadWinUI.ViewModel;

public class CategoriesViewModel : IBaseViewModel<Categoria>, ITaskRunning, INotifyPropertyChanged
{
    private readonly ICategoriaRepository _repo;

    private Visibility _taskVisibility;
    private bool _isError;
    private Categoria? _categoria;

    public ObservableCollection<Categoria> Models { get; private set; }

    public Categoria? SelectedModel
    {
        get => _categoria;
        set
        {
            _categoria = value;
            NotifyPropertyChanged(nameof(SelectedModel));
        }
    }


    public IModelDialogService<Categoria> DialogService { get; }
    public ViewCommand<Categoria> ViewCommand { get; }
    public CreateCommand<Categoria> CreateCommand { get; }
    public DeleteCommand<Categoria> DeleteCommand { get; }
    public EditCommand<Categoria> EditCommand { get; }

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

    public CategoriesViewModel()
    {
        _repo = App.Current.Services.GetService<ICategoriaRepository>() ??
                throw new ArgumentNullException($"Service {typeof(ICategoriaRepository)} is not registered");

        DialogService = new CategoriaDialogService();

        ViewCommand = new ViewCommand<Categoria>(this);
        CreateCommand = new CreateCommand<Categoria>(this);
        DeleteCommand = new DeleteCommand<Categoria>(this);
        EditCommand = new EditCommand<Categoria>(this);

        GetData();
    }

    private async void GetData()
    {
        TaskVisibility = Visibility.Visible;
        try
        {
            var data = await Task.Run(() => _repo.GetAllAsync());
            Models = new ObservableCollection<Categoria>(data);
            NotifyPropertyChanged(nameof(Models));
            TaskVisibility = Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            IsTaskError = true;
        }
    }

    public async void Create()
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

            TaskVisibility = Visibility.Collapsed;
            Models.Add(c!);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating. {ex}");
            IsTaskError = true;
        }
    }

    public void Show(Categoria t)
    {
        DialogService.ShowDialog(t);
    }

    public async void Edit(Categoria categoria)
    {
        TaskVisibility = Visibility.Visible;
        var result = await DialogService.UpdateDialog(categoria);
        if (result is null)
            return;

        SelectedModel = null;

        categoria.CopyFrom(result);

        try
        {
            var collection = await Task.Run(async () =>
            {
                await _repo.UpdateAsync(categoria);

                return await _repo.GetAllAsync();
            });

            Models = new ObservableCollection<Categoria>(collection);

            NotifyPropertyChanged(nameof(Models));

            SelectedModel = categoria;
            TaskVisibility = Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            IsTaskError = true;
        }
    }

    public async void Delete(Categoria t)
    {
        TaskVisibility = Visibility.Visible;
        var delete = await DialogService.DeleteDialog(t);

        if (!delete)
            return;

        SelectedModel = null;
        Models.Remove(t);
        try
        {
            await Task.Run(() => _repo.DeleteAsync(t.Id));
            TaskVisibility = Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            IsTaskError = true;
        }
    }

    private void NotifyPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}