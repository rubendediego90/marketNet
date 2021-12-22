using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //La clase usuario tiene por defecto todaas las propieades 
    // y métodos de la clase IdentityUser
    public class UsuarioEntity : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DireccionEntity Direccion { get; set; }
    }
}
