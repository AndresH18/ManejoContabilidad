using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using ModelEntities;

namespace ManejoContable.ViewModel.Product;

public class ProductViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Producto> Products { get; }
    private Producto? _producto;

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
        Products = new ObservableCollection<Producto>
        {
            new Producto() { Nombre = "Radio", Codigo = "rad-01", PrecioUnitario = 20.3M },
        };
    }

    private void NotifyPropertyChange(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}