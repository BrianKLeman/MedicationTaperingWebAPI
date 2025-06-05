using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Index("TASK_ID", Name = "TASK_ID_UNIQUE", IsUnique = true)]
public partial class task
{
    [Key]
    public int TASK_ID { get; set; }

    [StringLength(255)]
    public string? TASK_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATED_DATE { get; set; }

    public int? CREATED_BY { get; set; }

    public int? PERSON_ID { get; set; }

    [StringLength(45)]
    public string? STATUS { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DUE_DATE { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DATE_COMPLETED { get; set; }

    [Precision(10, 0)]
    public decimal? PRIORITY { get; set; }

    [StringLength(255)]
    public string? DESCRIPTION { get; set; }

    public sbyte? PERSONAL { get; set; }

    public int? ESTIMATE { get; set; }

    public sbyte REQUIRES_LEARNING { get; set; }

    [Column(TypeName = "text")]
    public string? ACCEPTANCE_CRITERIA { get; set; }

    public int DIFFICULTY { get; set; }
}
