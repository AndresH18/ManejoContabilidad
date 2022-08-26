using System.Collections.ObjectModel;
using ModelEntities;

namespace ContabilidadWinUI.ViewModel;

public class ClientsViewModel : IBaseViewModel<Cliente>
{
    private Cliente? _cliente;

    public ObservableCollection<Cliente> Models { get; }
    public Cliente? SelectedModel { get; set; }


    public ClientsViewModel()
    {
        Models = new ObservableCollection<Cliente>
        {
            new()
            {
                Nombre = "Imporcom", NumeroDocumento = "123-456-7890", TipoDocumento = TipoDocumento.Nit,
                Direccion = "Cra impor #1", Correo = "imporcom@correo.com", Telefono = "123-456-7890",
            },
            new()
            {
                Nombre = "Andres' Programmers SAS", NumeroDocumento = "111-222-33-44",
                TipoDocumento = TipoDocumento.Cc, Correo = "andres@correo.com", Telefono = "111-222-3344",
                Direccion = "Calle 123 # 445 sur",
            }
        };
    }

    public void Create()
    {
        // TODO: Implement create client
        throw new System.NotImplementedException($"Implement {typeof(ClientsViewModel)}:{nameof(Create)}");
    }
}