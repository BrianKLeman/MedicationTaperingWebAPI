using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Keyless]
public partial class jobs_at_home_summary
{
    public int? PERSON_ID { get; set; }

    public int JOB_ID { get; set; }

    [StringLength(45)]
    public string? JOB { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DATE_COMPLETED { get; set; }
}
