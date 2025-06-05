using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Index("ID", Name = "ID_UNIQUE", IsUnique = true)]
public partial class group
{
    [Key]
    public int ID { get; set; }

    [StringLength(45)]
    public string? NAME { get; set; }

    public int PERSON_ID { get; set; }
}
