using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ContabilidadWinUI.ViewModel.Commands;
using DbContextLibrary.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using ModelEntities;

namespace ContabilidadWinUI.ViewModel;

public class ClientsViewModel : IBaseViewModel<Cliente>, INotifyPropertyChanged
{
    private readonly IClienteRepository _repo;

    private Cliente? _model;
    private Visibility _taskVisibility;
    private bool _isError;
    public ObservableCollection<Cliente> Models { get; private set; }

    public Cliente? SelectedModel
    {
        get => _model;
        set
        {
            _model = value;
            NotifyPropertyChanged(nameof(SelectedModel));
        }
    }

    public IModelDialogService<Cliente> DialogService { get; }

    public ViewCommand<Cliente> ViewCommand { get; }
    public CreateCommand<Cliente> CreateCommand { get; }
    public DeleteCommand<Cliente> DeleteCommand { get; }
    public EditCommand<Cliente> EditCommand { get; }

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

    public ClientsViewModel()
    {
        _repo = App.Current.Services.GetService<IClienteRepository>() ??
                throw new ArgumentNullException($"Service {typeof(IClienteRepository)} is not registered");

        DialogService = new ClientDialogService();

        ViewCommand = new ViewCommand<Cliente>(this);
        CreateCommand = new CreateCommand<Cliente>(this);
        DeleteCommand = new DeleteCommand<Cliente>(this);
        EditCommand = new EditCommand<Cliente>(this);

        GetData();
    }

    private async void GetData()
    {
        TaskVisibility = Visibility.Visible;
        try
        {
            var data = await Task.Run(() => _repo.GetAllAsync());
            Models = new ObservableCollection<Cliente>(data);

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
            Debug.WriteLine(ex);
            IsTaskError = true;
        }
    }

    public void Show(Cliente t)
    {
        DialogService.ShowDialog(t);
    }

    public async void Edit(Cliente cliente)
    {
        TaskVisibility = Visibility.Visible;
        var c = await DialogService.UpdateDialog(cliente);
        if (c is null)
            return;

        SelectedModel = null;

        cliente.CopyFrom(c);

        try
        {
            var collection = await Task.Run(async () =>
            {
                await _repo.UpdateAsync(cliente);

                return await _repo.GetAllAsync();
            });

            Models = new ObservableCollection<Cliente>(collection);

            NotifyPropertyChanged(nameof(Models));

            SelectedModel = cliente;

            TaskVisibility = Visibility.Collapsed;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            IsTaskError = true;
        }
    }

    public async void Delete(Cliente t)
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


    private void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}