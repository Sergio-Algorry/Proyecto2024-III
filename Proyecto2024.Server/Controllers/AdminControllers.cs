using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto2024.BD.Data;
using Proyecto2024.Shared.DTO;

namespace Proyecto2024.Server.Controllers
{
    [ApiController]
    [Route("usuarios/admin")]
    //Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    public class AdminControllers : ControllerBase
    {
        private readonly Context context;
        private readonly UserManager<IdentityUser> userManager;

        public AdminControllers(Context context,
                                UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserListadoDTO>>> Get()
        {
            var usuarios = context.Users.AsQueryable();
            var usuariosDTO = await usuarios.Select(u => new UserListadoDTO
            {
                Id = u.Id,         
                Email = u.Email!
            }).ToListAsync();
            return usuariosDTO;
        }
    }
}
