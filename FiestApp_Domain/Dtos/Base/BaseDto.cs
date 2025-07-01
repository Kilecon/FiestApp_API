using System.Text.Json.Serialization;

namespace FiestApp_Domain.Dtos.Base;

public abstract class BaseDto : IBaseDto
{
    [JsonPropertyName("id")]
    public required string Guid { get; set; }
}
