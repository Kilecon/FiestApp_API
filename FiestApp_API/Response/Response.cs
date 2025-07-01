using FiestApp_API.Dtos.Base;
using System.Text.Json.Serialization;

namespace FiestApp_API.Response;

public class Response<T> where T : IBaseDto
{
    [JsonPropertyName("succes")]
    public bool Succes { get; set; }

    [JsonPropertyName("data")]
    public T? Data { get; set; }
}
