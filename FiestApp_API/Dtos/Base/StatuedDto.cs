using System.Text.Json.Serialization;

namespace FiestApp_API.Dtos.Base;

public abstract class StatuedDto : BaseDto
{
    [JsonPropertyName("status")]
    public required string Status { get; set; }
}
