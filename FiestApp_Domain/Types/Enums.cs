using System.ComponentModel;

namespace FiestApp_Domain.Types;

public class Enums
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
