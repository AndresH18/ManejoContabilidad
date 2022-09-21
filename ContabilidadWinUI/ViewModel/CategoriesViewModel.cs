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

public class CategoriesViewModel : IBaseViewModel<Categoria>, INotifyPropertyChanged
{
    private readonly ICategoriaRepository _repo;

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
        var data = await Task.Run(() => _repo.GetAllAsync());
        Models = new ObservableCollection<Categoria>(data);
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

    public void Show(Categoria t)
    {
        DialogService.ShowDialog(t);
    }


    public async void Edit(Categoria categoria)
    {
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
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }


    public async void Delete(Categoria t)
    {
        var delete = await DialogService.DeleteDialog(t);

        if (!delete)
            return;

        SelectedModel = null;
        Models.Remove(t);
        try
        {
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