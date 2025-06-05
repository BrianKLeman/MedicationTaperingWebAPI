using System;
using System.Collections.Generic;

namespace DataAccessLayerCore;

public partial class JobsAtHomeFrequency
{
    public string? Job { get; set; }

    public long Amount { get; set; }

    public DateTime? CreatedDate { get; set; }
}
