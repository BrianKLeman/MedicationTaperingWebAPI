using System;
using System.Collections.Generic;

namespace DataAccessLayerCore;

public partial class AdhocTableColumn
{
    public int Id { get; set; }

    public int AdhocTableId { get; set; }

    public string? Name { get; set; }

    public int Order { get; set; }

    public virtual ICollection<AdhocDetail> AdhocDetails { get; set; } = new List<AdhocDetail>();

    public virtual AdhocTable AdhocTable { get; set; } = null!;
}
