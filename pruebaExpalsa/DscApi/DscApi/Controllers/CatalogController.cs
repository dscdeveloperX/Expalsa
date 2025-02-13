using DscApi.Interfaces;
using DscApi.Models.Entity;
using DscApi.Models.Response;
using DscApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DscApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [EnableCors("dsccors")]
    public class CatalogController : ControllerBase
    {


        private readonly ICatalogService _catalogService;
        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }


        [HttpGet("{grupo}")]
        public async Task<IActionResult> GetCatalogByGroup(string grupo)
        {
            DataResponse<Catalog> response = new DataResponse<Catalog>();
            try
            {
                var data = await _catalogService.GetCatalogByGroup(grupo);
                response.Data = data;
                response.ErrorCode = 0;
                response.ErrorMessage = "Proceso exitoso";
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                response.Data = new List<Catalog>() { };
                response.ErrorCode = 0;
                response.ErrorMessage = "Ocurrio un error al procesar su solicitud: " + ex;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

        }



    }
}
