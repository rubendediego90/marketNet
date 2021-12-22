using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DireccionEntity
    {
        public int ID { get; set; }
        public string Calle { get; set; }
        public string Ciudad { get; set; }

        public string Departamento { get; set; }

        public string CodigoPostal { get; set; }

        public string UsuarioId { get; set; }

        public UsuarioEntity Usuario { get; set;}
    }
}
