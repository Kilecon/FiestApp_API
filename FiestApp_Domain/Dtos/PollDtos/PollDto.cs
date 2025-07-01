using System.Text.Json.Serialization;
using FiestApp_Domain.Dtos.Base;
using FiestApp_Domain.Dtos.EventDtos;

namespace FiestApp_Domain.Dtos.PollDtos;
public class PollDto : StatuedDto
{
    [JsonPropertyName("event")]
    public required EventDto Event { get; set; }
    [JsonPropertyName("question")]
    public required string Question { get; set; }
    [JsonPropertyName("poll_options")]
    public required IEnumerable<LightPollOptionDto> PollOptions { get; set; }
    [JsonPropertyName("creation_date")]
    public long CreatedAt { get; set; }
}