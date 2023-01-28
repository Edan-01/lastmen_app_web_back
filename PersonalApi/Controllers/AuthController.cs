using Logica;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Modelos;
using Modelos.NoDatabase;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Utilitarios;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace PersonalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[AllowAnonymous]
    public class AuthController : ControllerBase
    {
        UsuarioLogica userLogica = new UsuarioLogica();

        [HttpGet]
        public IActionResult get()
        {
            return Ok("servicio en escucha");
        }
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult post([FromBody] LoginRequest request)
        {
            
            LoginResponse response = new LoginResponse();
            UsuarioModel user = userLogica.ObtenerUsuarioPorUserrName(request.Usuario);
            
            if (
                !( // "!" significa negación
                user.Usuario == request.Usuario
                && user.Password == UtilSecurity.encriptar_AES(request.Password))
                )
            {
                return BadRequest("Usuario y/o password incorrecto");
            }

            user.Password = "";
            string token = generateToken(user, 59);
            response.token = token;
            response.usuario = user;

            return Ok(response);    
        }


        //[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginResponse))]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorResponse))]
        //[ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        //[HttpPost("RefreshToken")]
        //public IActionResult refresh([FromBody] LoginRequest request)
        //{
        //    try
        //    {
        //        string refreshToken = "";
        //        LoginResponse response = new LoginResponse();
        //        UsuarioModel user = userLogica.ObtenerUsuarioPorUserrName(request.Usuario);

        //        if (
        //            !( // "!" significa negación
        //            user.Usuario == request.Usuario
        //            && user.Password == UtilSecurity.encriptar_AES(request.Password))
        //            )
        //        {
        //            return BadRequest("Usuario y/o password incorrecto");
        //        }

        //        user.Password = "";
        //        string token = generateToken(user, 1);
        //        response.token = token;
        //        response.refreshtoken = refreshToken;
        //        response.usuario = user;
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok();
        //    }
        //}

       


        private string generateToken(UsuarioModel user,int expireInMinutes)
        {
            //create claims details based on the user information
            IConfigurationBuilder configurationBuild = new ConfigurationBuilder();
            configurationBuild = configurationBuild.AddJsonFile("appsettings.json");
            IConfiguration configurationFile = configurationBuild.Build();
            // Leemos el archivo de configuración.
            var claims = new[] {
                       new Claim(JwtRegisteredClaimNames.Sub, configurationFile["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.IdUsuario.ToString()),
                        new Claim("UserName", user.Usuario),
                        new Claim(ClaimTypes.Role, user.TipoUsuario),
                        new Claim("DisplayName", user.Nombres),
                        new Claim("UserName", user.Apellidos),
                        new Claim("Direccion", user.Direccion),
                        new Claim("Email", user.Correo)
                    };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationFile["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);  
            var token = new JwtSecurityToken(
                configurationFile["Jwt:Issuer"],
                configurationFile["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(expireInMinutes),
                signingCredentials: signIn);
            return new JwtSecurityTokenHandler().WriteToken(token);
        } 


    }
}
