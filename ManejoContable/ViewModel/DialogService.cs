using System;
using System.Windows;
using ManejoContable.View.Windows.Client;
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
        var dialogResult = new ViewClientWindow(cliente)
        {
            Owner = Application.Current.MainWindow,
            ShowInTaskbar = false,
            ResizeMode = ResizeMode.NoResize,
        }.ShowDialog();
    }

    public bool DeleteDialog(Cliente cliente)
    {
        // TODO: Implement Delete . use new Window, or use the dialog result
        var result = MessageBox.Show("Implement Delete", "Borrar Cliente?",
            MessageBoxButton.OKCancel,
            MessageBoxImage.Question, MessageBoxResult.Cancel);
        if (result == MessageBoxResult.OK)
        {
            // delete client
        }
        else
        {
            // Nothing 
        }

        return true;
    }

    public Cliente? UpdateDialog(Cliente client)
    {
        // System.Media.SystemSounds.Asterisk.Play();
        // System.Media.SystemSounds.Hand.Play();
        // System.Media.SystemSounds.Beep.Play();
        // System.Media.SystemSounds.Question.Play();

        var dialog = new EditClientWindow(client)
        {
            Owner = Application.Current.MainWindow,
            ShowInTaskbar = false,
            ResizeMode = ResizeMode.NoResize
        };
        var dialogResult = dialog.ShowDialog();

        // return dialogResult == true ? dialog.NewValue : dialog.OldValue;
        return dialogResult == true ? dialog.NewValue : default;
    }

    public Cliente? AddDialog()
    {
        var window = EditClientWindow.CreateAddClientDialogWindow();

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
        new ViewProductWindow(producto)
        {
            Owner = Application.Current.MainWindow,
            ResizeMode = ResizeMode.NoResize,
            ShowInTaskbar = false,
        }.ShowDialog();
    }

    public bool DeleteDialog(Producto producto)
    {
        throw new NotImplementedException();
    }

    public Producto? UpdateDialog(Producto producto)
    {
        throw new NotImplementedException();
    }

    public Producto? AddDialog()
    {
        throw new NotImplementedException();
    }
}