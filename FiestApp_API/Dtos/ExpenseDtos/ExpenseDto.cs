using FiestApp_API.Dtos.Base;
using FiestApp_API.Dtos.EventDtos;
using FiestApp_API.Dtos.UserDtos;
using System.Text.Json.Serialization;

namespace FiestApp_API.Dtos.ExpenseDtos;

public class ExpenseDto : BaseDto
{
    [JsonPropertyName("event")]
    public required EventDto Event { get; set; }
    [JsonPropertyName("payer")]
    public required LightUserDto Payer { get; set; }
    [JsonPropertyName("label")]
    public required string Label { get; set; }
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }
}
