using System.Collections.ObjectModel;
using ModelEntities;

namespace ContabilidadWinUI.ViewModel;

public interface IBaseViewModel<TModel>
{
    public ObservableCollection<TModel> Models { get; }

    public TModel? SelectedModel { get; set; }

    // public ViewCommand<TModel> ViewCommand { get; }
    //
    // public CreateCommand<TModel> CreateCommand { get; }
    //
    // public DeleteCommand<TModel> DeleteCommand { get; }
    //
    // public EditCommand<TModel> EditCommand { get; }
    //
    // public void Show(TModel t);
    //
    // public void Delete(TModel t);
    //
    // public void Edit(TModel t);
    //
    public void Create();
}