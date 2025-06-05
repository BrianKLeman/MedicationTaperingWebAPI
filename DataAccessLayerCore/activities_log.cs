using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Table("activities_log")]
[Index("ACTIVITIES_LOG_ID", Name = "ACTIVITIES_LOG_ID_UNIQUE", IsUnique = true)]
public partial class activities_log
{
    [Key]
    public int ACTIVITIES_LOG_ID { get; set; }

    public int? PERSON_ID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DATE_COMPLETED { get; set; }

    [StringLength(3)]
    public string? CREATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATED_DATE { get; set; }

    public int ACTIVITIES_ID { get; set; }
}
