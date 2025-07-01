using System.Text.Json.Serialization;
using FiestApp_Domain.Dtos.Base;
using FiestApp_Domain.Dtos.UserDtos;

namespace FiestApp_Domain.Dtos.ExpenseDtos;

public class ExpenseDtoWithoutEventId : BaseDto
{
    [JsonPropertyName("payer")]
    public required LightUserDto Payer { get; set; }
    [JsonPropertyName("label")]
    public required string Label { get; set; }
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }
}

