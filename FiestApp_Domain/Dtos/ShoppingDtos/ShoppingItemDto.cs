using System.Text.Json.Serialization;
using FiestApp_Domain.Dtos.Base;
using FiestApp_Domain.Dtos.UserDtos;

namespace FiestApp_Domain.Dtos.ShoppingDtos;

public class ShoppingItemDto : BaseDto
{
    [JsonPropertyName("list_id")]
    public required string ListGuid { get; set; }
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
    [JsonPropertyName("icon_id")]
    public required string IconId { get; set; }
    [JsonPropertyName("assigned_to")]
    public required LightUserDto AssignedTo { get; set; }
    [JsonPropertyName("is_bought")]
    public bool IsBought { get; set; }
}
