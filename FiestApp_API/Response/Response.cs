using System.Text.Json.Serialization;

namespace FiestApp_API.Response;

public abstract class Response
{
    [JsonPropertyName("succes")]
    public bool Succes { get; set; }

    [JsonPropertyName("data")]
    public required object Data { get; set; }
}
