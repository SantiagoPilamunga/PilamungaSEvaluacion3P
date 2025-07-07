using PilamungaSEvaluacion3P.Views;

namespace PilamungaSEvaluacion3P
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RegistroPage), typeof(RegistroPage));

        }
    }
}
