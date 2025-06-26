using FiestApp_Infrastructure.Documents.Base;
using System.ComponentModel.DataAnnotations;

namespace FiestApp_Infrastructure.Documents;
public class EventDocument : DocumentBase
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Location { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public long Date { get; set; }
    [Key]
    [StringLength(36, MinimumLength = 36)]
    public required string Creator { get; set; }
}