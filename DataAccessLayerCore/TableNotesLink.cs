using System;
using System.Collections.Generic;

namespace DataAccessLayerCore;

/// <summary>
/// Phenomena Notes Links
/// </summary>
public partial class TableNotesLink
{
    public uint TableNotesLinksId { get; set; }

    public string Table { get; set; } = null!;

    public int NotesId { get; set; }

    public int PersonId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public DateTime? PersonIdAddedDate { get; set; }

    public uint? EntityId { get; set; }
}
