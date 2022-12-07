namespace ManejoContabilidad.Wpf.Services.Dialog;

public interface IDialogService<T>
{
    void Show(T t);
    T Add(T t);
    T Edit(T t);
    void Delete(T t);
}