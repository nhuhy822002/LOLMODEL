using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace LOLMODEL.Models
{
    public class ModelGenreViewModel
    {
        public List<Lolmodel>? Models { get; set; }
        public SelectList? Genres { get; set; }
        public string? BookGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
