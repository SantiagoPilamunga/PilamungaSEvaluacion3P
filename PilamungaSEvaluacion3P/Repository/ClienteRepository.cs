using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilamungaSEvaluacion3P.Models;
using SQLite;

namespace PilamungaSEvaluacion3P.Repository
{
        public class ClienteRepository
        {
            private readonly SQLiteAsyncConnection _data;

            public ClienteRepository(string dbPath)
            {
                _data = new SQLiteAsyncConnection(dbPath);
                _data.CreateTableAsync<Cliente>().Wait();
            }

            public Task<List<Cliente>> GetClientesAsync() =>
                _data.Table<Cliente>().ToListAsync();

            public async Task<bool> AddClienteAsync(Cliente cliente)
            {
                if (cliente.AntiguedadMeses > 150)
                    return false;

                await _data.InsertAsync(cliente);
                return true;
            }
        }
}
