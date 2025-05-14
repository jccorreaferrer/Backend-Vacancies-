using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace vacancyApiNET8.Models;

public partial class Status
{
    public int IdStatus { get; set; }

    public int? IdCatStatus { get; set; }

    public int? IdNote { get; set; }

    public int? InsertUser { get; set; }

    public DateOnly? InsertDate { get; set; }

    public int? UpdateUser { get; set; }

    public DateOnly? UpdateDate { get; set; }
    [JsonIgnore]
    public virtual CatStatus? IdCatStatusNavigation { get; set; }
    [JsonIgnore]
    public virtual Note? IdNoteNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
}
