using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Index("APPOINTMENT_ID", Name = "APPOINTMENT_ID_UNIQUE", IsUnique = true)]
public partial class appointment
{
    [Key]
    public int APPOINTMENT_ID { get; set; }

    [StringLength(45)]
    public string? APPOINTMENT_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? APPOINTMENT_DATE { get; set; }

    public int? PEOPLE_ID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATED_DATE { get; set; }

    [StringLength(3)]
    public string? CREATED_BY { get; set; }
}
