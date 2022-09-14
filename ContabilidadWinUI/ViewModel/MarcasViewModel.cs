using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using ContabilidadWinUI.ViewModel.Commands;
using DbContextLibrary.Repository;
using Microsoft.Extensions.DependencyInjection;
using ModelEntities;

namespace ContabilidadWinUI.ViewModel;

public class MarcasViewModel : IBaseViewModel<Marca>, INotifyPropertyChanged
{
    private IMarcaRepository _repo;
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

        Models = new ObservableCollection<Marca>(_repo.GetAll());
    }

    public async void Create()
    {
        var c = await DialogService.CreateDialog();

        if (c is null)
            return;

        c = _repo.Create(c);

        Models.Add(c);
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
            _repo.Update(marca);
            Models = new ObservableCollection<Marca>(_repo.GetAll());
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
            _repo.Delete(t.Id);
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