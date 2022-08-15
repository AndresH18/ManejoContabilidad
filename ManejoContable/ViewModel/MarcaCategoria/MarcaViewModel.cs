using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using ModelEntities;

namespace ManejoContable.ViewModel.MarcaCategoria;

public class MarcaViewModel : IBaseViewModel<Marca>
{
    public ObservableCollection<Marca> Models { get; }

    public MarcaViewModel()
    {
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
        throw new System.NotImplementedException();
    }

    public void Delete(Marca t)
    {
        throw new System.NotImplementedException();
    }

    public void Edit(Marca t)
    {
        throw new System.NotImplementedException();
    }

    public void Create()
    {
        throw new System.NotImplementedException();
    }
}