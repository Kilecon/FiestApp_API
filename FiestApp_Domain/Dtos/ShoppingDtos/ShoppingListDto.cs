using FiestApp_API.Dtos.Base;
using FiestApp_API.Dtos.EventDtos;
using System.Text.Json.Serialization;

namespace FiestApp_API.Dtos.ShoppingDtos;

public class ShoppingListDto : BaseDto
{
    [JsonPropertyName("related_event")]
    public required EventDto RelatedEvent { get; set; }
    [JsonPropertyName("items")]
    public required IEnumerable<LightShoppingItemDto> Items { get; set; }
}
