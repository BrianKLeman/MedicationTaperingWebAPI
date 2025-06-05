using System;
using System.Collections.Generic;

namespace DataAccessLayerCore;

public partial class AdhocDetail
{
    public int Id { get; set; }

    public int AdhocTableId { get; set; }

    public int AdhocTableRowId { get; set; }

    public int AdhocTableColumnId { get; set; }

    public string? Details { get; set; }

    public virtual AdhocTable AdhocTable { get; set; } = null!;

    public virtual AdhocTableColumn AdhocTableColumn { get; set; } = null!;

    public virtual AdhocTableRow AdhocTableRow { get; set; } = null!;
}
