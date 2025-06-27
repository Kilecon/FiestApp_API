using FiestApp_API.Dtos.Base;
using System.Text.Json.Serialization;

namespace FiestApp_API.Dtos.PollDtos;

public class LightPollOptionDto : BaseDto
{

    [JsonPropertyName("option")]
    public required string Option { get; set; }
}
