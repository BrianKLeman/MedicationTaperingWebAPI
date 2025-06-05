using System;
using System.Collections.Generic;

namespace DataAccessLayerCore;

public partial class AdhocTableRow
{
    public int Id { get; set; }

    public int AdhocTableId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<AdhocDetail> AdhocDetails { get; set; } = new List<AdhocDetail>();

    public virtual AdhocTable AdhocTable { get; set; } = null!;
}
