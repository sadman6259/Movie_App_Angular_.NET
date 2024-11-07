using System;
using System.Collections.Generic;

namespace Movie_API.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string? MovieTitle { get; set; }

    public int? ReleaseYear { get; set; }

    public string PostarImage { get; set; }
}
public partial class MovieDTO
{
    public int Id { get; set; }

    public string? MovieTitle { get; set; }

    public int? ReleaseYear { get; set; }

    public string PostarImage { get; set; }
}