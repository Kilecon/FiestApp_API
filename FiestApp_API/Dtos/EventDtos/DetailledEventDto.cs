using FiestApp_API.Dtos.ExpenseDtos;
using FiestApp_API.Dtos.UserDtos;
using System.Text.Json.Serialization;

namespace FiestApp_API.Dtos.EventDtos;

public class DetailledEventDto : EventDto
{
    [JsonPropertyName("paticipants")]
    public required IEnumerable<LightUserDto> Participants { get; set; }
    [JsonPropertyName("expenses")]
    public required IEnumerable<ExpenseDtoWithoutEventId> Expenses { get; set; }
}
