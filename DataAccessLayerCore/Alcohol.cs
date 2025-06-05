using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Table("alcohol")]
public partial class alcohol
{
    [Key]
    public int ALCOHOL_ID { get; set; }

    [StringLength(45)]
    public string? DETAILS { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATED_DATE { get; set; }

    [StringLength(3)]
    public string? CREATED_USER { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CONSUMED_DATE { get; set; }

    public sbyte? PERSONAL { get; set; }
}
