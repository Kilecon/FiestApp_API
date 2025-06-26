using FiestApp_API.Dtos.Base;
using FiestApp_API.Dtos.EventDtos;
using System.Text.Json.Serialization;

namespace FiestApp_API.Dtos.PollDtos;
public class PollDto : StatuedDto
{
    [JsonPropertyName("event")]
    public required EventDto Event { get; set; }
    [JsonPropertyName("question")]
    public required string Question { get; set; }
    [JsonPropertyName("poll_options")]
    public required IEnumerable<LightPollOptionDto> PollOptions { get; set; }
}