using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Table("jobs_at_home")]
public partial class jobs_at_home
{
    [Key]
    public int JOBS_AT_HOME_ID { get; set; }

    [StringLength(45)]
    public string? JOB { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATED_DATE { get; set; }

    public int? PERSON_ID { get; set; }
}
