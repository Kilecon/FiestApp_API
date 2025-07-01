using System.Text.Json.Serialization;
using FiestApp_Domain.Dtos.ExpenseDtos;
using FiestApp_Domain.Dtos.UserDtos;

namespace FiestApp_Domain.Dtos.EventDtos;

public class DetailledEventDto : EventDto
{
    [JsonPropertyName("paticipants")]
    public required IEnumerable<LightUserDto> Participants { get; set; }
    [JsonPropertyName("expenses")]
    public required IEnumerable<ExpenseDtoWithoutEventId> Expenses { get; set; }
}
