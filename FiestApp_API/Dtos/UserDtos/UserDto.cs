using FiestApp_API.Dtos.Base;
using System.Text.Json.Serialization;

namespace FiestApp_API.Dtos.UserDtos;

public class UserDto : BaseDto
{
    [JsonPropertyName("username")]
    public required string Username { get; set; }
    [JsonPropertyName("biological_gender")]
    public required string BiologicalGender { get; set; }
    [JsonPropertyName("age")]
    public int Age { get; set; }
    [JsonPropertyName("height")]
    public int Height { get; set; }
    [JsonPropertyName("weight")]
    public int Weight { get; set; }
    [JsonPropertyName("alcohol_consumption")]
    public required string AlcoholConsumption { get; set; }

}
