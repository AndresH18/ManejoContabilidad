using System;
using System.Threading.Tasks;
using ContabilidadWinUI.View.Categoria;
using ContabilidadWinUI.View.Client;
using ContabilidadWinUI.View.Marca;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ModelEntities;

namespace ContabilidadWinUI.ViewModel;

public interface IModelDialogService<T>
{
    Task<T?> CreateDialog();
    void ShowDialog(T model);
    Task<T?> UpdateDialog(T model);
    Task<bool> DeleteDialog(T model);
}

#region ClientDialogService

public class ClientDialogService : IModelDialogService<Cliente>
{
    public async Task<Cliente?> CreateDialog()
    {
        var content = ClientDialog.CreateDialog(new Cliente());

        var dialog = new ContentDialog
        {
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            XamlRoot = App.Current.Window?.Content.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            Title = "Agregar Cliente",
            PrimaryButtonText = "Guardar",
            // dialog.SecondaryButtonText = "Don't Save";
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            Content = content
        };


        var result = await dialog.ShowAsync();

        return result == ContentDialogResult.Primary ? content.Cliente : null;
    }

    public async void ShowDialog(Cliente model)
    {
        // var content = ClientDialog.CreateViewDialog(model);
        var content = ClientDialog.CreateDialog(model, isReadOnly: true);

        var dialog = new ContentDialog
        {
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            XamlRoot = App.Current.Window?.Content.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            Title = model.Nombre,
            // Title = model.Nombre,
            // PrimaryButtonText = "Guardar",
            // dialog.SecondaryButtonText = "Don't Save";
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            Content = content
        };

        await dialog.ShowAsync();
    }

    public async Task<Cliente?> UpdateDialog(Cliente model)
    {
        var toUpdate = (Cliente) model.Clone();
        var content = ClientDialog.CreateDialog(toUpdate);

        var dialog = new ContentDialog
        {
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            XamlRoot = App.Current.Window?.Content.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            Title = "Actualizar",
            // Title = model.Nombre,
            PrimaryButtonText = "Guardar",
            // dialog.SecondaryButtonText = "Don't Save";
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            Content = content
        };

        var result = await dialog.ShowAsync();

        return result == ContentDialogResult.Primary ? toUpdate : null;
    }

    public async Task<bool> DeleteDialog(Cliente model)
    {
        var content = ClientDialog.CreateDialog(model, isReadOnly: true);
        var dialog = new ContentDialog
        {
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            XamlRoot = App.Current.Window?.Content.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            Title = "Eliminar Cliente?",
            // Title = model.Nombre,
            PrimaryButtonText = "Eliminar",
            // dialog.SecondaryButtonText = "Don't Save";
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            Content = content,
        };

        var result = await dialog.ShowAsync();

        return result == ContentDialogResult.Primary;
    }
}

#endregion

#region CategoriaDialogService

public class CategoriaDialogService : IModelDialogService<Categoria>
{
    public async Task<Categoria?> CreateDialog()
    {
        var content = CategoriaDialog.CreateDialog(new Categoria());

        var dialog = new ContentDialog
        {
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            XamlRoot = App.Current.Window?.Content.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            Title = "Agregar Categoria",
            PrimaryButtonText = "Guardar",
            // dialog.SecondaryButtonText = "Don't Save";
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            Content = content
        };


        var result = await dialog.ShowAsync();

        return result == ContentDialogResult.Primary ? content.Categoria : null;
    }

    public async void ShowDialog(Categoria model)
    {
        var content = CategoriaDialog.CreateDialog(model, isReadOnly: true);

        var dialog = new ContentDialog
        {
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            XamlRoot = App.Current.Window?.Content.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            Title = model.Name,
            // Title = model.Nombre,
            // PrimaryButtonText = "Guardar",
            // dialog.SecondaryButtonText = "Don't Save";
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            Content = content
        };

        await dialog.ShowAsync();
    }

    public async Task<Categoria?> UpdateDialog(Categoria model)
    {
        var toUpdate = (Categoria) model.Clone();
        var content = CategoriaDialog.CreateDialog(toUpdate);

        var dialog = new ContentDialog
        {
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            XamlRoot = App.Current.Window?.Content.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            Title = "Actualizar",
            PrimaryButtonText = "Guardar",
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            Content = content
        };

        var result = await dialog.ShowAsync();

        return result == ContentDialogResult.Primary ? toUpdate : null;
    }

    public async Task<bool> DeleteDialog(Categoria model)
    {
        var content = CategoriaDialog.CreateDialog(model, isReadOnly: true);
        var dialog = new ContentDialog
        {
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            XamlRoot = App.Current.Window?.Content.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            Title = "Eliminar Categoria?",
            // Title = model.Nombre,
            PrimaryButtonText = "Eliminar",
            // dialog.SecondaryButtonText = "Don't Save";
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            Content = content,
        };

        var result = await dialog.ShowAsync();

        return result == ContentDialogResult.Primary;
    }
}

#endregion

#region MarcaDialogService

public class MarcaDialogService : IModelDialogService<Marca>
{
    public async Task<Marca?> CreateDialog()
    {
        var content = MarcaDialog.CreateDialog(new Marca());

        var dialog = new ContentDialog
        {
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            XamlRoot = App.Current.Window?.Content.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            Title = "Agregar Marca",
            PrimaryButtonText = "Guardar",
            // dialog.SecondaryButtonText = "Don't Save";
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            Content = content
        };


        var result = await dialog.ShowAsync();

        return result == ContentDialogResult.Primary ? content.Marca : null;
    }

    public async void ShowDialog(Marca model)
    {
        var content = MarcaDialog.CreateDialog(model, isReadOnly: true);

        var dialog = new ContentDialog
        {
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            XamlRoot = App.Current.Window?.Content.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            Title = model.Name,
            // Title = model.Nombre,
            // PrimaryButtonText = "Guardar",
            // dialog.SecondaryButtonText = "Don't Save";
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            Content = content
        };

        await dialog.ShowAsync();
    }

    public async Task<Marca?> UpdateDialog(Marca model)
    {
        var toUpdate = (Marca) model.Clone();
        var content = MarcaDialog.CreateDialog(toUpdate);

        var dialog = new ContentDialog
        {
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            XamlRoot = App.Current.Window?.Content.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            Title = "Actualizar",
            PrimaryButtonText = "Guardar",
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            Content = content
        };

        var result = await dialog.ShowAsync();

        return result == ContentDialogResult.Primary ? toUpdate : null;
    }

    public async Task<bool> DeleteDialog(Marca model)
    {
        var content = MarcaDialog.CreateDialog(model, isReadOnly: true);
        var dialog = new ContentDialog
        {
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            XamlRoot = App.Current.Window?.Content.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            Title = "Eliminar Marca?",
            // Title = model.Nombre,
            PrimaryButtonText = "Eliminar",
            // dialog.SecondaryButtonText = "Don't Save";
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            Content = content,
        };

        var result = await dialog.ShowAsync();

        return result == ContentDialogResult.Primary;
    }
}

#endregion