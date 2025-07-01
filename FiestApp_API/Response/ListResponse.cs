using FiestApp_API.Dtos.Base;
using System.Text.Json.Serialization;

namespace FiestApp_API.Response;

public class ListResponse<T> where T : IBaseDto
{
    [JsonPropertyName("succes")]
    public bool Succes { get; set; }

    [JsonPropertyName("data")]
    public required IEnumerable<T?> Data { get; set; }
}
