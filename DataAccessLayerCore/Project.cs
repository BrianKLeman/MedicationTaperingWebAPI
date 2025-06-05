using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

public partial class project
{
    [Key]
    public int PROJECT_ID { get; set; }

    public int? PERSON_ID { get; set; }

    [StringLength(255)]
    public string? PROJECT_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATED_DATE { get; set; }

    [StringLength(45)]
    public string? CREATED_BY { get; set; }

    [Precision(10, 0)]
    public decimal? STATUS { get; set; }

    [Precision(10, 0)]
    public decimal? PRIORITY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? START_DATE { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? END_DATE { get; set; }

    [Precision(6, 3)]
    public decimal? PRIORITY_WEIGHT { get; set; }

    public sbyte? PERSONAL { get; set; }
}
