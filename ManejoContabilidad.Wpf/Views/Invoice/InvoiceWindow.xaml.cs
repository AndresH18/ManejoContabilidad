using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using Models = Shared.Models;


namespace ManejoContabilidad.Wpf.Views.Invoice;

/// <summary>
/// Interaction logic for InvoiceWindow.xaml
/// </summary>
[INotifyPropertyChanged]
public partial class InvoiceWindow : Window
{
    private const string FileFilter = "PDF (*.pdf)|*.pdf";
    public Visibility IsConfirmVisible => IsReadOnly ? Visibility.Collapsed : Visibility.Visible;


    public bool IsReadOnly { get; }
    public Models::Invoice Invoice { get; private set; }

    public InvoiceWindow(Models::Invoice invoice, bool isReadOnly = false)
    {
        IsReadOnly = isReadOnly;
        Invoice = invoice;

        InitializeComponent();

        Owner = App.Current.MainWindow;
    }

    [RelayCommand]
    private void SearchFile()
    {
        var fileDialog = new OpenFileDialog
        {
            Filter = FileFilter,
            Multiselect = false,
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
        };

        if (fileDialog.ShowDialog(this) != true)
            return;
        var path = fileDialog.FileName;

        Invoice.Path = path;
        OnPropertyChanged(nameof(Invoice.Path));
    }

    [RelayCommand]
    private void Confirm()
    {
        DialogResult = true;
    }

    [RelayCommand]
    private void Cancel()
    {
        DialogResult = false;
    }
}