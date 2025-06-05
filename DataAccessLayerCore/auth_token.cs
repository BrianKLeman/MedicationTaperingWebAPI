using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Index("TOKEN_ID", Name = "TOKEN_ID_UNIQUE", IsUnique = true)]
public partial class auth_token
{
    [Key]
    public int TOKEN_ID { get; set; }

    public int? PEOPLE_ID { get; set; }

    [StringLength(45)]
    public string? AUTH_TOKEN { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TOKEN_DATE { get; set; }
}
