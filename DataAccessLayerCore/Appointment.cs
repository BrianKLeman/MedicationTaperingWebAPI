using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Services.Interfaces.IModels;
using Microsoft.EntityFrameworkCore;

namespace test;

[Table("appointments")]
[Index("Id", Name = "APPOINTMENT_ID_UNIQUE", IsUnique = true)]
public partial class Appointment  : IId, IPersonID
{
    [Key]
    [Column("ID")]
    public uint Id { get; set; }

    [Column("APPOINTMENT_NAME")]
    [StringLength(45)]
    public string? AppointmentName { get; set; }

    [Column("APPOINTMENT_DATE", TypeName = "datetime")]
    public DateTime? AppointmentDate { get; set; }

    [Column("PERSON_ID")]
    public uint PersonId { get; set; }

    [Column("CREATED_DATE", TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column("CREATED_BY")]
    [StringLength(3)]
    public string? CreatedBy { get; set; }
}
