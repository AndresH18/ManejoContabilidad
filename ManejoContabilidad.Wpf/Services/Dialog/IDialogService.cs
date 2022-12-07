namespace ManejoContabilidad.Wpf.Services.Dialog;

public interface IDialogService<T>
{
    void Show(T t);
    T Add();
    T Edit(T t);
    void Delete(T t);
}