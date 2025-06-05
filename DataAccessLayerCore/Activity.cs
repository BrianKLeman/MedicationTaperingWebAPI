using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

public partial class activity
{
    [Key]
    public int ACTIVITY_ID { get; set; }

    [StringLength(255)]
    public string? DETAILS { get; set; }

    public int? PERSON_ID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATED_DATE { get; set; }

    [StringLength(3)]
    public string? CREATED_BY { get; set; }
}
