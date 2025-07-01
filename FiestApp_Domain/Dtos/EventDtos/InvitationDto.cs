using System.Text.Json.Serialization;
using FiestApp_Domain.Dtos.Base;
using FiestApp_Domain.Dtos.UserDtos;

namespace FiestApp_Domain.Dtos.EventDtos;

public class InvitationDto : StatuedDto
{
    [JsonPropertyName("user")]
    public required LightUserDto UserInvited { get; set; }
    [JsonPropertyName("event")]
    public required EventDto Event { get; set; }
}