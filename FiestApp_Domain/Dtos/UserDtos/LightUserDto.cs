using System.Text.Json.Serialization;
using FiestApp_Domain.Dtos.Base;

namespace FiestApp_Domain.Dtos.UserDtos;

public class LightUserDto : BaseDto
{
    [JsonPropertyName("username")]
    public required string Username { get; set; }
}
