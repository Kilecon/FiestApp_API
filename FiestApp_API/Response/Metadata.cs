using System.Text.Json.Serialization;

namespace FiestApp_API.Response;

public sealed class Metadata
{
    [JsonPropertyName("page")]
    public int Page { get; set; }
    [JsonPropertyName("page_size")]
    public int PageSize { get; set; }
    [JsonPropertyName("total_items")]
    public int TotalItems { get; set; }
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
}
