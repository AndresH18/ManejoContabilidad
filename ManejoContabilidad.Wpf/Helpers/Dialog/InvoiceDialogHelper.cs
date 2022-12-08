using Shared.Models;

namespace ManejoContabilidad.Wpf.Helpers.Dialog;

public class InvoiceDialogHelper : IDialogHelper<Invoice>
{
    public Invoice? Add()
    {
        return null;
    }

    public bool Delete(Invoice t)
    {
        return false;
    }

    public Invoice? Edit(Invoice t)
    {
        return null;
    }

    public void Show(Invoice t)
    {
    }
}