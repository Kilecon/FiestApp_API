using System.Text.Json.Serialization;
using FiestApp_Domain.Dtos.Base;
using FiestApp_Domain.Dtos.EventDtos;

namespace FiestApp_Domain.Dtos.ShoppingDtos;

public class ShoppingListDto : BaseDto
{
    [JsonPropertyName("related_event")]
    public required EventDto RelatedEvent { get; set; }
    [JsonPropertyName("items")]
    public required IEnumerable<LightShoppingItemDto> Items { get; set; }
}
