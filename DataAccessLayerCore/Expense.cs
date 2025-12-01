using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("expenses")]
[Index("Id", Name = "ID_UNIQUE", IsUnique = true)]
public partial class Expense  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("EXPENSES_NAME")]
    [StringLength(45)]
    public string? ExpensesName { get; set; }

    [Column("DATE_DUE", TypeName = "datetime")]
    public DateTime? DateDue { get; set; }

    [Column("REOCCURING")]
    public sbyte? Reoccuring { get; set; }

    [Column("ON_DAY")]
    public int? OnDay { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("BALANCE")]
    [Precision(10)]
    public decimal? Balance { get; set; }

    [Column("REGULAR_PAYMENT")]
    [Precision(10)]
    public decimal? RegularPayment { get; set; }
}
