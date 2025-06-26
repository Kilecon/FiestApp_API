using FiestApp_API.Dtos.Base;
using FiestApp_API.Dtos.UserDtos;
using System.Text.Json.Serialization;

namespace FiestApp_API.Dtos.EventDtos;

public class EventDto : BaseDto
{
    [JsonPropertyName("title")]
    public required string Title { get; set; }
    [JsonPropertyName("description")]
    public required string Description { get; set; }
    [JsonPropertyName("location")]
    public required string Location { get; set; }
    [JsonPropertyName("latitude")]
    public long Latitute { get; set; }
    [JsonPropertyName("longitude")]
    public long Longitude { get; set; }
    [JsonPropertyName("date")]
    public long Date { get; set; }
    [JsonPropertyName("organazer")]
    public required LightUserDto Organazer { get; set; }
}
