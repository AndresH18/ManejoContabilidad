using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace ContabilidadWinUI.Services;

internal static class FileService
{
    public static async Task<StorageFile?> SelectFile(Microsoft.UI.Xaml.Window mainWindow, params string[] filters)
    {
        try
        {
            FileOpenPicker filePicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
            };

            foreach (var filter in filters)
            {
                filePicker.FileTypeFilter.Add(filter);
            }

            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(mainWindow);
            WinRT.Interop.InitializeWithWindow.Initialize(filePicker, hwnd);

            StorageFile? file = await filePicker.PickSingleFileAsync();

            return file;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error while trying to open the File picker. {ex}");

            throw;
        }
    }

    public static async Task<StorageFile?> SelectFile(Microsoft.UI.Xaml.Window mainWindow)
    {
        try
        {
            FileOpenPicker filePicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                FileTypeFilter = {"*"}
            };

            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(mainWindow);
            WinRT.Interop.InitializeWithWindow.Initialize(filePicker, hwnd);

            StorageFile? file = await filePicker.PickSingleFileAsync();

            return file;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error while trying to open the File picker. {ex}");

            throw;
        }
    }
}