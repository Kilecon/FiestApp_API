using FiestApp_Domain.Entities.Base;
using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities;
public sealed class EventEntity : EntityBase
{
    public required Str50Formatted Title { get; set; }
    public required Text Description { get; set; }
    public required Str255Formatted Location { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public long Date { get; set; }
    public required EntityId Creator { get; set; }
}