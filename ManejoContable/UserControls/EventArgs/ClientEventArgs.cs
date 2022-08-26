using ModelEntities;

namespace ManejoContable.UserControls.EventArgs;

public class ClientEventArgs : System.EventArgs
{
    public Cliente? Cliente { get; set; } = default;
}