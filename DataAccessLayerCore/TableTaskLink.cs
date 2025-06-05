using System;
using System.Collections.Generic;

namespace DataAccessLayerCore;

public partial class TableTaskLink
{
    public int TableTaskLinksId { get; set; }

    public string? TableName { get; set; }

    public int? EntityId { get; set; }

    public int? TaskId { get; set; }

    public int? PersonId { get; set; }
}
