using System.Text.Json.Serialization;
using FiestApp_Domain.Dtos.Base;

namespace FiestApp_API.Response;

public class Response<T> where T : IBaseDto
{
    [JsonPropertyName("succes")]
    public bool Succes { get; set; }

    [JsonPropertyName("data")]
    public T? Data { get; set; }
}
