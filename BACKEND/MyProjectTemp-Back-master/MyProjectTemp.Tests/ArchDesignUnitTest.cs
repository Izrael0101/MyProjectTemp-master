using Moq;
using MyProjectTemp.Api.Controllers;
using MyProjectTemp.Api.DTOs.Responses;
using MyProjectTemp.App.Interfaces;
using MyProjectTemp.Core.Entities;

namespace MyProjectTemp.Tests
{
    public class ArchDesignUnitTest
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly ArchDesignController _controller;

        public ArchDesignUnitTest()
        {
            // Crear un mock de IUnitOfWork para simular las operaciones de acceso a datos.
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            // Instanciar el controlador con el mock de IUnitOfWork.
            _controller = new ArchDesignController(_mockUnitOfWork.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsAllItems()
        {
            // Configurar el mock para que retorne una lista de ArchDesigns cuando se llame a GetAllAsync().
            var mockItems = new List<ArchDesign> { new ArchDesign(), new ArchDesign() };
            _mockUnitOfWork.Setup(uow => uow.ArchDesign.GetAllAsync()).ReturnsAsync(mockItems);

            // Ejecutar el método GetAll() y verificar que el resultado es como se esperaba.
            var result = await _controller.GetAll();

            // Verificar que el resultado es una respuesta API exitosa con los items esperados.
            var actionResult = Assert.IsType<ApiResponse<List<ArchDesign>>>(result);
            Assert.True(actionResult.Success);
            Assert.Equal(mockItems.Count, actionResult.Result.Count);
        }

        [Fact]
        public async Task GetById_ReturnsItem_WhenItemExists()
        {
            // Configurar el mock para que retorne un ArchDesign específico cuando se llame a GetByIdAsync() con un ID específico.
            var mockItem = new ArchDesign { ArchDesignID = 1 };
            _mockUnitOfWork.Setup(uow => uow.ArchDesign.GetByIdAsync(long.Parse(mockItem.ArchDesignID.ToString()))).ReturnsAsync(mockItem);

            // Ejecutar el método GetById() y verificar que el resultado es como se esperaba.
            var result = await _controller.GetById(long.Parse(mockItem.ArchDesignID.ToString()));

            // Verificar que el resultado es una respuesta API exitosa con el item esperado.
            var actionResult = Assert.IsType<ApiResponse<ArchDesign>>(result);
            Assert.True(actionResult.Success);
            Assert.Equal(mockItem.ArchDesignID, actionResult.Result.ArchDesignID);
        }

        [Fact]
        public async Task Add_ReturnsSuccess_WhenItemIsAdded()
        {
            // Configurar el mock para que retorne un resultado exitoso cuando se llame a AddAsync().
            var newItem = new ArchDesign();
            _mockUnitOfWork.Setup(uow => uow.ArchDesign.AddAsync(newItem)).ReturnsAsync("Added successfully");

            // Ejecutar el método Add() y verificar que el resultado es como se esperaba.
            var result = await _controller.Add(newItem);

            // Verificar que el resultado es una respuesta API exitosa.
            var actionResult = Assert.IsType<ApiResponse<string>>(result);
            Assert.True(actionResult.Success);
            Assert.Equal("Added successfully", actionResult.Result);
        }

        [Fact]
        public async Task Update_ReturnsSuccess_WhenItemIsUpdated()
        {
            // Configurar el mock para que retorne un resultado exitoso cuando se llame a UpdateAsync().
            var updatedItem = new ArchDesign { ArchDesignID = 1 };
            _mockUnitOfWork.Setup(uow => uow.ArchDesign.UpdateAsync(updatedItem)).ReturnsAsync("Updated successfully");

            // Ejecutar el método Update() y verificar que el resultado es como se esperaba.
            var result = await _controller.Update(updatedItem);

            // Verificar que el resultado es una respuesta API exitosa.
            var actionResult = Assert.IsType<ApiResponse<string>>(result);
            Assert.True(actionResult.Success);
            Assert.Equal("Updated successfully", actionResult.Result);
        }

        [Fact]
        public async Task Delete_ReturnsSuccess_WhenItemIsDeleted()
        {
            // Configurar el mock para que retorne un resultado exitoso cuando se llame a DeleteAsync() con un ID específico.
            long itemId = 1;
            _mockUnitOfWork.Setup(uow => uow.ArchDesign.DeleteAsync(itemId)).ReturnsAsync("Deleted successfully");

            // Ejecutar el método Delete() y verificar que el resultado es como se esperaba.
            var result = await _controller.Delete(itemId);

            // Verificar que el resultado es una respuesta API exitosa.
            var actionResult = Assert.IsType<ApiResponse<string>>(result);
            Assert.True(actionResult.Success);
            Assert.Equal("Deleted successfully", actionResult.Result);
        }
    }
}