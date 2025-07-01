using System.Text.Json.Serialization;
using FiestApp_Domain.Dtos.Base;

namespace FiestApp_Domain.Dtos.PollDtos;

public class LightPollOptionDto : BaseDto
{

    [JsonPropertyName("option")]
    public required string Option { get; set; }
}
