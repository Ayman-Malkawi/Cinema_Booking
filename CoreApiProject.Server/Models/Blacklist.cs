using System;
using System.Collections.Generic;

namespace CoreApiProject.Server.Models;

public partial class Blacklist
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Reason { get; set; }

    public virtual User? User { get; set; }
}
