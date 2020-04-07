using System.Collections.Generic;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Presentacion.Models;
using System.Linq;
using Entity;

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiquidacionController : ControllerBase
    {
        private readonly LiquidacionService liquidacionService;
        public IConfiguration Configuration { get; }

        public LiquidacionController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            liquidacionService = new LiquidacionService(connectionString);
        }

        [HttpGet]
        public IEnumerable<LiquidacionViewModel> Gets()
        {
            var liquidaciones = liquidacionService.ConsultarTodos().Liquidaciones.Select(p => new LiquidacionViewModel(p));
            return liquidaciones;
        }

        [HttpPost]
        public ActionResult<LiquidacionViewModel> Post(LiquidacionInputModel liquidacionInput)
        {
            Liquidacion liquidacion = LiquidacionPersona(liquidacionInput);
            var response = liquidacionService.Guardar(liquidacion);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Liquidacion);
        }

        private Liquidacion LiquidacionPersona(LiquidacionInputModel liquidacionInput)
        {
            var liquidacion = new Liquidacion
            {
                IdentificacionDelPaciente = liquidacionInput.IdentificacionDelPaciente,
                ValorDelServicio = liquidacionInput.ValorDelServicio,
                SalarioDeTrabajador = liquidacionInput.SalarioDeTrabajador
            };
            return liquidacion;
        }


    }
}