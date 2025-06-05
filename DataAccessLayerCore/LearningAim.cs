using System;
using System.Collections.Generic;

namespace DataAccessLayerCore;

public partial class LearningAim
{
    public int LearningAimId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? PersonId { get; set; }

    public DateTime? AchievedDate { get; set; }

    public decimal? PriorityWeight { get; set; }
}
