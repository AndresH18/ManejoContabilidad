using System.Collections.ObjectModel;

namespace ManejoContable.ViewModel;

public interface IBaseViewModel<TModel>
{
    public ObservableCollection<TModel> Models { get; }
    public void Show(TModel t);
    public void Delete(TModel t);
    public void Edit(TModel t);
    public void Create();
}