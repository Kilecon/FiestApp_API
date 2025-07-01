using System.ComponentModel;
using System.Reflection;

namespace FiestApp_Domain.Types;

public abstract class Enums
{
    public enum Status
    {
        [Description("PD")]
        Pending,

        [Description("KO")]
        Rejected,

        [Description("OK")]
        Accepted
    }

    public enum Gender
    {
        [Description("M")]
        Male,

        [Description("F")]
        Female,

        [Description("OT")]
        Other,
        [Description("PR")]
        Private,
        [Description("UN")]
        Unknown
    }

    public enum AlcoholConsumption
    {
        [Description("NE")]
        Never,
        [Description("OC")]
        Occasional,

        [Description("RG")]
        Regular,

        [Description("VT")]
        Veteran,
        [Description("UN")]
        Unknown
    }
    public static string GetDescription(Enum value)
    {
        FieldInfo? fi = value.GetType().GetField(value.ToString());

        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi!.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes is not null && attributes.Length > 0)
            return attributes[0].Description;
        else
            return value.ToString();
    }

    public static T GetEnumValueFromDescription<T>(string? description) where T : struct, Enum
    {
        foreach (var field in typeof(T).GetFields())
        {
            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            if (attribute != null && attribute.Description == description)
                return (T)field.GetValue(null)!;

            if (attribute == null && field.Name == description)
                return (T)field.GetValue(null)!;
        }

        throw new ArgumentException("Not found");
    }
}
