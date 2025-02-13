using DscApi.Interfaces;
using DscApi.Models.Entity;
using DscApi.Models.Request;
using DscApi.Models.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DscApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [EnableCors("dsccors")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetProductAll()
        {
            DataResponse<Product> response = new DataResponse<Product>();
            try
            {
                var data = await _productService.GetProductAll();
                response.Data = data;
                response.ErrorCode = 0;
                response.ErrorMessage = "Proceso exitoso";
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                response.Data = new List<Product>() { };
                response.ErrorCode = 0;
                response.ErrorMessage = "Ocurrio un error al procesar su solicitud: " + ex;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

        }



        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            DataResponse<Product> response = new DataResponse<Product>();
            try
            {
                var data = await _productService.GetProductById(id);
                response.Data = new List<Product>() { data };
                response.ErrorCode = 0;
                response.ErrorMessage = "Proceso exitoso";
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                response.Data = new List<Product>() { };
                response.ErrorCode = 0;
                response.ErrorMessage = "Ocurrio un error al procesar su solicitud: " + ex;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

        }



        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateOrEditRequest request)
        {
            DataResponse<Product> response = new DataResponse<Product>();
            try
            {
                bool data = await _productService.CreateProduct(request);

                if (!data)
                {
                    throw new Exception("No existen registros afectadas en el proceso");
                }

                response.Data = new List<Product>();
                response.ErrorCode = 0;
                response.ErrorMessage = "Proceso exitoso";
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                response.Data = new List<Product>() { };
                response.ErrorCode = 0;
                response.ErrorMessage = "Ocurrio un error al procesar su solicitud: " + ex;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

        }





        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductCreateOrEditRequest request)
        {
            DataResponse<Product> response = new DataResponse<Product>();
            try
            {
                bool data = await _productService.UpdateProduct(id, request);

                if (!data)
                {
                    throw new Exception("No existen registros afectadas en el proceso");
                }

                response.Data = new List<Product>();
                response.ErrorCode = 0;
                response.ErrorMessage = "Proceso exitoso";
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                response.Data = new List<Product>() { };
                response.ErrorCode = 0;
                response.ErrorMessage = "Ocurrio un error al procesar su solicitud: " + ex;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

        }




        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            DataResponse<Product> response = new DataResponse<Product>();
            try
            {
                bool data = await _productService.DeleteProduct(id);

                if (!data)
                {
                    throw new Exception("No existen registros afectadas en el proceso");
                }

                response.Data = new List<Product>();
                response.ErrorCode = 0;
                response.ErrorMessage = "Proceso exitoso";
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                response.Data = new List<Product>() { };
                response.ErrorCode = 0;
                response.ErrorMessage = "Ocurrio un error al procesar su solicitud: " + ex;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

        }


    }
}
