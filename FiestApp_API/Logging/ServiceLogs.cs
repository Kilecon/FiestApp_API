using Microsoft.Extensions.Logging;

namespace FiestApp_API.Logging;

public static partial class ServiceLogs
{
    [LoggerMessage(LogLevel.Error, EventName = "ToEntity.Error")]
    public static partial void ToEntityError(ILogger logger, Exception ex);

    [LoggerMessage(LogLevel.Error, EventName = "ToDocument.Error")]
    public static partial void ToDocumentError(ILogger logger, Exception ex);

    [LoggerMessage(LogLevel.Error, EventName = "GetAllAsync.Error")]
    public static partial void GetAllAsyncError(ILogger logger, Exception ex);

    [LoggerMessage(LogLevel.Error, EventName = "InsertManyAsync.Error")]
    public static partial void InsertManyAsyncError(ILogger logger, Exception ex);
}