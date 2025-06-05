using System;
using System.Collections.Generic;

namespace DataAccessLayerCore;

public partial class AdhocTable
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public int ProjectId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<AdhocDetail> AdhocDetails { get; set; } = new List<AdhocDetail>();

    public virtual ICollection<AdhocTableColumn> AdhocTableColumns { get; set; } = new List<AdhocTableColumn>();

    public virtual ICollection<AdhocTableRow> AdhocTableRows { get; set; } = new List<AdhocTableRow>();
}
