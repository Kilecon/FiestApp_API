using FiestApp_API.Dtos.Base;
using FiestApp_API.Dtos.EventDtos;
using FiestApp_API.Dtos.UserDtos;
using System.Text.Json.Serialization;

namespace FiestApp_API.Dtos.RideDtos;

public class RideDto : BaseDto
{
    [JsonPropertyName("event")]
    public required EventDto Event { get; set; }

    [JsonPropertyName("driver")]
    public required LightUserDto Driver { get; set; }

    [JsonPropertyName("passenger")]
    public required LightUserDto Passenger { get; set; }
}

