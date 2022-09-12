using Microsoft.UI.Xaml;

namespace ContabilidadWinUI.ViewModel;

public interface ITaskRunning
{
    public Visibility TaskVisibility { get; }
    public bool IsTaskError { get; }
}