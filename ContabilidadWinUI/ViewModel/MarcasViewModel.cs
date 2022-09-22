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
using Exception = System.Exception;

namespace ContabilidadWinUI.ViewModel;

public class MarcasViewModel : IBaseViewModel<Marca>, INotifyPropertyChanged
{
    private readonly IMarcaRepository _repo;
    private Marca? _marca;
    private Visibility _taskVisibility;
    private bool _isError;

    public Marca? SelectedModel
    {
        get => _marca;
        set
        {
            _marca = value;
            NotifyPropertyChanged(nameof(SelectedModel));
        }
    }

    public ObservableCollection<Marca> Models { get; private set; }
    public IModelDialogService<Marca> DialogService { get; }
    public ViewCommand<Marca> ViewCommand { get; }
    public CreateCommand<Marca> CreateCommand { get; }
    public DeleteCommand<Marca> DeleteCommand { get; }
    public EditCommand<Marca> EditCommand { get; }

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

    public MarcasViewModel()
    {
        _repo = App.Current.Services.GetService<IMarcaRepository>() ??
                throw new ArgumentNullException($"Service {typeof(IMarcaRepository)} is not registered");

        DialogService = new MarcaDialogService();

        ViewCommand = new ViewCommand<Marca>(this);
        CreateCommand = new CreateCommand<Marca>(this);
        DeleteCommand = new DeleteCommand<Marca>(this);
        EditCommand = new EditCommand<Marca>(this);

        GetData();
    }

    private async void GetData()
    {
        TaskVisibility = Visibility.Visible;
        try
        {
            var data = await Task.Run(() => _repo.GetAllAsync());
            Models = new ObservableCollection<Marca>(data);
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

            Models.Add(c!);
            TaskVisibility = Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating. {ex}");
            IsTaskError = true;
        }
    }

    public void Show(Marca t)
    {
        DialogService.ShowDialog(t);
    }


    public async void Edit(Marca marca)
    {
        TaskVisibility = Visibility.Visible;
        var m = await DialogService.UpdateDialog(marca);
        if (m is null)
            return;

        SelectedModel = null;

        marca.CopyFrom(m);

        try
        {
            var collection = await Task.Run(async () =>
            {
                await _repo.UpdateAsync(marca);

                return await _repo.GetAllAsync();
            });

            Models = new ObservableCollection<Marca>(collection);

            NotifyPropertyChanged(nameof(Models));

            SelectedModel = marca;

            TaskVisibility = Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            IsTaskError = true;
        }
    }

    public async void Delete(Marca t)
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

    private void NotifyPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}