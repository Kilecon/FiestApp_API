using FiestApp_API.Dtos.UserDtos;
using FiestApp_API.Services.Users;
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
    public async Task<ActionResult<UserDto>> GetById(string id, CancellationToken cancellationToken)
    {
        var user = await _usersService.GetByIdAsync(id, cancellationToken);
        if (user == null)
            return NotFound();

        return Ok(user.ToDto());
    }

    /// <summary>
    /// Get all users
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll(CancellationToken cancellationToken)
    {
        var users = await _usersService.GetAllAsync(cancellationToken);
        return Ok(users.Select(u => u.ToDto()));
    }

    /// <summary>
    /// Create a new user
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<UserDto>> Create([FromBody] UserDto dto, CancellationToken cancellationToken)
    {
        var entity = dto.FromDto();
        var doc = new UserDocument
        {
            Guid = entity.Guid,
            Username = entity.Username,
            Gender = entity.Gender?.ToString(),
            Age = entity.Age,
            Height = entity.Height,
            Weight = entity.Weight,
            AlcoholConsumption = entity.AlcoholConsumption?.ToString()
        };

        var result = await _usersService.InsertAsync(doc, cancellationToken);
        if (result == null)
            return BadRequest("Could not create user");

        return CreatedAtAction(nameof(GetById), new { id = result.Guid }, result.ToDto());
    }

    /// <summary>
    /// Update an existing user
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> Update(string id, [FromBody] UserDto dto, CancellationToken cancellationToken)
    {
        if (dto.Guid != id)
            return BadRequest("Mismatched user ID");

        var entity = dto.FromDto();
        var doc = new UserDocument
        {
            Guid = entity.Guid,
            Username = entity.Username,
            Gender = entity.Gender?.ToString(),
            Age = entity.Age,
            Height = entity.Height,
            Weight = entity.Weight,
            AlcoholConsumption = entity.AlcoholConsumption?.ToString()
        };

        var result = await _usersService.UpdateAsync(doc, cancellationToken);
        if (result == null)
            return NotFound();

        return Ok(result.ToDto());
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