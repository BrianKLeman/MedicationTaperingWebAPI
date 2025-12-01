using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("sleeps")]
[Index("Id", Name = "SLEEP_ID_UNIQUE", IsUnique = true)]
public partial class Sleep  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("CREATED_DATE", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("FROM_DATE", TypeName = "datetime")]
    public DateTime FromDate { get; set; }

    [Column("TO_DATE", TypeName = "datetime")]
    public DateTime ToDate { get; set; }
}
