using System.Collections.ObjectModel;
using System.ComponentModel;
using ManejoContable.ViewModel.Commands;
using ModelEntities;

namespace ManejoContable.ViewModel.MarcaCategoria;

public class CategoriaViewModel : IBaseViewModel<Categoria>, INotifyPropertyChanged
{
    public ObservableCollection<Categoria> Models { get; }


    public ViewCommand<Categoria> ViewCommand { get; }
    public CreateCommand<Categoria> CreateCommand { get; }
    public DeleteCommand<Categoria> DeleteCommand { get; }
    public EditCommand<Categoria> EditCommand { get; }

    private IDialogService<Categoria> _dialog;
    private Categoria? _marca;

    public Categoria? SelectedModel
    {
        get => _marca;
        set
        {
            _marca = value;
            NotifyPropertyChanged(nameof(SelectedModel));
        }
    }


    public CategoriaViewModel()
    {
        _dialog = new CategoriaDialogService();

        ViewCommand = new ViewCommand<Categoria>(this);
        CreateCommand = new CreateCommand<Categoria>(this);
        DeleteCommand = new DeleteCommand<Categoria>(this);
        EditCommand = new EditCommand<Categoria>(this);

        Models = new ObservableCollection<Categoria>
        {
            new()
            {
                Name = "Television", Description = "Televisores, pantallas grandes, etc"
            },
            new()
            {
                Name = "Radios", Description = "Radios, Telecomunicaciones"
            }
        };
    }

    public void Show(Categoria t)
    {
        _dialog.OpenInformationDialog(t);
    }

    public void Delete(Categoria t)
    {
        // TODO: use delete result
        var result = _dialog.DeleteDialog(t);
    }

    public void Edit(Categoria t)
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