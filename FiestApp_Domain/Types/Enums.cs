using System.ComponentModel;
using System.Reflection;

namespace FiestApp_Domain.Types;

public abstract class Enums
{
    public enum AlcoholConsumption
    {
        [Description("NE")] Never,
        [Description("OC")] Occasional,

        [Description("RG")] Regular,

        [Description("VT")] Veteran,
        [Description("UN")] Unknown
    }

    public enum Gender
    {
        [Description("M")] Male,

        [Description("F")] Female,

        [Description("OT")] Other,
        [Description("PR")] Private,
        [Description("UN")] Unknown
    }

    public enum Status
    {
        [Description("PD")] Pending,

        [Description("KO")] Rejected,

        [Description("OK")] Accepted
    }

    public static string GetDescription(Enum value)
    {
        var fi = value.GetType().GetField(value.ToString());

        var attributes = (DescriptionAttribute[])fi!.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes.Length > 0)
            return attributes[0].Description;
        return value.ToString();
    }

    public static T GetEnumValueFromDescription<T>(string? description) where T : struct, Enum
    {
        if (description == null)
            return GetDefaultEnumValue<T>();

        foreach (var field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            if (attribute != null && attribute.Description == description)
                return (T)field.GetValue(null)!;

            if (attribute == null && field.Name == description)
                return (T)field.GetValue(null)!;
        }

        return GetDefaultEnumValue<T>();
    }

    private static T GetDefaultEnumValue<T>() where T : struct, Enum
    {
        foreach (var field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var attr = field.GetCustomAttribute<DescriptionAttribute>();
            if (attr?.Description == "UN" || field.Name == "Unknown") return (T)field.GetValue(null)!;
        }

        return Enum.GetValues<T>().FirstOrDefault();
    }
}