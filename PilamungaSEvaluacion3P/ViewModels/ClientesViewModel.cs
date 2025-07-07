using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilamungaSEvaluacion3P.Models;
using PilamungaSEvaluacion3P.Repository;

namespace PilamungaSEvaluacion3P.ViewModels
{
    public class ClientesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Cliente> Clientes { get; set; } = new();

        private ClienteRepository repo;

        public ClientesViewModel()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "clientes.db3");
            repo = new ClienteRepository(dbPath);

            _ = LoadClientesAsync();
        }

        private async Task LoadClientesAsync()
        {
            var lista = await repo.GetClientesAsync();
            Clientes.Clear();
            foreach (var cliente in lista)
                Clientes.Add(cliente);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public async void CargarClientes()
        {
            var lista = await repo.GetClientesAsync();
            Clientes.Clear();
            foreach (var cliente in lista)
                Clientes.Add(cliente);
        }

    }
}
