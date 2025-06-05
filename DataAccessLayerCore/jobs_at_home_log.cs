using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Table("jobs_at_home_log")]
[Index("JOBS_AT_HOME_LOG_ID", Name = "JOBS_AT_HOME_LOG_ID_UNIQUE", IsUnique = true)]
public partial class jobs_at_home_log
{
    [Key]
    public int JOBS_AT_HOME_LOG_ID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    [StringLength(45)]
    public string CREATED_BY { get; set; } = null!;

    public int PERSON_ID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DATE_COMPLETED { get; set; }

    public int JOBS_AT_HOME_ID { get; set; }
}
