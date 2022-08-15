using System;
using System.Windows;
using ManejoContable.View.Windows.Client;
using ManejoContable.View.Windows.MarcaCategoria;
using ManejoContable.View.Windows.Product;
using ModelEntities;

namespace ManejoContable.ViewModel;

public interface IDialogService<T>
{
    public void OpenInformationDialog(T t);
    public bool DeleteDialog(T t);
    public T? UpdateDialog(T t);
    public T? AddDialog();
}

public class ClientDialogService : IDialogService<Cliente>
{
    public void OpenInformationDialog(Cliente cliente)
    {
        ClientWindow.CreateViewClientWindow(cliente).ShowDialog();
    }

    public bool DeleteDialog(Cliente cliente)
    {
        // TODO: Implement Delete . use new Window, or use the dialog result
        var result = MessageBox.Show("Implement Delete", "Borrar Cliente?",
            MessageBoxButton.OKCancel,
            MessageBoxImage.Question, MessageBoxResult.Cancel);

        return result == MessageBoxResult.OK;
    }

    public Cliente? UpdateDialog(Cliente client)
    {
        // System.Media.SystemSounds.Asterisk.Play();
        // System.Media.SystemSounds.Hand.Play();
        // System.Media.SystemSounds.Beep.Play();
        // System.Media.SystemSounds.Question.Play();

        var dialog = ClientWindow.CreateUpdateClientWindow(client);
        var dialogResult = dialog.ShowDialog();

        // return dialogResult == true ? dialog.NewValue : dialog.OldValue;
        return dialogResult == true ? dialog.NewValue : default;
    }

    public Cliente? AddDialog()
    {
        var window = ClientWindow.CreateAddClientWindow();

        var result = window.ShowDialog();

        return result == true ? window.NewValue : default;
    }

    private Cliente dd()
    {
        Cliente c;

        H(out c);

        return c;
    }

    private void H(out Cliente c)
    {
        c = new Cliente();
    }
}

public class ProductDialogService : IDialogService<Producto>
{
    // TODO: Implement Dialog Functionality
    public void OpenInformationDialog(Producto producto)
    {
        ProductWindow.CreateViewProductWindow(producto).ShowDialog();
    }

    public bool DeleteDialog(Producto producto)
    {
        // TODO: Implement Delete
        var result = MessageBox.Show("Implement", "ssss", MessageBoxButton.OKCancel, MessageBoxImage.Question,
            MessageBoxResult.Cancel);

        return result == MessageBoxResult.OK;
    }

    public Producto? UpdateDialog(Producto producto)
    {
        var dialog = ProductWindow.CreateUpdateProductWindow(producto);

        var dialogResult = dialog.ShowDialog();

        // return dialogResult == true ? dialog.NewValue : dialog.OldValue;
        return dialogResult == true ? dialog.NewValue : default;
    }

    public Producto? AddDialog()
    {
        var window = ProductWindow.CreateAddProductWindow();

        var result = window.ShowDialog();

        return result == true ? window.NewValue : default;
    }
}

public class MarcaDialogService : IDialogService<Marca>
{
    public void OpenInformationDialog(Marca t)
    {
        MarcaWindow.CreateViewMarcaWindow(t).ShowDialog();
    }

    public bool DeleteDialog(Marca t)
    {
        // TODO: Implement Delete
        var result = MessageBox.Show("Implement", "ssss", MessageBoxButton.OKCancel, MessageBoxImage.Question,
            MessageBoxResult.Cancel);

        return result == MessageBoxResult.OK;
    }

    public Marca? UpdateDialog(Marca t)
    {
        var dialog = MarcaWindow.CreateUpdateMarcaWindow(t);
        var result = dialog.ShowDialog();

        return result == true ? dialog.NewValue : default;
    }

    public Marca? AddDialog()
    {
        var dialog = MarcaWindow.CreateAddMarcaWindow();
        var result = dialog.ShowDialog();

        return result == true ? dialog.NewValue : default;
    }
}

public class CategoriaDialogService : IDialogService<Categoria>
{
    public void OpenInformationDialog(Categoria t)
    {
        CategoriaWindow.CreateViewCategoriaWindow(t).ShowDialog();
    }

    public bool DeleteDialog(Categoria t)
    {
        // TODO: Implement Delete
        var result = MessageBox.Show("Implement", "ssss", MessageBoxButton.OKCancel, MessageBoxImage.Question,
            MessageBoxResult.Cancel);

        return result == MessageBoxResult.OK;
    }

    public Categoria? UpdateDialog(Categoria t)
    {
        var dialog = CategoriaWindow.CreateUpdateCategoriaWindow(t);
        var result = dialog.ShowDialog();

        return result == true ? dialog.NewValue : default;
    }

    public Categoria? AddDialog()
    {
        var dialog = CategoriaWindow.CreateAddCategoriaWindow();
        var result = dialog.ShowDialog();

        return result == true ? dialog.NewValue : default;
    }
}