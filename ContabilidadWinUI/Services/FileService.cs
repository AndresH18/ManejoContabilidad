using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace ContabilidadWinUI.Services;

internal static class FileService
{
    public static async Task<StorageFile?> SelectFile(Microsoft.UI.Xaml.Window mainWindow)
    {
        try
        {
            FileOpenPicker filePicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                FileTypeFilter = {".pdf"}
            };

            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(mainWindow);
            WinRT.Interop.InitializeWithWindow.Initialize(filePicker, hwnd);

            StorageFile? file = await filePicker.PickSingleFileAsync();

            return file;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error while trying to open the File picker. {ex}");

            return default;
        }
    }
}