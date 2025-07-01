using FiestApp_API.Dtos.Base;
using FiestApp_API.Dtos.UserDtos;
using System.Text.Json.Serialization;

namespace FiestApp_API.Dtos.ExpenseDtos;

public class ExpenseShareDto : BaseDto
{
    [JsonPropertyName("expense")]
    public required ExpenseDto Expense { get; set; }
    [JsonPropertyName("assigned_to")]
    public required LightUserDto AssignedTo { get; set; }
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }
}
