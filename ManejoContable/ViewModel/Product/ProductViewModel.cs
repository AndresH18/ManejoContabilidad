using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using ManejoContable.ViewModel.Commands;
using ModelEntities;

namespace ManejoContable.ViewModel.Product;

public class ProductViewModel : IBaseViewModel<Producto>, INotifyPropertyChanged
{
    public ObservableCollection<Producto> Products { get; }
    private Producto? _producto;

    public ViewCommand<Producto> ViewProductCommand { get; }

    public Producto? SelectedProduct
    {
        get => _producto;
        set
        {
            _producto = value;
            NotifyPropertyChange(nameof(SelectedProduct));
        }
    }

    public ProductViewModel()
    {
        // if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
        // {
        //     Products = new ObservableCollection<Producto>();
        // }
        ViewProductCommand = new ViewCommand<Producto>(this);

        Products = new ObservableCollection<Producto>
        {
            new Producto() {Nombre = "Radio", Codigo = "rad-01", PrecioUnitario = 20.3M},
        };
    }

    public void Show(Producto t)
    {
        throw new NotImplementedException();
    }

    public void Delete(Producto t)
    {
        throw new NotImplementedException();
    }

    public void Edit(Producto t)
    {
        throw new NotImplementedException();
    }

    public void Create()
    {
        throw new NotImplementedException();
    }

    private void NotifyPropertyChange(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}