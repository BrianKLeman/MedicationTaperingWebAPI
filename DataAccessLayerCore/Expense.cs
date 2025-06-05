using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

public partial class expense
{
    [Key]
    public int EXPENSES_ID { get; set; }

    [StringLength(45)]
    public string? EXPENSES_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DATE_DUE { get; set; }

    public sbyte? REOCCURING { get; set; }

    public int? ON_DAY { get; set; }

    public int? PERSON_ID { get; set; }

    [Precision(10)]
    public decimal? BALANCE { get; set; }

    [Precision(10)]
    public decimal? REGULAR_PAYMENT { get; set; }
}
