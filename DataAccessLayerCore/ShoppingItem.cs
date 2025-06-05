using System;
using System.Collections.Generic;

namespace DataAccessLayerCore;

public partial class ShoppingItem
{
    public int ItemId { get; set; }

    public string? ItemName { get; set; }

    public string? Status { get; set; }

    public int? PersonId { get; set; }

    public DateTime? DateChecked { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public sbyte? Personal { get; set; }
}
