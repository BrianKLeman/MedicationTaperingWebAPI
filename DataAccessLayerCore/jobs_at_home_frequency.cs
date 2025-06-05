using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Keyless]
public partial class jobs_at_home_frequency
{
    [StringLength(45)]
    public string? job { get; set; }

    public long amount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATED_DATE { get; set; }
}
