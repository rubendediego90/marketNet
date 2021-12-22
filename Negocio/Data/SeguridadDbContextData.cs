using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Data
{
    public class SeguridadDbContextData
    {
        public static async Task SeedUserAsync(UserManager<UsuarioEntity> userManager)
        {
            if (!userManager.Users.Any())
            {
                var usuario = new UsuarioEntity
                {
                    Nombre = "Rubén",
                    Apellido = "de Diego",
                    UserName = "rdediego",
                    Direccion = new DireccionEntity
                    {
                        Calle = "Gabriela Mistral",
                        Ciudad = "Alcalá de Henares",
                        CodigoPostal = "28806",
                        Departamento = "IT"
                    }
                };
                await userManager.CreateAsync(usuario,"123456");
            }
        }
    }
}
