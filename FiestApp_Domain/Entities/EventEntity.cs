using FiestApp_Domain.Entities;
using FiestApp_Domain.Types;

namespace FiestApp_Infrastructure.Documents;
public class EventEntity : EntityBase
{
    public required Title Title { get; set; }
    public required Description Description { get; set; }
    public required Location Location { get; set; }
    public long Date { get; set; }
    public required string Creator { get; set; }
}