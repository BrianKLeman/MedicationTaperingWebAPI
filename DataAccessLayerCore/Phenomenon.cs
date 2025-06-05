using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

public partial class phenomenon
{
    [Key]
    public uint PHENOMENA_ID { get; set; }

    [Column(TypeName = "text")]
    public string? PHENOMENA_DETAILS { get; set; }

    [StringLength(3)]
    public string? CREATED_USER { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CREATED_DATE { get; set; }

    [StringLength(3)]
    public string? UPDATED_BY { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UPDATED_DATE { get; set; }

    public int LOCKED_TO_PERSON_ID { get; set; }
}
