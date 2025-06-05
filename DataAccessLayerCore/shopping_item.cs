using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayerCore;

[Index("ITEM_ID", Name = "ITEM_LIST_ID_UNIQUE", IsUnique = true)]
public partial class shopping_item
{
    [Key]
    public int ITEM_ID { get; set; }

    [StringLength(45)]
    public string? ITEM_NAME { get; set; }

    [StringLength(45)]
    public string? STATUS { get; set; }

    public int? PERSON_ID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DATE_CHECKED { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATED_DATE { get; set; }

    [StringLength(45)]
    public string? CREATED_BY { get; set; }

    public sbyte? PERSONAL { get; set; }
}
