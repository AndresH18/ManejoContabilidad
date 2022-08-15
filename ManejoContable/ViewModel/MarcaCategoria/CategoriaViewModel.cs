using System.Collections.ObjectModel;
using ManejoContable.ViewModel.Commands;
using ModelEntities;

namespace ManejoContable.ViewModel.MarcaCategoria;

public class CategoriaViewModel : IBaseViewModel<Categoria>
{
    public ObservableCollection<Categoria> Models { get; }

    public Categoria? SelectedModel { get; set; }

    public ViewCommand<Categoria> ViewCommand { get; }
    public CreateCommand<Categoria> CreateCommand { get; }
    public DeleteCommand<Categoria> DeleteCommand { get; }
    public EditCommand<Categoria> EditCommand { get; }

    public CategoriaViewModel()
    {
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
        throw new System.NotImplementedException();
    }

    public void Delete(Categoria t)
    {
        throw new System.NotImplementedException();
    }

    public void Edit(Categoria t)
    {
        throw new System.NotImplementedException();
    }

    public void Create()
    {
        throw new System.NotImplementedException();
    }
}