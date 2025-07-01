using System.Text.Json.Serialization;
using FiestApp_Domain.Dtos.Base;
using FiestApp_Domain.Dtos.EventDtos;
using FiestApp_Domain.Dtos.UserDtos;

namespace FiestApp_Domain.Dtos.RideDtos;

public class DriverDto : StatuedDto
{
    [JsonPropertyName("event")]
    public required EventDto Event { get; set; }

    [JsonPropertyName("driver")]
    public required LightUserDto Driver { get; set; }
}
