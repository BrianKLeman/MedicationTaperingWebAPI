using System;
using System.Collections.Generic;

namespace DataAccessLayerCore;

public partial class AuthToken
{
    public int TokenId { get; set; }

    public int? PeopleId { get; set; }

    public string? AuthToken1 { get; set; }

    public DateTime? TokenDate { get; set; }
}
