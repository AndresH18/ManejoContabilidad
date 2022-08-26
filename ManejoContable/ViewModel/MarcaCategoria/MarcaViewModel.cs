using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ManejoContable.ViewModel.Commands;
using ModelEntities;

namespace ManejoContable.ViewModel.MarcaCategoria;

public class MarcaViewModel : IBaseViewModel<Marca>, INotifyPropertyChanged
{
    public ObservableCollection<Marca> Models { get; }
    public ViewCommand<Marca> ViewCommand { get; }
    public CreateCommand<Marca> CreateCommand { get; }
    public DeleteCommand<Marca> DeleteCommand { get; }
    public EditCommand<Marca> EditCommand { get; }

    private readonly IDialogService<Marca> _dialog;
    private Marca? _model;

    public Marca? SelectedModel
    {
        get => _model;
        set
        {
            _model = value;
            NotifyPropertyChanged(nameof(SelectedModel));
        }
    }

    public MarcaViewModel()
    {
        _dialog = new MarcaDialogService();

        ViewCommand = new ViewCommand<Marca>(this);
        CreateCommand = new CreateCommand<Marca>(this);
        DeleteCommand = new DeleteCommand<Marca>(this);
        EditCommand = new EditCommand<Marca>(this);

        Models = new ObservableCollection<Marca>
        {
            new()
            {
                Name = "Samsung", Description = "Es samsung"
            },
            new()
            {
                Name = "Nokia", Description = "Los que hacias los celulared indestructibles"
            }
        };
    }

    public void Show(Marca t)
    {
        _dialog.OpenInformationDialog(t);
    }

    public void Delete(Marca t)
    {
        // TODO: use delete result
        var result = _dialog.DeleteDialog(t);
    }

    public void Edit(Marca t)
    {
        // TODO: use update result
        var result = _dialog.UpdateDialog(t);
    }

    public void Create()
    {
        // TODO: use Add result
        var result = _dialog.AddDialog();
    }

    private void NotifyPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}