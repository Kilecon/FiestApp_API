﻿using System.Text.Json.Serialization;
using FiestApp_Domain.Dtos.Base;
using FiestApp_Domain.Dtos.UserDtos;

namespace FiestApp_Domain.Dtos.EventDtos;

public class EventDto : BaseDto
{
    [JsonPropertyName("title")]
    public required string Title { get; set; }
    [JsonPropertyName("description")]
    public required string Description { get; set; }
    [JsonPropertyName("location")]
    public required string Location { get; set; }
    [JsonPropertyName("latitude")]
    public decimal Latitute { get; set; }
    [JsonPropertyName("longitude")]
    public decimal Longitude { get; set; }
    [JsonPropertyName("date")]
    public long Date { get; set; }
    [JsonPropertyName("organazer")]
    public required LightUserDto Organazer { get; set; }
}
