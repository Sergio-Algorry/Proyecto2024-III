using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Proyecto2024.Client.Autorizacion
{
    public class ProveedorAutenticacion : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //await Task.Delay(5000);
            var anonimo = new ClaimsIdentity();
            var usuarioPepe = new ClaimsIdentity(
                new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Pepe Sanchez"),
                    new Claim(ClaimTypes.Role, "admin"),
                    new Claim("DNI", "12.587.895"),
                },
                authenticationType: "ok"
                );
            var usuarioJuan = new ClaimsIdentity(
                new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Juan Perez"),
                    new Claim(ClaimTypes.Role, "operador"),
                    new Claim("DNI", "12.587.895"),
                },
                authenticationType: "ok"
                );
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(usuarioJuan)));
        }
    }
}
