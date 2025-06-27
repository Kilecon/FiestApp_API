using FiestApp_API.Dtos.Base;
using FiestApp_API.Dtos.UserDtos;
using System.Text.Json.Serialization;

namespace FiestApp_API.Dtos.EventDtos;

public class InvitationDto : StatuedDto
{
    [JsonPropertyName("user")]
    public required LightUserDto UserInvited { get; set; }
    [JsonPropertyName("event")]
    public required EventDto Event { get; set; }
}