using FiestApp_API.Dtos.Base;
using FiestApp_API.Dtos.EventDtos;
using FiestApp_API.Dtos.UserDtos;
using System.Text.Json.Serialization;

namespace FiestApp_API.Dtos.AccommodationDtos;

public class AccommodationDto : StatuedDto
{
    [JsonPropertyName("event")]
    public required EventDto Event { get; set; }
    [JsonPropertyName("host")]
    public required LightUserDto Host { get; set; }
    [JsonPropertyName("guest")]
    public required LightUserDto Guest { get; set; }
}
