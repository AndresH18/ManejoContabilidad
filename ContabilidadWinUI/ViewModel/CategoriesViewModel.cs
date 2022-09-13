using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ContabilidadWinUI.ViewModel.Commands;
using DbContextLibrary.Repository;
using Microsoft.Extensions.DependencyInjection;
using ModelEntities;

namespace ContabilidadWinUI.ViewModel;

public class CategoriesViewModel : IBaseViewModel<Categoria>, INotifyPropertyChanged
{
    private Categoria? _categoria;
    private ICategoriaRepository _repo;

    public ObservableCollection<Categoria> Models { get; }

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

        Models = new ObservableCollection<Categoria>(_repo.GetAll());
    }

    public async void Create()
    {
        var c = await DialogService.CreateDialog();

        if (c is null)
            return;

        c = _repo.Create(c);

        Models.Add(c);
    }

    public void Show(Categoria t)
    {
        DialogService.ShowDialog(t);
    }


    public async void Edit(Categoria t)
    {
        var c = await DialogService.UpdateDialog(t);
        if (c is null)
            return;

        _repo.Update(c);

        Models.Remove(SelectedModel!);
        Models.Add(c);
        SelectedModel = c;
    }

    public async void Delete(Categoria t)
    {
        var delete = await DialogService.DeleteDialog(t);

        if (!delete)
            return;

        SelectedModel = null;
        Models.Remove(t);
        _repo.Delete(t.Id);
    }

    private void NotifyPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}