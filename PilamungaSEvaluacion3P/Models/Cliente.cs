using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PilamungaSEvaluacion3P.Models
{
    public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Empresa { get; set; }
        public int AntiguedadMeses { get; set; }
        public bool Activo { get; set; }
    }
}

