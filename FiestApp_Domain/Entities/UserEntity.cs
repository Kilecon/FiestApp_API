using FiestApp_Domain.Entities.Base;
using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities;
public class UserEntity : EntityBase
{
    public required Str50Formatted Username { get; set; }
    public long LastLoginAtUnixTimestamp { get; set; }
    public Enums.Gender Gender { get; set; }
    public Age Age { get; set; }
    public Height Height { get; set; }
    public Weight Weight { get; set; }
    public Enums.AlcoholConsumption AlcoholConsumption { get; set; }

    public UserEntity(Enums.Gender gender, Age age,
        Height height, Weight weight, Enums.AlcoholConsumption alcoholConsumption)
    {
        Gender = gender;
        Age = age;
        Height = height;
        Weight = weight;
        AlcoholConsumption = alcoholConsumption;
    }
}