using System.Text.Json.Serialization;
using FiestApp_Domain.Dtos.Base;

namespace FiestApp_Domain.Dtos.UserDtos;

public class UserDto : IBaseDto
{
    [JsonPropertyName("id")]
    public required string Guid { get; set; }
    [JsonPropertyName("username")]
    public required string Username { get; set; }
    [JsonPropertyName("gender")]
    public string? Gender { get; set; }
    [JsonPropertyName("age")]
    public int? Age { get; set; }
    [JsonPropertyName("height")]
    public int? Height { get; set; }
    [JsonPropertyName("weight")]
    public int? Weight { get; set; }
    [JsonPropertyName("alcohol_consumption")]
    public string? AlcoholConsumption { get; set; }

}
