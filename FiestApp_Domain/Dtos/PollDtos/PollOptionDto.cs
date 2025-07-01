using FiestApp_API.Dtos.Base;
using System.Text.Json.Serialization;

namespace FiestApp_API.Dtos.PollDtos;

public class PollOptionDto : BaseDto
{
    [JsonPropertyName("poll_id")]
    public required string PollGuid { get; set; }

    [JsonPropertyName("option")]
    public required string Option { get; set; }
}
