using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("alcohol")]
[Index("Id", Name = "ID_UNIQUE", IsUnique = true)]
public partial class Alcohol  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("DETAILS")]
    [StringLength(45)]
    public string? Details { get; set; }

    [Column("CREATED_DATE", TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column("CREATED_USER")]
    [StringLength(3)]
    public string? CreatedUser { get; set; }

    [Column("CONSUMED_DATE", TypeName = "datetime")]
    public DateTime? ConsumedDate { get; set; }

    [Column("PERSONAL")]
    public sbyte? Personal { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }
}
