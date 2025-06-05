using System;
using System.Collections.Generic;

namespace DataAccessLayerCore;

public partial class JobsAtHomeSummary
{
    public int? PersonId { get; set; }

    public int JobId { get; set; }

    public string? Job { get; set; }

    public DateTime? DateCompleted { get; set; }
}
