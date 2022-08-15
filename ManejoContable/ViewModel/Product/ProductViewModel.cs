using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using ManejoContable.ViewModel.Commands;
using ModelEntities;

namespace ManejoContable.ViewModel.Product;

public class ProductViewModel : IBaseViewModel<Producto>, INotifyPropertyChanged
{
    public ObservableCollection<Producto> Models { get; }

    public ViewCommand<Producto> ViewCommand { get; }
    public CreateCommand<Producto> CreateCommand { get; }
    public DeleteCommand<Producto> DeleteCommand { get; }
    public EditCommand<Producto> EditCommand { get; }

    private IDialogService<Producto> _dialog;
    private Producto? _producto;

    public Producto? SelectedModel
    {
        get => _producto;
        set
        {
            _producto = value;
            NotifyPropertyChange(nameof(SelectedModel));
        }
    }

    public ProductViewModel()
    {
        // if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
        // {
        //     Models = new ObservableCollection<Producto>();
        // }

        _dialog = new ProductDialogService();

        ViewCommand = new ViewCommand<Producto>(this);
        CreateCommand = new CreateCommand<Producto>(this);
        DeleteCommand = new DeleteCommand<Producto>(this);
        EditCommand = new EditCommand<Producto>(this);


        Models = new ObservableCollection<Producto>
        {
            new Producto() {Nombre = "Radio", Codigo = "rad-01", PrecioUnitario = 20.3M},
        };
    }

    public void Show(Producto t)
    {
        Debug.WriteLine($"{nameof(Show)}: Showing Information");
        _dialog.OpenInformationDialog(t);
    }

    public void Delete(Producto t)
    {
        Debug.WriteLine($"{nameof(Delete)}: Prompt to Delete");
        // TODO: use result
        var result = _dialog.DeleteDialog(t);
    }

    public void Edit(Producto t)
    {
        Debug.WriteLine($"{nameof(Edit)}: Prompt to Edit");
        // TODO: use result
        var result = _dialog.UpdateDialog(t);
    }

    public void Create()
    {
        Debug.WriteLine($"{nameof(Create)}: Prompt to Create");
        // TODO: use result
        var result = _dialog.AddDialog();
    }

    private void NotifyPropertyChange(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}