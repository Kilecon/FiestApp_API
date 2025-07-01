using System.Text.Json.Serialization;
using FiestApp_Domain.Dtos.Base;
using FiestApp_Domain.Dtos.EventDtos;
using FiestApp_Domain.Dtos.UserDtos;

namespace FiestApp_Domain.Dtos.AccommodationDtos;

public class AccommodationDto : StatuedDto
{
    [JsonPropertyName("event")]
    public required EventDto Event { get; set; }
    [JsonPropertyName("host")]
    public required LightUserDto Host { get; set; }
    [JsonPropertyName("guest")]
    public LightUserDto? Guest { get; set; }
    [JsonPropertyName("available_slots")]
    public int AvailableSlots { get; set; }
}
