using FiestApp_API.Response;
using FiestApp_Domain.Dtos.Base;
using FiestApp_Domain.Entities.Base;
using FiestApp_Infrastructure.Documents.Base;
using Microsoft.AspNetCore.Mvc;

namespace FiestApp_API.Controllers;

/// <summary>
/// Base controller interface with light dto.
/// </summary>
public interface ILightBaseController
{
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TE"></typeparam>
    /// <typeparam name="TD"></typeparam>
    /// <typeparam name="TI"></typeparam>
    /// <returns></returns>
    public Task<ActionResult<Response<T>>> GetById<T, TE, TD, TI>(string id, CancellationToken cancellationToken)
        where T : IBaseDto where TE : IEntityBase where TD : IDocumentBase where TI : IBaseDto;
    
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TE"></typeparam>
    /// <typeparam name="TD"></typeparam>
    /// <typeparam name="TI"></typeparam>
    /// <returns></returns>
    public Task<ActionResult<ListResponse<T>>> GetAll<T, TE, TD, TI>(CancellationToken cancellationToken)
        where T : IBaseDto where TE : IEntityBase where TD : IDocumentBase where TI : IBaseDto;
    
    /// <param name="dto"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TE"></typeparam>
    /// <typeparam name="TD"></typeparam>
    /// <typeparam name="TI"></typeparam>
    /// <returns></returns>
    public Task<ActionResult<Response<T>>> Create<T, TE, TD, TI>([FromBody] T dto, CancellationToken cancellationToken)
        where T : IBaseDto where TE : IEntityBase where TD : IDocumentBase where TI : IBaseDto;
    
    /// <param name="id"></param>
    /// <param name="dto"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TE"></typeparam>
    /// <typeparam name="TD"></typeparam>
    /// <typeparam name="TI"></typeparam>
    /// <returns></returns>
    public Task<ActionResult<Response<T>>> Update<T, TE, TD, TI>(string id, [FromBody] T dto,
        CancellationToken cancellationToken) where T : IBaseDto
        where TE : IEntityBase
        where TD : IDocumentBase
        where TI : IBaseDto;
    
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TE"></typeparam>
    /// <typeparam name="TD"></typeparam>
    /// <typeparam name="TI"></typeparam>
    /// <returns></returns>
    public Task<ActionResult<Response<T>>> Delete<T, TE, TD, TI>(string id, CancellationToken cancellationToken)
        where T : IBaseDto where TE : IEntityBase where TD : IDocumentBase where TI : IBaseDto;
    
    /// <param name="entity"></param>
    /// <typeparam name="TE"></typeparam>
    /// <typeparam name="TD"></typeparam>
    /// <returns></returns>
    public TD CreateDocument<TE, TD>(TE entity)
        where TE : IEntityBase
        where TD : IDocumentBase;
}