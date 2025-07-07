using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PilamungaSEvaluacion3P.Models;
using PilamungaSEvaluacion3P.Repository;

namespace PilamungaSEvaluacion3P.ViewModels
{
    public class ClienteViewModel : INotifyPropertyChanged
    {
        public string Nombre { get; set; }
        public string Empresa { get; set; }
        public int AntiguedadMeses { get; set; }
        public bool Activo { get; set; }

        public ICommand GuardarCommand { get; }

        private ClienteRepository repo;
        private string logPath;

        public ClienteViewModel()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "clientes.db3");
            repo = new ClienteRepository(dbPath);
            logPath = Path.Combine(FileSystem.AppDataDirectory, "Logs_Pilamunga.txt");

            GuardarCommand = new Command(async () => await Guardar());
        }

        private async Task Guardar()
        {
            var cliente = new Cliente
            {
                Nombre = this.Nombre,
                Empresa = this.Empresa,
                AntiguedadMeses = this.AntiguedadMeses,
                Activo = this.Activo
            };

            if (await repo.AddClienteAsync(cliente))
            {
                string log = $"Se incluyó el registro {cliente.Nombre} el {DateTime.Now:dd/MM/yyyy HH:mm}";
                File.AppendAllText(logPath, log + Environment.NewLine);
                await Application.Current.MainPage.DisplayAlert("Exito","Cliente registrado correctamente", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se puede registrar empresas con más de 1500 días de antigüedad.", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
