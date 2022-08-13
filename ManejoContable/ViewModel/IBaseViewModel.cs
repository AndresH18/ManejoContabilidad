namespace ManejoContable.ViewModel;

public interface IBaseViewModel<TModel>
{
    public void ShowInformation(TModel t);
    public void Delete(TModel t);
    public void Edit(TModel t);
    public void Add();
}