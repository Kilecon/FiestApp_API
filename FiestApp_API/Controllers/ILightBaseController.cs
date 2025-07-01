using FiestApp_API.Dtos.Base;
using FiestApp_API.Response;
using FiestApp_Domain.Entities.Base;
using FiestApp_Infrastructure.Documents.Base;
using Microsoft.AspNetCore.Mvc;

namespace FiestApp_API.Controllers;

/// <summary>
/// Base controller interface with light dto.
/// </summary>
public interface ILightBaseController
{
    public Task<ActionResult<Response<T>>> GetById<T, TE, TD, TI>(string id, CancellationToken cancellationToken)
        where T : IBaseDto where TE : IEntityBase where TD : IDocumentBase where TI : IBaseDto;

    public Task<ActionResult<ListResponse<T>>> GetAll<T, TE, TD, TI>(CancellationToken cancellationToken)
        where T : IBaseDto where TE : IEntityBase where TD : IDocumentBase where TI : IBaseDto;

    public Task<ActionResult<Response<T>>> Create<T, TE, TD, TI>([FromBody] T dto, CancellationToken cancellationToken)
        where T : IBaseDto where TE : IEntityBase where TD : IDocumentBase where TI : IBaseDto;

    public Task<ActionResult<Response<T>>> Update<T, TE, TD, TI>(string id, [FromBody] T dto,
        CancellationToken cancellationToken) where T : IBaseDto
        where TE : IEntityBase
        where TD : IDocumentBase
        where TI : IBaseDto;

    public Task<ActionResult<Response<T>>> Delete<T, TE, TD, TI>(string id, CancellationToken cancellationToken)
        where T : IBaseDto where TE : IEntityBase where TD : IDocumentBase where TI : IBaseDto;
}