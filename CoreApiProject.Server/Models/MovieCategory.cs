using System;
using System.Collections.Generic;

namespace CoreApiProject.Server.Models;

public partial class MovieCategory
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public bool IsVisible { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
