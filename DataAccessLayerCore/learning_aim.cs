using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

public partial class learning_aim
{
    [Key]
    public int LEARNING_AIM_ID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATED_DATE { get; set; }

    [StringLength(45)]
    public string? NAME { get; set; }

    [StringLength(255)]
    public string? DESCRIPTION { get; set; }

    public int? PERSON_ID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ACHIEVED_DATE { get; set; }

    [Precision(10, 5)]
    public decimal? PRIORITY_WEIGHT { get; set; }
}
