﻿using FiestApp_Domain.Entities.Base;
using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities;

public class ShoppingListEntity : EntityBase
{
    public required EntityId EventGuid { get; set; }
    public required IEnumerable<ShoppingItemEntity> Items { get; set; }
}
