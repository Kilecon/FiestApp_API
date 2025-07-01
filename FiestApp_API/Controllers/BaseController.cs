using FiestApp_API.Response;
using FiestApp_API.Services.Base;
using FiestApp_Domain.Dtos.Base;
using FiestApp_Domain.Entities.Base;
using FiestApp_Domain.Factories.Base;
using FiestApp_Infrastructure.Documents.Base;
using Microsoft.AspNetCore.Mvc;

namespace FiestApp_API.Controllers;

public class BaseController(
    IService<IDocumentBase, IEntityBase> service,
    IFactoryBase<IEntityBase, IBaseDto> factory) : ControllerBase, IBaseController
{
    /// <inheritdoc />
    public virtual async Task<ActionResult<ListResponse<T>>> GetAll<T, TE, TD>(CancellationToken cancellationToken)
        where T : IBaseDto where TE : IEntityBase where TD : IDocumentBase
    {
        var data = await service.GetAllAsync(cancellationToken);
        return Ok(new ListResponse<T>
        {
            Data = data.Select(factory.ToDto).Cast<T>(),
            Succes = true
        });
    }

    /// <inheritdoc />
    public virtual async Task<ActionResult<Response<T>>> Create<T, TE, TD>(T dto, CancellationToken cancellationToken)
        where T : IBaseDto where TE : IEntityBase where TD : IDocumentBase
    {
        var entity = factory.FromDto(dto);
        var doc = CreateDocument<TE, TD>((TE)entity);

        var result = await service.InsertAsync(doc, cancellationToken);
        Response<T> response = new()
        {
            Data = dto,
            Succes = result != null
        };

        if (result == null)
            return BadRequest(response);

        return Created($"/api/{result.Guid}", response);
    }

    /// <inheritdoc />
    public async Task<ActionResult<Response<T>>> Update<T, TE, TD>(string id, T dto,
        CancellationToken cancellationToken)
        where T : IBaseDto where TE : IEntityBase where TD : IDocumentBase
    {
        if (dto.Guid != id)
            return BadRequest(new Response<T>
            {
                Data = default,
                Succes = false
            });
        var entity = factory.FromDto(dto);
        var doc = CreateDocument<TE, TD>((TE)entity);

        var result = await service.UpdateAsync(doc, cancellationToken);
        Response<T> response = new()
        {
            Data = dto,
            Succes = result != null
        };

        if (result == null)
            return NotFound(response);

        return Ok(response);
    }

    /// <inheritdoc />
    public async Task<ActionResult<Response<T>>> Delete<T, TE, TD>(string id, CancellationToken cancellationToken)
        where T : IBaseDto where TE : IEntityBase where TD : IDocumentBase
    {
        await service.DeleteAsync(id, cancellationToken);
        return NoContent();
    }

    /// <inheritdoc />
    public virtual async Task<ActionResult<Response<T>>> GetById<T, TE, TD>(string id,
        CancellationToken cancellationToken)
        where T : IBaseDto
        where TE : IEntityBase
        where TD : IDocumentBase
    {
        var data = await service.GetByIdAsync(id, cancellationToken);
        var dto = factory.ToDto(data);
        Response<T> response = new()
        {
            Data = (T)dto!,
            Succes = data != null
        };

        if (data == null) return NotFound(response);

        return Ok(response);
    }

    /// <param name="entity"></param>
    /// <typeparam name="TE"></typeparam>
    /// <typeparam name="TD"></typeparam>
    /// <returns></returns>
    public virtual TD CreateDocument<TE, TD>(TE entity)
        where TE : IEntityBase
        where TD : IDocumentBase
    {
        var doc = (TD)Activator.CreateInstance(typeof(TD))!;

        if (doc is IDocumentBase docBase && entity is IEntityBase entityBase) docBase.Guid = entityBase.Guid;
        return doc;
    }
}