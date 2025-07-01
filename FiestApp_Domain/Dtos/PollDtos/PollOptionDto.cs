using System.Text.Json.Serialization;
using FiestApp_Domain.Dtos.Base;

namespace FiestApp_Domain.Dtos.PollDtos;

public class PollOptionDto : BaseDto
{
    [JsonPropertyName("poll_id")]
    public required string PollGuid { get; set; }

    [JsonPropertyName("option")]
    public required string Option { get; set; }
}
