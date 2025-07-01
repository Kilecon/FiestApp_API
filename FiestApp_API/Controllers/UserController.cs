using FiestApp_API.Response;
using FiestApp_API.Services.Users;
using FiestApp_Domain.Dtos.UserDtos;
using FiestApp_Domain.Factories;
using FiestApp_Infrastructure.Documents;
using Microsoft.AspNetCore.Mvc;

namespace FiestApp_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    /// <summary>
    /// Get user by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Response<UserDto>>> GetById(string id, CancellationToken cancellationToken)
    {
        var user = await _usersService.GetByIdAsync(id, cancellationToken);
        var dto = user.ToDto();
        Response<UserDto> response = new()
        {
            Data = dto,
            Succes = user != null
        };

        if (dto == null)
            return NotFound(response);

        return Ok(response);
    }

    /// <summary>
    /// Get all users
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<ListResponse<UserDto>>> GetAll(CancellationToken cancellationToken)
    {
        var users = await _usersService.GetAllAsync(cancellationToken);
        return Ok(new ListResponse<UserDto>()
        {
            Data = users.Select(u => u.ToDto()),
            Succes = true
        }
        );
    }

    /// <summary>
    /// Create a new user
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Response<UserDto>>> Create([FromBody] UserDto dto, CancellationToken cancellationToken)
    {
        var entity = dto.FromDto();
        var doc = new UserDocument
        {
            Guid = entity.Guid,
            Username = entity.Username,
            Gender = entity.Gender.ToString(),
            Age = entity.Age,
            Height = entity.Height,
            Weight = entity.Weight,
            AlcoholConsumption = entity.AlcoholConsumption.ToString()
        };

        var result = await _usersService.InsertAsync(doc, cancellationToken);
        Response<UserDto> response = new()
        {
            Data = dto,
            Succes = result != null
        };
        if (result == null)
            return BadRequest(response);

        return CreatedAtAction(nameof(GetById), new { id = result.Guid }, response);
    }

    /// <summary>
    /// Update an existing user
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<Response<UserDto>>> Update(string id, [FromBody] UserDto dto, CancellationToken cancellationToken)
    {
        if (dto.Guid != id)
            return BadRequest(new Response<UserDto>()
            {
                Data = null,
                Succes = false
            });

        var entity = dto.FromDto();
        var doc = new UserDocument
        {
            Guid = entity.Guid,
            Username = entity.Username,
            Gender = entity.Gender.ToString(),
            Age = entity.Age,
            Height = entity.Height,
            Weight = entity.Weight,
            AlcoholConsumption = entity.AlcoholConsumption.ToString()
        };

        var result = await _usersService.UpdateAsync(doc, cancellationToken);
        Response<UserDto> response = new()
        {
            Data = dto,
            Succes = result != null
        };
        if (result == null)
            return NotFound(response);

        return Ok(response);
    }

    /// <summary>
    /// Delete a user
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        await _usersService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}