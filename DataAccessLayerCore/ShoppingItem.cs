using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("shopping_items")]
[Index("Id", Name = "ITEM_LIST_ID_UNIQUE", IsUnique = true)]
public partial class ShoppingItem  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("ITEM_NAME")]
    [StringLength(45)]
    public string? ItemName { get; set; }

    [Column("STATUS")]
    [StringLength(45)]
    public string? Status { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("DATE_CHECKED", TypeName = "datetime")]
    public DateTime? DateChecked { get; set; }

    [Column("CREATED_DATE", TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column("CREATED_BY")]
    [StringLength(45)]
    public string? CreatedBy { get; set; }

    [Column("PERSONAL")]
    public sbyte? Personal { get; set; }
}
