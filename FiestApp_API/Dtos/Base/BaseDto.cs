using System.Text.Json.Serialization;

namespace FiestApp_API.Dtos.Base;

public abstract class BaseDto
{
    [JsonPropertyName("id")]
    public required string Guid { get; set; }
}
