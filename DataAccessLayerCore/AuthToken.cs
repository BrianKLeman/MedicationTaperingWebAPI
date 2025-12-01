using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("auth_tokens")]
[Index("Id", Name = "TOKEN_ID_UNIQUE", IsUnique = true)]
public partial class AuthToken  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("AUTH_TOKEN")]
    [StringLength(45)]
    public string? AuthToken1 { get; set; }

    [Column("TOKEN_DATE", TypeName = "datetime")]
    public DateTime? TokenDate { get; set; }
}
