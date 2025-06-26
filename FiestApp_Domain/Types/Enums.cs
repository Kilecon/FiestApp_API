using System.ComponentModel;

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

}
