using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductoEntity : BaseClass
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int MarcaId { get; set; }
        public MarcaEntity Marca { get; set; }

        public int CategoriaId { get; set; }

        public CategoriaEntity Categoria { get; set; }

        public int Stock { get; set; }
        //[Column(TypeName="decimal(18,4)")]
        public decimal Precio { get; set; }

        public string Imagen { get; set; }
    }
}
