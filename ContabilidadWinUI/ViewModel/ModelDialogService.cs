using System;
using System.Threading.Tasks;
using ContabilidadWinUI.View.Client;
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

public class ClientDialogService : IModelDialogService<Cliente>
{
    public async Task<Cliente?> CreateDialog()
    {
        var content = ClientDialog.CreateDialog();

        var dialog = new ContentDialog
        {
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            XamlRoot = (Application.Current as App)?.Window?.Content.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            Title = "Agregar Cliente",
            PrimaryButtonText = "Guardar",
            // dialog.SecondaryButtonText = "Don't Save";
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            Content = content
        };


        var result = await dialog.ShowAsync();

        return null;
    }

    public async void ShowDialog(Cliente model)
    {
        var content = ClientDialog.CreateViewDialog(model);

        var dialog = new ContentDialog
        {
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            XamlRoot = (Application.Current as App)?.Window?.Content.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            Title = "Agregar Cliente",
            // Title = model.Nombre,
            // PrimaryButtonText = "Guardar",
            // dialog.SecondaryButtonText = "Don't Save";
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            Content = content
        };

        var result = await dialog.ShowAsync();
    }

    public async Task<Cliente?> UpdateDialog(Cliente model)
    {
        var content = ClientDialog.CreateUpdateDialog(model);

        var dialog = new ContentDialog
        {
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            XamlRoot = (Application.Current as App)?.Window?.Content.XamlRoot,
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

        return null;
    }

    public async Task<bool> DeleteDialog(Cliente model)
    {
        var content = ClientDialog.CreateViewDialog(model);
        var dialog = new ContentDialog
        {
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            XamlRoot = (Application.Current as App)?.Window?.Content.XamlRoot,
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

        return false;
    }
}