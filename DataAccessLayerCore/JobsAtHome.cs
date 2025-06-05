using System;
using System.Collections.Generic;

namespace DataAccessLayerCore;

public partial class JobsAtHome
{
    public int JobsAtHomeId { get; set; }

    public string? Job { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? PersonId { get; set; }
}
