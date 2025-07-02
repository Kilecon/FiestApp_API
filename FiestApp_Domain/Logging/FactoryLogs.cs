using Microsoft.Extensions.Logging;

namespace FiestApp_Domain.Logging;

public static partial class FactoryLogs
{
    [LoggerMessage(LogLevel.Warning, Message = "Attempted to convert null UserEntity to UserDto",
        EventName = "ToDto.Warning")]
    public static partial void ToDtoWarning(ILogger logger);

    [LoggerMessage(LogLevel.Error, EventName = "ToDto.Error")]
    public static partial void ToDtoError(ILogger logger, Exception ex);

    [LoggerMessage(LogLevel.Warning, Message = "Attempted to convert null UserEntity to LightUserDto",
        EventName = "ToLightDto.Warning")]
    public static partial void ToLightDtoWarning(ILogger logger);

    [LoggerMessage(LogLevel.Error, EventName = "ToLightDto.Error")]
    public static partial void ToLightDtoError(ILogger logger, Exception ex);

    [LoggerMessage(LogLevel.Error, EventName = "FromDto.Error")]
    public static partial void FromDtoError(ILogger logger, Exception ex);

    [LoggerMessage(LogLevel.Error, EventName = "FromLightDto.Error")]
    public static partial void FromLightDtoError(ILogger logger, Exception ex);
}