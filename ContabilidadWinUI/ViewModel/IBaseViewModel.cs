using System.Collections.ObjectModel;
using ContabilidadWinUI.ViewModel.Commands;
using ModelEntities;

namespace ContabilidadWinUI.ViewModel;

public interface IBaseViewModel<TModel> : ITaskRunning
{
    public ObservableCollection<TModel> Models { get; }

    public TModel? SelectedModel { get; set; }

    public IModelDialogService<TModel> DialogService { get; }

    public ViewCommand<TModel> ViewCommand { get; }

    public CreateCommand<TModel> CreateCommand { get; }

    public DeleteCommand<TModel> DeleteCommand { get; }

    public EditCommand<TModel> EditCommand { get; }

    public void Show(TModel t);

    public void Delete(TModel t);

    public void Edit(TModel t);

    //
    public void Create();
}