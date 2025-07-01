namespace FiestApp_Infrastructure.Documents.Base;

public interface IDocumentBase
{
    string Guid { get; set; }
    long CreatedAtUnixTimestamp { get; set; }
    long UpdatedAtUnixTimestamp { get; set; }
}

