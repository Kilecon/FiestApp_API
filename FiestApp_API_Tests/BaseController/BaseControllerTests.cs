using FiestApp_API.Controllers;
using FiestApp_API.Response;
using FiestApp_API.Services.Base;
using FiestApp_Domain.Dtos.Base;
using FiestApp_Domain.Entities.Base;
using FiestApp_Domain.Factories.Base;
using FiestApp_Infrastructure.Documents.Base;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

public class BaseControllerTests
{
    private readonly BaseController _controller;
    private readonly Mock<IFactoryBase<IEntityBase, IBaseDto>> _mockFactory;
    private readonly Mock<IService<IDocumentBase, IEntityBase>> _mockService;

    public BaseControllerTests()
    {
        _mockService = new Mock<IService<IDocumentBase, IEntityBase>>();
        _mockFactory = new Mock<IFactoryBase<IEntityBase, IBaseDto>>();
        _controller = new BaseController(_mockService.Object, _mockFactory.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsOkResultWithData_WhenServiceReturnsEntities()
    {
        var entities = new List<IEntityBase> { Mock.Of<IEntityBase>(), Mock.Of<IEntityBase>() };
        var dtos = new List<IBaseDto> { Mock.Of<IBaseDto>(), Mock.Of<IBaseDto>() };

        _mockService.Setup(s => s.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(entities);
        _mockFactory.Setup(f => f.ToDto(It.IsAny<IEntityBase>())).Returns((IEntityBase e) => dtos[entities.IndexOf(e)]);

        var result = await _controller.GetAll<IBaseDto, IEntityBase, IDocumentBase>(CancellationToken.None);

        var okResult = Assert.IsType<ActionResult<ListResponse<IBaseDto>>>(result);
        var response = Assert.IsType<OkObjectResult>(okResult.Result);
        var listResponse = Assert.IsType<ListResponse<IBaseDto>>(response.Value);
        Assert.True(listResponse.Succes);
        Assert.Equal(2, listResponse.Data.Count());
    }

    [Fact]
    public async Task GetAll_ReturnsOkResultWithEmptyData_WhenServiceReturnsEmptyList()
    {
        _mockService.Setup(s => s.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(new List<IEntityBase>());

        var result = await _controller.GetAll<IBaseDto, IEntityBase, IDocumentBase>(CancellationToken.None);

        var okResult = Assert.IsType<ActionResult<ListResponse<IBaseDto>>>(result);
        var response = Assert.IsType<OkObjectResult>(okResult.Result);
        var listResponse = Assert.IsType<ListResponse<IBaseDto>>(response.Value);
        Assert.True(listResponse.Succes);
        Assert.Empty(listResponse.Data);
    }

    [Fact]
    public async Task Create_ReturnsCreatedResult_WhenServiceReturnsValidDocument()
    {
        var dto = Mock.Of<IBaseDto>();
        var entity = Mock.Of<IEntityBase>();
        var document = Mock.Of<IDocumentBase>();
        Mock.Get(document).Setup(d => d.Guid).Returns("test-guid");

        _mockFactory.Setup(f => f.FromDto(dto)).Returns(entity);
        _mockService.Setup(s => s.InsertAsync(It.IsAny<IDocumentBase>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(document);

        var result = await _controller.Create<IBaseDto, IEntityBase, IDocumentBase>(dto, CancellationToken.None);

        var createdResult = Assert.IsType<ActionResult<Response<IBaseDto>>>(result);
        var response = Assert.IsType<CreatedResult>(createdResult.Result);
        var responseValue = Assert.IsType<Response<IBaseDto>>(response.Value);
        Assert.True(responseValue.Succes);
        Assert.Equal(dto, responseValue.Data);
        Assert.Equal("/api/test-guid", response.Location);
    }

    [Fact]
    public async Task Create_ReturnsBadRequest_WhenServiceReturnsNull()
    {
        var dto = Mock.Of<IBaseDto>();
        var entity = Mock.Of<IEntityBase>();

        _mockFactory.Setup(f => f.FromDto(dto)).Returns(entity);
        _mockService.Setup(s => s.InsertAsync(It.IsAny<IDocumentBase>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((IDocumentBase)null);

        var result = await _controller.Create<IBaseDto, IEntityBase, IDocumentBase>(dto, CancellationToken.None);

        var badRequestResult = Assert.IsType<ActionResult<Response<IBaseDto>>>(result);
        var response = Assert.IsType<BadRequestObjectResult>(badRequestResult.Result);
        var responseValue = Assert.IsType<Response<IBaseDto>>(response.Value);
        Assert.False(responseValue.Succes);
    }

    [Fact]
    public async Task Update_ReturnsOkResult_WhenIdMatchesAndServiceReturnsValidDocument()
    {
        var id = "test-id";
        var dto = Mock.Of<IBaseDto>();
        Mock.Get(dto).Setup(d => d.Guid).Returns(id);
        var entity = Mock.Of<IEntityBase>();
        var document = Mock.Of<IDocumentBase>();

        _mockFactory.Setup(f => f.FromDto(dto)).Returns(entity);
        _mockService.Setup(s => s.UpdateAsync(It.IsAny<IDocumentBase>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(document);

        var result = await _controller.Update<IBaseDto, IEntityBase, IDocumentBase>(id, dto, CancellationToken.None);

        var okResult = Assert.IsType<ActionResult<Response<IBaseDto>>>(result);
        var response = Assert.IsType<OkObjectResult>(okResult.Result);
        var responseValue = Assert.IsType<Response<IBaseDto>>(response.Value);
        Assert.True(responseValue.Succes);
        Assert.Equal(dto, responseValue.Data);
    }

    [Fact]
    public async Task Update_ReturnsBadRequest_WhenIdDoesNotMatch()
    {
        const string id = "test-id";
        var dto = Mock.Of<IBaseDto>();
        Mock.Get(dto).Setup(d => d.Guid).Returns("different-id");

        var result = await _controller.Update<IBaseDto, IEntityBase, IDocumentBase>(id, dto, CancellationToken.None);

        var badRequestResult = Assert.IsType<ActionResult<Response<IBaseDto>>>(result);
        var response = Assert.IsType<BadRequestObjectResult>(badRequestResult.Result);
        var responseValue = Assert.IsType<Response<IBaseDto>>(response.Value);
        Assert.False(responseValue.Succes);
    }

    [Fact]
    public async Task Update_ReturnsNotFound_WhenServiceReturnsNull()
    {
        const string id = "test-id";
        var dto = Mock.Of<IBaseDto>();
        Mock.Get(dto).Setup(d => d.Guid).Returns(id);
        var entity = Mock.Of<IEntityBase>();

        _mockFactory.Setup(f => f.FromDto(dto)).Returns(entity);
        _mockService.Setup(s => s.UpdateAsync(It.IsAny<IDocumentBase>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((IDocumentBase)null);

        var result = await _controller.Update<IBaseDto, IEntityBase, IDocumentBase>(id, dto, CancellationToken.None);

        var notFoundResult = Assert.IsType<ActionResult<Response<IBaseDto>>>(result);
        var response = Assert.IsType<NotFoundObjectResult>(notFoundResult.Result);
        var responseValue = Assert.IsType<Response<IBaseDto>>(response.Value);
        Assert.False(responseValue.Succes);
    }

    [Fact]
    public async Task Delete_ReturnsNoContent_WhenCalled()
    {
        const string id = "test-id";

        var result = await _controller.Delete<IBaseDto, IEntityBase, IDocumentBase>(id, CancellationToken.None);

        var noContentResult = Assert.IsType<ActionResult<Response<IBaseDto>>>(result);
        Assert.IsType<NoContentResult>(noContentResult.Result);
        _mockService.Verify(s => s.DeleteAsync(id, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GetById_ReturnsOkResult_WhenServiceReturnsEntity()
    {
        const string id = "test-id";
        var entity = Mock.Of<IEntityBase>();
        var dto = Mock.Of<IBaseDto>();

        _mockService.Setup(s => s.GetByIdAsync(id, It.IsAny<CancellationToken>())).ReturnsAsync(entity);
        _mockFactory.Setup(f => f.ToDto(entity)).Returns(dto);

        var result = await _controller.GetById<IBaseDto, IEntityBase, IDocumentBase>(id, CancellationToken.None);

        var okResult = Assert.IsType<ActionResult<Response<IBaseDto>>>(result);
        var response = Assert.IsType<OkObjectResult>(okResult.Result);
        var responseValue = Assert.IsType<Response<IBaseDto>>(response.Value);
        Assert.True(responseValue.Succes);
        Assert.Equal(dto, responseValue.Data);
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenServiceReturnsNull()
    {
        const string id = "test-id";

        _mockService.Setup(s => s.GetByIdAsync(id, It.IsAny<CancellationToken>())).ReturnsAsync((IEntityBase)null);
        _mockFactory.Setup(f => f.ToDto(null)).Returns((IBaseDto)null);

        var result = await _controller.GetById<IBaseDto, IEntityBase, IDocumentBase>(id, CancellationToken.None);

        var notFoundResult = Assert.IsType<ActionResult<Response<IBaseDto>>>(result);
        var response = Assert.IsType<NotFoundObjectResult>(notFoundResult.Result);
        var responseValue = Assert.IsType<Response<IBaseDto>>(response.Value);
        Assert.False(responseValue.Succes);
    }

    [Fact]
    public void CreateDocument_CreatesDocumentWithMatchingGuid_WhenEntityHasGuid()
    {
        const string entityGuid = "test-guid";
        var entity = Mock.Of<IEntityBase>();
        Mock.Get(entity).Setup(e => e.Guid).Returns(entityGuid);

        var result = _controller.CreateDocument<IEntityBase, TestDocument>(entity);

        Assert.NotNull(result);
        Assert.Equal(entityGuid, result.Guid);
    }

    private class TestDocument : IDocumentBase
    {
        public string Guid { get; set; } = string.Empty;
        public long CreatedAtUnixTimestamp { get; set; }
        public long UpdatedAtUnixTimestamp { get; set; }
    }
}