using System.Text.Json.Serialization;

namespace FiestApp_API.Response;

public abstract class PagedResponse : Response
{
    [JsonPropertyName("meta")]
    public required Metadata Meta { get; set; }
}
