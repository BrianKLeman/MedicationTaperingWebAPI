using System;
using System.Collections.Generic;

namespace DataAccessLayerCore;

public partial class ActivitiesLog
{
    public int ActivitiesLogId { get; set; }

    public int? PersonId { get; set; }

    public DateTime? DateCompleted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int ActivitiesId { get; set; }
}
