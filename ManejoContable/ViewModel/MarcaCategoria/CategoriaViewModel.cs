using System.Collections.ObjectModel;
using ModelEntities;

namespace ManejoContable.ViewModel.MarcaCategoria;

public class CategoriaViewModel : IBaseViewModel<Categoria>
{
    public ObservableCollection<Categoria> Models { get; }

    public CategoriaViewModel()
    {
        Models = new ObservableCollection<Categoria> { };
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