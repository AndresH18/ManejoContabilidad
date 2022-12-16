namespace ManejoContabilidad.Wpf.Helpers.Dialog;

/// <summary>
/// Helper class for dialogs
/// </summary>
/// <typeparam name="T">Type of the object to display in dialogs</typeparam>
public interface IDialogHelper<T>
{
    /// <summary>
    /// Show <paramref name="t"/> on a dialog
    /// </summary>
    /// <param name="t">the object to display</param>
    void Show(T t);

    /// <summary>
    /// Display a dialog to create a new <typeparamref name="T"/>
    /// </summary>
    /// <returns>A new instance of <typeparamref name="T"/> or null if no instance is to be created</returns>
    T? Add();

    /// <summary>
    /// Display a dialog to edit <paramref name="t"/>. 
    /// </summary>
    /// <param name="t">The object to edit</param>
    /// <returns>A new instance of <typeparamref name="T"/> with the modified values or null if no update is made</returns>
    T? Edit(T t);

    /// <summary>
    /// Displays a dialog to confirm deletion of <paramref name="t"/>
    /// </summary>
    /// <param name="t">The object to delete</param>
    bool Delete(T t);
}