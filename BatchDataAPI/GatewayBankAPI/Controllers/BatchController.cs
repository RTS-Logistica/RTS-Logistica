using Application.DTO.Response;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GatewayBankAPI.Controllers
{
    [ApiController]
    [Route("BatchController")]
    public class BatchController : Controller
    {
        public readonly IBatchCardService _service;
        public BatchController(IBatchCardService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetBatchCardById([FromQuery(Name = "BatchId")][Required] int id)
        {
            if (id < 1)
                return BadRequest("El ID debe ser un entero positivo");

            var result = await _service.GetBatchCardById(id);
            if (result == null)
                return NotFound("No existe un Lote de Tarjetas con ese ID");
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(result));
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
