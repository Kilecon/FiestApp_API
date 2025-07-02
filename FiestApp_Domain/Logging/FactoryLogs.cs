using Microsoft.Extensions.Logging;

namespace FiestApp_Domain.Logging;

public static partial class FactoryLogs
{
    [LoggerMessage(LogLevel.Warning, Message = "Attempted to convert null UserEntity to UserDto",
        EventName = "ToDto.Warning")]
    public static partial void ToDtoWarning(ILogger logger);

    [LoggerMessage(LogLevel.Warning, Message = "Attempted to convert null UserEntity to LightUserDto",
        EventName = "ToLightDto.Warning")]
    public static partial void ToLightDtoWarning(ILogger logger);
}