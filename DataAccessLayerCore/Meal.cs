using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Index("MEALS_ID", Name = "MEALS_ID_UNIQUE", IsUnique = true)]
public partial class meal
{
    [Key]
    public int MEALS_ID { get; set; }

    [StringLength(255)]
    public string? DETAILS { get; set; }

    public int? PEOPLE_ID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATED_DATE { get; set; }

    [StringLength(3)]
    public string? CREATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EATEN_DATE { get; set; }
}
