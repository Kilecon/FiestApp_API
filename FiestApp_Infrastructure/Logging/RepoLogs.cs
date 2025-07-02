using Microsoft.Extensions.Logging;

namespace FiestApp_Infrastructure.Logging;

public static partial class RepoLogs
{
    [LoggerMessage(
        Level = LogLevel.Error,
        EventName = "PartialUpdateManyAsync.Error",
        Message = "Error during partial multiple update")]
    public static partial void PartialUpdateManyAsyncError(ILogger logger, Exception ex);

    [LoggerMessage(Level = LogLevel.Error, EventName = "PartialUpdateAsync.Error",
        Message = "Error during partial update")]
    public static partial void PartialUpdateAsyncError(ILogger logger, Exception ex);

    [LoggerMessage(
        Level = LogLevel.Error,
        EventName = "DeleteAsync.Error",
        Message = "Error during deletion")]
    public static partial void DeleteAsyncError(ILogger logger, Exception ex);

    [LoggerMessage(
        Level = LogLevel.Error,
        EventName = "InsertAsync.Error",
        Message = "Error during insertion")]
    public static partial void InsertAsyncError(ILogger logger, Exception ex);

    [LoggerMessage(
        Level = LogLevel.Error,
        EventName = "InsertManyAsync.Error",
        Message = "Error during multiple insertion")]
    public static partial void InsertManyAsyncError(ILogger logger, Exception ex);

    [LoggerMessage(
        Level = LogLevel.Error,
        EventName = "UpdateAsync.Error",
        Message = "Error during update")]
    public static partial void UpdateAsyncError(ILogger logger, Exception ex);

    [LoggerMessage(
        Level = LogLevel.Error,
        EventName = "UpdateManyAsync.Error",
        Message = "Error during multiple update")]
    public static partial void UpdateManyAsyncError(ILogger logger, Exception ex);

    [LoggerMessage(
        Level = LogLevel.Error,
        EventName = "DeleteByIdAsync.Error",
        Message = "Error during deletion by ID")]
    public static partial void DeleteByIdAsyncError(ILogger logger, Exception ex);

    [LoggerMessage(
        Level = LogLevel.Error,
        EventName = "DeleteManyAsync.Error",
        Message = "Error during multiple deletion")]
    public static partial void DeleteManyAsyncError(ILogger logger, Exception ex);
}