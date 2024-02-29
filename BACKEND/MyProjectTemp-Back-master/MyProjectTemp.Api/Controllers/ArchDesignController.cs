using Microsoft.AspNetCore.Mvc;
using MyProjectTemp.Api.DTOs.Responses;
using MyProjectTemp.App.Interfaces;
using MyProjectTemp.Core.Entities;
using System.Data.SqlClient;

namespace MyProjectTemp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchDesignController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArchDesignController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Método genérico para ejecutar operaciones y manejar errores comunes
        private async Task<ActionResult<ApiResponse<T>>> ExecuteOperationAsync<T>(Func<Task<T>> operation, string successMessage = null)
        {
            var apiResponse = new ApiResponse<T>();
            try
            {
                T result = await operation();
                apiResponse.Success = true;
                apiResponse.Result = result;
                apiResponse.Message = successMessage; // Mensaje de éxito personalizado
                return Ok(apiResponse); // HTTP 200 con el cuerpo de la respuesta
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = $"SQL Error: {ex.Message}";
                return BadRequest(apiResponse); // HTTP 400 para errores de SQL
            }
            catch (KeyNotFoundException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                return NotFound(apiResponse); // HTTP 404 para cuando no se encuentra un recurso
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = $"An error occurred: {ex.Message}";
                return StatusCode(500, apiResponse); // HTTP 500 para errores del servidor
            }
        }

        [HttpGet("GetAll")]
        public Task<ActionResult<ApiResponse<List<ArchDesign>>>> GetAll()
        {
            return ExecuteOperationAsync(async () => (await _unitOfWork.ArchDesign.GetAllAsync()).ToList(), "OK");
        }

        [HttpGet("GetById/{id}")]
        public Task<ActionResult<ApiResponse<ArchDesign>>> GetById(long id)
        {
            return ExecuteOperationAsync(async () =>
            {
                var design = await _unitOfWork.ArchDesign.GetByIdAsync(id);
                if (design == null)
                {
                    throw new KeyNotFoundException($"ID {id} not found");
                }
                return design;
            }, "OK");
        }

        [HttpPost("Add")]
        public Task<ActionResult<ApiResponse<string>>> Add(ArchDesign archDesign)
        {
            return ExecuteOperationAsync(async () =>
            {
                string result = await _unitOfWork.ArchDesign.AddAsync(archDesign);
                return $"Added with ID {result}";
            });
        }

        [HttpPut("Update")]
        public Task<ActionResult<ApiResponse<string>>> Update(ArchDesign archDesign)
        {
            return ExecuteOperationAsync(async () =>
            {
                string result = await _unitOfWork.ArchDesign.UpdateAsync(archDesign);
                return $"ID {archDesign.ArchDesignID} updated successfully";
            });
        }

        [HttpDelete("Delete/{id}")]
        public Task<ActionResult<ApiResponse<string>>> Delete(long id)
        {
            return ExecuteOperationAsync(async () =>
            {
                string result = await _unitOfWork.ArchDesign.DeleteAsync(id);
                return $"ID {id} deleted successfully";
            });
        }
    }
}