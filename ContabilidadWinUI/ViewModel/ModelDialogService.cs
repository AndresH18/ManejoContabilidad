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
    T? UpdateDialog(T model);
    bool DeleteDialog(T model);
}

public class ClientDialogService : IModelDialogService<Cliente>
{
    public async Task<Cliente?> CreateDialog()
    {
        // 
        ContentDialog dialog = new ContentDialog();

        // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
        // dialog.XamlRoot = this.XamlRoot;
        
        dialog.XamlRoot = (Application.Current as App)?.Window?.Content.XamlRoot;
        dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
        dialog.Title = "Save your work?";
        dialog.PrimaryButtonText = "Save";
        dialog.SecondaryButtonText = "Don't Save";
        dialog.CloseButtonText = "Cancel";
        dialog.DefaultButton = ContentDialogButton.Primary;
        dialog.Content = ClientDialog.CreateClientDialog();

        var result = await dialog.ShowAsync();

        return null;
    }

    public void ShowDialog(Cliente model)
    {
        throw new NotImplementedException();
    }

    public Cliente? UpdateDialog(Cliente model)
    {
        throw new NotImplementedException();
    }

    public bool DeleteDialog(Cliente model)
    {
        throw new NotImplementedException();
    }
}