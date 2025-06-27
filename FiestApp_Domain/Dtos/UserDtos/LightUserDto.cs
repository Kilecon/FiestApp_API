using FiestApp_API.Dtos.Base;
using System.Text.Json.Serialization;

namespace FiestApp_API.Dtos.UserDtos;

public class LightUserDto : BaseDto
{
    [JsonPropertyName("username")]
    public required string Username { get; set; }
}
