using API.DTOs;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace API.Controllers
{
    public class PruebaBaseConnectionController : BaseController
    {
        public readonly IServiceDataBase service;

        public PruebaBaseConnectionController(IServiceDataBase IService)
        {
            service = IService;
        }

        [HttpGet]
        public async Task<IActionResult> PruebaConsulta()
        {
            var resutl = await service.Query_Service(" SELECT JSON_QUERY((SELECT TOP 10 * FROM CL_PERSONAS FOR JSON PATH, INCLUDE_NULL_VALUES)) AS datos ");

            if (resutl == null)
            {
                BadRequest("No se obtuvo respuesta de la consulta");
                return BadRequest();
            }
            else
            {
                return Ok(resutl);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PruebaConsultaSP([FromBody] LoginDto payload){
            var result = await service.SP_Service(payload, "SP_Login");

            if (result == "false")
            {
                return Unauthorized();
            }
            else
            {
                var resultado = JsonSerializer.Deserialize<BaseResponseDto>(result);

                if (resultado.error == 0)
                {
                    return Ok(resultado);
                }
                else
                {
                    return BadRequest("No existe el usuario");
                }
            }
        }
    }
}
