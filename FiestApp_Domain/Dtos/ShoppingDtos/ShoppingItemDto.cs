using FiestApp_API.Dtos.Base;
using FiestApp_API.Dtos.UserDtos;
using System.Text.Json.Serialization;

namespace FiestApp_API.Dtos.ShoppingDtos;

public class ShoppingItemDto : BaseDto
{
    [JsonPropertyName("list_id")]
    public required string ListGuid { get; set; }
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
    [JsonPropertyName("assigned_to")]
    public required LightUserDto AssignedTo { get; set; }
    [JsonPropertyName("is_bought")]
    public bool IsBought { get; set; }
}
