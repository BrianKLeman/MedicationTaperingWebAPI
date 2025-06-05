using System;
using System.Collections.Generic;

namespace DataAccessLayerCore;

public partial class JobsAtHomeLog
{
    public int JobsAtHomeLogId { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public int PersonId { get; set; }

    public DateTime? DateCompleted { get; set; }

    public int JobsAtHomeId { get; set; }
}
