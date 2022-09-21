using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using ContabilidadWinUI.ViewModel.Commands;
using DbContextLibrary.Repository;
using Microsoft.Extensions.DependencyInjection;
using ModelEntities;

namespace ContabilidadWinUI.ViewModel;

public class MarcasViewModel : IBaseViewModel<Marca>, INotifyPropertyChanged
{
    private readonly IMarcaRepository _repo;
    private Marca? _marca;

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
        var data = await Task.Run(() => _repo.GetAllAsync());
        Models = new ObservableCollection<Marca>(data);
        NotifyPropertyChanged(nameof(Models));
    }


    public async void Create()
    {
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
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating. {ex}");
        }
    }

    public void Show(Marca t)
    {
        DialogService.ShowDialog(t);
    }


    public async void Edit(Marca marca)
    {
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
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }

    public async void Delete(Marca t)
    {
        var delete = await DialogService.DeleteDialog(t);

        if (!delete)
            return;
        try
        {
            SelectedModel = null;
            Models.Remove(t);
            await Task.Run(() => _repo.DeleteAsync(t.Id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }

    private void NotifyPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}