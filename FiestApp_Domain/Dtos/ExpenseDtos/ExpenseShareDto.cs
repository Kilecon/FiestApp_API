using System.Text.Json.Serialization;
using FiestApp_Domain.Dtos.Base;
using FiestApp_Domain.Dtos.UserDtos;

namespace FiestApp_Domain.Dtos.ExpenseDtos;

public class ExpenseShareDto : BaseDto
{
    [JsonPropertyName("expense")]
    public required ExpenseDto Expense { get; set; }
    [JsonPropertyName("assigned_to")]
    public required LightUserDto AssignedTo { get; set; }
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }
}
