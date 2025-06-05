using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Index("ID", Name = "ID_UNIQUE", IsUnique = true)]
public partial class sprint
{
    [Key]
    public int ID { get; set; }

    public int? PERSON_ID { get; set; }

    [StringLength(45)]
    public string? NAME { get; set; }

    [StringLength(255)]
    public string? DESCRIPTION { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? START_DATE { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? END_DATE { get; set; }
}
