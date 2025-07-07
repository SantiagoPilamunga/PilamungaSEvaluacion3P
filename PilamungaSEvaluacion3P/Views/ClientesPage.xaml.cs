using PilamungaSEvaluacion3P.ViewModels;

namespace PilamungaSEvaluacion3P.Views;

public partial class ClientesPage : ContentPage
{
    private ClientesViewModel viewModel;

    public ClientesPage()
	{
		InitializeComponent();
        BindingContext = viewModel = new ClientesViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.CargarClientes();
    }

}