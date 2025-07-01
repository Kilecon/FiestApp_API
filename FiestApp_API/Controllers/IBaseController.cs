using FiestApp_API.Dtos.Base;
using FiestApp_API.Response;
using FiestApp_Domain.Entities.Base;
using FiestApp_Infrastructure.Documents.Base;
using Microsoft.AspNetCore.Mvc;

namespace FiestApp_API.Controllers;

public interface IBaseController
{
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TE"></typeparam>
    /// <typeparam name="TD"></typeparam>
    /// <returns></returns>
    public Task<ActionResult<Response<T>>> GetById<T, TE, TD>(string id, CancellationToken cancellationToken)
        where T : IBaseDto where TE : IEntityBase where TD : IDocumentBase;

    /// <summary>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TE"></typeparam>
    /// <typeparam name="TD"></typeparam>
    /// <returns></returns>
    public Task<ActionResult<ListResponse<T>>> GetAll<T, TE, TD>(CancellationToken cancellationToken)
        where T : IBaseDto where TE : IEntityBase where TD : IDocumentBase;

    /// <param name="dto"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TE"></typeparam>
    /// <typeparam name="TD"></typeparam>
    /// <returns></returns>
    public Task<ActionResult<Response<T>>> Create<T, TE, TD>([FromBody] T dto, CancellationToken cancellationToken)
        where T : IBaseDto where TE : IEntityBase where TD : IDocumentBase;

    /// <param name="id"></param>
    /// <param name="dto"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TE"></typeparam>
    /// <typeparam name="TD"></typeparam>
    /// <returns></returns>
    public Task<ActionResult<Response<T>>> Update<T, TE, TD>(string id, [FromBody] T dto,
        CancellationToken cancellationToken) where T : IBaseDto where TE : IEntityBase where TD : IDocumentBase;

    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TE"></typeparam>
    /// <typeparam name="TD"></typeparam>
    /// <returns></returns>
    public Task<ActionResult<Response<T>>> Delete<T, TE, TD>(string id, CancellationToken cancellationToken)
        where T : IBaseDto where TE : IEntityBase where TD : IDocumentBase;

    /// <param name="entity"></param>
    /// <typeparam name="TE"></typeparam>
    /// <typeparam name="TD"></typeparam>
    /// <returns></returns>
    public TD CreateDocument<TE, TD>(TE entity)
        where TE : IEntityBase
        where TD : IDocumentBase;
}