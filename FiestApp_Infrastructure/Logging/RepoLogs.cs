using Microsoft.Extensions.Logging;

namespace FiestApp_Infrastructure.Logging;

public static partial class RepoLogs
{
    [LoggerMessage(
        Level = LogLevel.Error,
        EventName = "PartialUpdateManyAsync.Error",
        Message = "Erreur lors de la mise à jour partielle multiple")]
    public static partial void PartialUpdateManyAsyncError(ILogger logger, Exception ex);
    
    [LoggerMessage(Level = LogLevel.Error, EventName = "PartialUpdateAsync.Error", Message = "Erreur lors de la mise à jour partielle")]
    public static partial void PartialUpdateAsyncError(ILogger logger, Exception ex);
    
    [LoggerMessage(
        Level = LogLevel.Error,
        EventName = "DeleteAsync.Error",
        Message = "Erreur lors de la suppression")]
    public static partial void DeleteAsyncError(ILogger logger, Exception ex);
    
    [LoggerMessage(
        Level = LogLevel.Error,
        EventName = "InsertAsync.Error",
        Message = "Erreur lors de l'insertion")]
    public static partial void InsertAsyncError(ILogger logger, Exception ex);
    
    [LoggerMessage(
        Level = LogLevel.Error,
        EventName = "InsertManyAsync.Error",
        Message = "Erreur lors de l'insertion multiple")]
    public static partial void InsertManyAsyncError(ILogger logger, Exception ex);
    
    [LoggerMessage(
        Level = LogLevel.Error,
        EventName = "UpdateAsync.Error",
        Message = "Erreur lors de la mise à jour")]
    public static partial void UpdateAsyncError(ILogger logger, Exception ex);
    
    [LoggerMessage(
        Level = LogLevel.Error,
        EventName = "UpdateManyAsync.Error",
        Message = "Erreur lors de la mise à jour multiple")]
    public static partial void UpdateManyAsyncError(ILogger logger, Exception ex);
    
    [LoggerMessage(
        Level = LogLevel.Error,
        EventName = "DeleteByIdAsync.Error",
        Message = "Erreur lors de la suppression par ID")]
    public static partial void DeleteByIdAsyncError(ILogger logger, Exception ex);
    
    [LoggerMessage(
        Level = LogLevel.Error,
        EventName = "DeleteManyAsync.Error",
        Message = "Erreur lors de la suppression multiple")]
    public static partial void DeleteManyAsyncError(ILogger logger, Exception ex);
}